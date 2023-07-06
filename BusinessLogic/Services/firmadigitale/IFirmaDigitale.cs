using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigitale
{
    public interface IFirmaDigitale
    {
        void Avvio();
        void DownloadFile();

        string NomeFileFirmato();

    }
}
