namespace Param.IO.Compression
{
    public abstract class Compressor : ICompressor
    {
        public abstract string Archive(string data);

        public abstract byte[] Archive(byte[] data);

        public abstract string Extract(string data);

        public abstract byte[] Extract(byte[] data);
    }
}