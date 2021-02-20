using Isopoh.Cryptography.Argon2;

namespace Questy.Infrastructure.Helpers.Security
{
    public static class EncryptionHelper
    {
        public static string HashPassword(string password)
        {
            return Argon2.Hash(password);
        }

        public static bool VerifyPassword(string hash, string password)
        {
            return Argon2.Verify(hash, password);
        }
    }
}
