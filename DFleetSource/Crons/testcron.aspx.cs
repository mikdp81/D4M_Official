using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AraneaUtilities.Auth;
using BusinessLogic;
using BusinessObject;

namespace DFleet.Crons
{
    public partial class testcron : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // METTERE IL VALIDATE!!!
            //AuthManager.SignIn2("web@araneamarketing.it", true);
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            ICronBL servizioCron = new CronBL();
            HttpResponse response = HttpContext.Current.Response;

            string filecsv = DateTime.Now.Day.ToString("d2") + DateTime.Now.Month.ToString("d2") + DateTime.Now.Year + "_fuel";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            StringBuilder builder = new StringBuilder();
            builder.Append("MODELLO;IDEMPL;ANNUMBER;CODGEST;IDFUELCARD;DTSTARTVL;DTENDVL");
            builder.AppendLine();


            List<IFileTracciati> dataExport = servizioFileTracciati.SelectViewConcur("", "" , Uidtenant, 100000, 1);

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (IFileTracciati resultExport in dataExport)
                {
                    builder.Append(resultExport.Modello + ";" + resultExport.Matricola + ";" + resultExport.Targa + ";" + resultExport.Codservice + ";" + resultExport.Numerofuelcard + ";" + resultExport.Datainizioperiodo.ToString("dd/MM/yyyy") + ";31/12/2999");
                    builder.AppendLine();
                }
            }

            //salva file csv
            File.WriteAllText(RequestExtensions.GetPathPhisicalApplication() + "/Repository/export/" + filecsv, builder.ToString());

            ICron cronNew = new Cron
            {
                Tipodocumento = "Concur",
                Pathfile = "export/",
                Nomefile = SeoHelper.EncodeString(filecsv)
            };
            servizioCron.InsertFileCron(cronNew);

            response.Write("File " + filecsv + " creato correttamente");
        }
    }
}
