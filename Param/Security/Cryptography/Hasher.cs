using System.Text;

namespace Param.Security.Cryptography
{
    public abstract class Hasher : IHasher
    {
        public abstract string Execute(byte[] data);

        public abstract string Execute(string data);

        protected string ByteArrayToString(byte[] data)
        {
            int i;

            var result = new StringBuilder(data.Length);

            for (i = 0; i < data.Length; i++)
            {
                result.Append(data[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}