using System;
using System.Security.Cryptography;
using System.Text;

namespace FilmsListBackEnd.Services
{
    public class Utilities
    {
        public Utilities()
        {
        }
        public static string ComputeSha256Hash(string data)
        {
            if(data == null)
            {
                Console.WriteLine("Password hashing failed, password is null.");
                throw new Exception("Password hashing failed, password is null.");
            }
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Password hashing failed:" + e);
                throw new Exception("Password hashing failed:" + e);
            }
        }
    }
}
