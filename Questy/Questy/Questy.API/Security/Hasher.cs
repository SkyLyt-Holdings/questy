using Konscious.Security.Cryptography;
using System;
using System.Linq;
using System.Text;

namespace Questy.API.Security
{
    /// <summary>
    /// Generate a random Hash, Used for Password Security.
    /// Dmytro Lytvyn
    /// 10/13/2020
    /// </summary>
    public class Hasher
    {
        public byte[] Hash(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(32);
        }

        public bool Verify(string password, byte[] salt, byte[] hash)
        {
            var newHash = Hash(password, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}
