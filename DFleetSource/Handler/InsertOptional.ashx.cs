// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsertOptional.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using BusinessObject;
using BusinessLogic;
using System.Globalization;
using System.Web.Script.Serialization;

namespace DFleet.Handler
{
    /// <summary>
    /// Summary description for InsertOptional
    /// </summary>
    public class InsertOptional : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            ICarsBL servizioCars = new CarsBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string codjatoauto = request["codjatoauto"];
            string codoptional = request["codoptional"];
            string idordine = request["idordine"];
            int countoptional = SeoHelper.IntString(request["count"]);
            int mesicontratto = SeoHelper.IntString(request["mesi"]);
            string elencooptional = "";
            string optional;

            ICars dataD = servizioCars.DetailOptionalXCod(codoptional);
            {
                optional = dataD.Optional;
            }

            //dati optional
            ICars dataExs = servizioCars.ExistOptionalAuto(codjatoauto, codoptional);
            if (dataExs != null)
            {
                IContratti OptNew = new Contratti
                {
                    Idordine = SeoHelper.IntString(idordine),
                    Codoptional = SeoHelper.EncodeString(codoptional),
                    Importooptional = dataExs.Importooptional,
                    Giorniconsegnaagg = dataExs.Giorniconsegnaagg,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                if (servizioContratti.InsertOrdineOptional(OptNew) == 1)
                {
                    elencooptional += "<div class='optional-table blockoptional' id='blockopt_" + countoptional + "' style='height:80px;'>";
                    elencooptional += "<div class='optional-table-left'><a data-count='" + countoptional + "' data-id='" + idordine + "' data-optional='" + codoptional + "' class='text-inverse p-r-10 deleteopt' data-toggle='tooltip' data-placement='left' title='' data-original-title='Elimina Optional'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a></div>";
                    elencooptional += "<div class='optional-table-center'>" + optional + " (" + codoptional + ")</div>";
                    elencooptional += "<div class='optional-table-right'>";
                    elencooptional += " &euro; <input type='text' class='importooptann' name='importoann_" + countoptional + "' id='importoann_" + countoptional + "' data-id='" + countoptional + "' size='10' maxlength='20' value='" + (OptNew.Importooptional * mesicontratto) + "' /> Annuale";
                    elencooptional += " <br /> &euro; <input type='text' class='importoopt' name='importo_" + countoptional + "' id='importo_" + countoptional + "' data-id='" + countoptional + "' size='10' maxlength='20' style='margin-top:10px;' value='" + OptNew.Importooptional + "' /> ";
                    elencooptional += "<input type='hidden' name='codoptional_" + countoptional + "' value='" + codoptional + "' /> ";
                    elencooptional += "</div>";
                    elencooptional += "</div>";

                    response.Write(elencooptional);
                }
                else 
                {
                    response.Write("KO");
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
