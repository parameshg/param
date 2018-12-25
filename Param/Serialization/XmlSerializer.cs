using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Param.Serialization
{
    public class XmlSerializer<T> : Serializer<T>
    {
        public override string Serialize(T o)
        {
            var result = string.Empty;

            if (o is Exception)
            {
                var bin = new BinaryFormatter();

                using (var stream = new MemoryStream())
                {
                    bin.Serialize(stream, o);

                    result = Convert.ToBase64String(stream.ToArray());
                }
            }
            else
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var stream = new MemoryStream())
                {
                    if (stream.CanWrite)
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            serializer.Serialize(writer.BaseStream, o);

                            if (stream.CanSeek)
                            {
                                stream.Position = 0;
                            }

                            if (stream.CanRead)
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    result = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public override T Deserialize(string data)
        {
            T result = default(T);

            if (typeof(T) == typeof(Exception))
            {
                var bin = new BinaryFormatter();

                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(data)))
                {
                    result = (T)bin.Deserialize(stream);
                }
            }
            else
            {
                var serializer = new XmlSerializer(typeof(T));

                using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(data)))
                {
                    result = (T)serializer.Deserialize(stream);
                }
            }

            return result;
        }
    }
}