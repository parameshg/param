namespace Param.Serialization
{
    public interface ISerializer<T>
    {
        string Serialize(T o);

        T Deserialize(string data);

        void Save(T o, string filename);

        T Load(string filename);
    }
}