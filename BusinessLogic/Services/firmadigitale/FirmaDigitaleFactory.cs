using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigitale
{
    public class FirmaDigitaleFactory
    {
        public static IFirmaDigitale CreateInstance(UserConfig userConfig, string returnUrl, string docPdf)
        {
            return new FirmaDigitale(userConfig, returnUrl, docPdf);
        }
    }
}
