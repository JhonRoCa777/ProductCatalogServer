using System.Security.Cryptography;
using System.Text;

namespace ProductCatalog.Infrastructure.Adapters.Utils
{
    public class EncrypUtil
    {
        public string Encrypt(string txt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txt));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
