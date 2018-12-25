using System.Security.Cryptography;
using System.Text;

namespace Param.Security.Cryptography
{
    public class MD5Hasher : Hasher
    {
        public override byte[] Execute(byte[] data)
        {
            byte[] result = null;

            result = new MD5CryptoServiceProvider().ComputeHash(data);

            return result;
        }

        public override string Execute(string data)
        {
            return ByteArrayToString(Execute(Encoding.ASCII.GetBytes(data)));
        }
    }
}