namespace Param.Security.Cryptography
{
    public interface IHasher
    {
        byte[] Execute(byte[] data);

        string Execute(string data);
    }
}