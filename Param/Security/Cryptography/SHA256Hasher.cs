using System.Security.Cryptography;
using System.Text;

namespace Param.Security.Cryptography
{
    public class SHA256Hasher : Hasher
    {
        public override string Execute(byte[] data)
        {
            var result = string.Empty;

            result = ByteArrayToString(new SHA256Managed().ComputeHash(data));

            return result;
        }

        public override string Execute(string data)
        {
            return Execute(Encoding.ASCII.GetBytes(data));
        }
    }
}