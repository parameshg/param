namespace Param.IO.Compression
{
    public interface ICompressor
    {
        string Archive(string data);

        byte[] Archive(byte[] data);

        string Extract(string data);

        byte[] Extract(byte[] data);
    }
}