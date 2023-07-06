using System;

namespace FirmaDigitale
{
    internal class User
    {
        internal string Name { get; set; }
        internal string AccessToken { get; set; }
        internal string RefreshToken { get; set; }
        internal DateTime? ExpireIn { get; set; }
        internal string AccountId { get; set; }
    }
}