using System;
using System.Security.Cryptography;
using System.Text;

namespace AttendanceCollector.Helper
{
    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            if (password == null)
                password = "";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes =
                    Encoding.UTF8.GetBytes(password);

                byte[] hash =
                    sha256.ComputeHash(bytes);

                StringBuilder builder =
                    new StringBuilder();

                foreach (byte b in hash)
                {
                    builder.Append(
                        b.ToString("x2")
                    );
                }

                return builder.ToString();
            }
        }

        public static bool VerifyPassword(
            string password,
            string storedHash)
        {
            if (string.IsNullOrWhiteSpace(storedHash))
                return false;

            string passwordHash =
                HashPassword(password);

            return string.Equals(
                passwordHash,
                storedHash,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
}