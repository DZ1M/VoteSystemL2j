using System;
using System.Security.Cryptography;

namespace VoteSystemL2j.Helpers
{
    public static class SecurityHelper
    {
        public static string CryptografaSenha(this string senha)
        {
            SHA1 sha = new SHA1Managed();
            return Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha)));
        }
    }
}
