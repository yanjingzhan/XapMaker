using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UnityScreenShoter.Utility
{
    public class CryptHelper
    {
        public static string Decrypt(string input)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(input);
                byte[] salt = Encoding.UTF8.GetBytes("qwertyuiophoepqpqipi");
                AesManaged managed = new AesManaged();
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("!@#$%^&*())_", salt);
                managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
                managed.KeySize = managed.LegalKeySizes[0].MaxSize;
                managed.Key = bytes.GetBytes(managed.KeySize / 8);
                managed.IV = bytes.GetBytes(managed.BlockSize / 8);
                ICryptoTransform transform = managed.CreateDecryptor();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.Close();
                byte[] buffer3 = stream.ToArray();
                return Encoding.UTF8.GetString(buffer3, 0, buffer3.Length);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Encrypt(string input)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(input);
                byte[] salt = Encoding.UTF8.GetBytes("qwertyuiophoepqpqipi");
                AesManaged managed = new AesManaged();
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("!@#$%^&*())_", salt);
                managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
                managed.KeySize = managed.LegalKeySizes[0].MaxSize;
                managed.Key = bytes.GetBytes(managed.KeySize / 8);
                managed.IV = bytes.GetBytes(managed.BlockSize / 8);
                ICryptoTransform transform = managed.CreateEncryptor();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.Close();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
