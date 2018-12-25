using System.IO;

namespace Param.Serialization
{
    public abstract class Serializer<T> : ISerializer<T>
    {
        public abstract string Serialize(T o);

        public abstract T Deserialize(string data);

        public virtual void Save(T o, string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.AutoFlush = true;
                writer.Write(Serialize(o));
                writer.Flush();
            }
        }

        public virtual T Load(string filename)
        {
            T result = default(T);

            if (File.Exists(filename))
            {
                string data = string.Empty;

                using (var reader = new StreamReader(filename))
                {
                    data = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(data))
                {
                    result = Deserialize(data);
                }
            }

            return result;
        }
    }
}