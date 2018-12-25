namespace Param.IO.Compression
{
    public class Zip
    {
        private readonly ICompressor _compressor;

        public Zip(CompressionType type)
        {
            if (type == CompressionType.GZip)
            {
                _compressor = new GZipCompressor();
            }

            if (type == CompressionType.Deflate)
            {
                _compressor = new DeflateCompressor();
            }
        }

        public string Archive(string data)
        {
            return _compressor.Archive(data);
        }

        public byte[] Archive(byte[] data)
        {
            return _compressor.Archive(data);
        }

        public string Extract(string data)
        {
            return _compressor.Extract(data);
        }

        public byte[] Extract(byte[] data)
        {
            return _compressor.Extract(data);
        }
    }
}