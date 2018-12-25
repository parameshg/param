using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Param.IO.Compression
{
    public class GZipCompressor : Compressor
    {
        public override byte[] Archive(byte[] data)
        {
            byte[] result = null;

            using (var stream = new MemoryStream(data))
            {
                using (var ouput = new MemoryStream())
                {
                    using (var compressor = new GZipStream(ouput, CompressionMode.Compress))
                    {
                        stream.CopyTo(compressor);

                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }

        public override byte[] Extract(byte[] data)
        {
            byte[] result = null;

            using (var stream = new MemoryStream(data))
            {
                using (var ouput = new MemoryStream())
                {
                    using (var compressor = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        compressor.CopyTo(ouput);

                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }

        public override string Archive(string data)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(data))
            {
                var buffer = Encoding.ASCII.GetBytes(data);

                var archive = Archive(buffer);

                result = Convert.ToBase64String(archive);
            }

            return result;
        }

        public override string Extract(string data)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(data))
            {
                var buffer = Convert.FromBase64String(data);

                var archive = Extract(buffer);

                result = Encoding.ASCII.GetString(archive);
            }

            return result;
        }
    }
}