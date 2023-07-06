using System;
using System.Security.Cryptography;

namespace Sicurezza
{
    internal interface ITransformer : IDisposable
    {
        byte[] IV { set; }

        byte[] Key { set; }

        new void Dispose();

        ICryptoTransform GetCryptoServiceProvider();
    }
}
