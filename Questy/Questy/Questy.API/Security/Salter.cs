using System.Security.Cryptography;

namespace Questy.API.Security
{
    /// <summary>
    /// Generate a random Salt, Used for Password Security.
    /// Dmytro Lytvyn
    /// 10/13/2020
    /// </summary>
    public class Salter
    {
        private static int saltLengthLimit = 8;
        public byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}
