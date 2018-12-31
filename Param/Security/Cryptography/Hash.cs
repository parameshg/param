namespace Param.Security.Cryptography
{
    public class Hash
    {
        private readonly IHasher _hasher;

        public Hash(HashType type)
        {
            if (type.Equals(HashType.MD5))
            {
                _hasher = new MD5Hasher();
            }

            if (type.Equals(HashType.SHA256))
            {
                _hasher = new SHA256Hasher();
            }
        }

        public string Execute(byte[] data)
        {
            return _hasher.Execute(data);
        }

        public string Execute(string data)
        {
            return _hasher.Execute(data);
        }
    }
}