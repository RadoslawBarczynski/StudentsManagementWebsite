using System.Text;
using System;
using System.Security.Cryptography;

namespace SchoolGradeManager.Services
{
    public class PasswordHashing
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
                return hashedPassword;
            }
        }

        public static void Main()
        {
            string password = "password";
            string hashedPassword = HashPassword(password);

            Console.WriteLine("Zahaszowane hasło: " + hashedPassword);
        }
    }
}
