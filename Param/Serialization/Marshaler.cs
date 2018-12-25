namespace Param.Serialization
{
    public class Marshaler<T>
    {
        private readonly ISerializer<T> _serializer;

        public Marshaler(SerializationType type)
        {
            if (type == SerializationType.Xml)
            {
                _serializer = new XmlSerializer<T>();
            }

            if (type == SerializationType.Json)
            {
                _serializer = new JsonSerializer<T>();
            }
        }

        public string Marshal(T o)
        {
            return _serializer.Serialize(o);
        }

        public T Unmarshal(string data)
        {
            return _serializer.Deserialize(data);
        }

        public void Save(T o, string filename)
        {
            _serializer.Save(o, filename);
        }

        public T Load(string filename)
        {
            return _serializer.Load(filename);
        }
    }
}