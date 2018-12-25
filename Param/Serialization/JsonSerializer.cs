using Newtonsoft.Json;

namespace Param.Serialization
{
    public class JsonSerializer<T> : Serializer<T>
    {
        public override string Serialize(T o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public override T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}