using System.Security.Cryptography;
using System.Text;

namespace Param.Security.Cryptography
{
    public class MD5Hasher : Hasher
    {
        public override string Execute(byte[] data)
        {
            var result = string.Empty;

            result = ByteArrayToString(new MD5CryptoServiceProvider().ComputeHash(data));

            return result;
        }

        public override string Execute(string data)
        {
            return Execute(Encoding.ASCII.GetBytes(data));
        }
    }
}