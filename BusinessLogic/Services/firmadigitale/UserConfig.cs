using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigitale
{
    public class UserConfig
    {
        // JWT
        public string ClientId { get; set;  }
        public string ImpersonatedUserId { get; set;  }
        public string AuthServer { get; set;  }
        public string PrivateKey { get; set; }

        // SIGN
        public string BasePath { get; set; }
        public string AccountId { get; set; }
        public string PingUrl { get; set; }
        public string SignerEmail { get; set; }
        public string SignerName { get; set; }
        public string SignerClientId { get; set; }
    }
}
