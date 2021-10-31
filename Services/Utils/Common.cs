using DappleWorks.Security;
using System;
using System.Linq;
using System.Text;

namespace Services.Utils
{
    public class Common
    {
        public static string HashPassword(string username, string password)
        {
            AESEncryption aES = new AESEncryption();
            return aES.EncryptPass(username, password);
        }

        public static bool VerifyPassword(string username, string password, string hashPassword)
        {
            AESEncryption aES = new AESEncryption();
            string passwordDecrypt = aES.DecryptPass(username, hashPassword);
            return password.Equals(passwordDecrypt);
        }

        public static string DecryptPassword(string username, string hashPassword)
        {
            AESEncryption aES = new AESEncryption();
            string passwordDecrypt = aES.DecryptPass(username, hashPassword);
            return passwordDecrypt;
        }

        public static string RandomString(int size, bool isNum = false)
        {
            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz123456789";

            if (isNum)
                chars = "1234567890";

            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, size)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        public static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}
