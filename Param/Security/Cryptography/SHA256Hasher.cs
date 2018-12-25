using System.Security.Cryptography;
using System.Text;

namespace Param.Security.Cryptography
{
    public class SHA256Hasher : Hasher
    {
        public override byte[] Execute(byte[] data)
        {
            byte[] result = null;

            result = new SHA256Managed().ComputeHash(data);

            return result;
        }

        public override string Execute(string data)
        {
            return ByteArrayToString(Execute(Encoding.ASCII.GetBytes(data)));
        }
    }
}