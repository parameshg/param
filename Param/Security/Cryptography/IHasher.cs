namespace Param.Security.Cryptography
{
    public interface IHasher
    {
        string Execute(byte[] data);

        string Execute(string data);
    }
}