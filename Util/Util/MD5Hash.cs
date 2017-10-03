using System.Security.Cryptography;
using System.Text;

namespace Util
{
    public class MD5Hash
    {
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach(byte b in data)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
