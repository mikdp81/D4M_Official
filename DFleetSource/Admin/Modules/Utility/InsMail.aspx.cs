// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsConti.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.Collections.Generic;

namespace DFleet.Admin.Modules.Utility
{
    public partial class InsMail : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(89)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false; 
            
            if (Request.QueryString["ins"] != null)
            {
                if (Request.QueryString["ins"].ToString().ToUpper() == "OK")
                {
                    //messaggio avvenuto inserimento
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Operazione effettuata correttamente";
                }
            }
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertMail("prova");
        }
        /*protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertMail("tutti");
        }*/

        public void InsertMail(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            string error = string.Empty;


            if (ddlTemplate.SelectedValue == "0")
            {
                ddlTemplate.CssClass = "form-control is-invalid";
                error += "scegliere un template per proseguire<br />";
            }
            else
            {
                ddlTemplate.CssClass = "form-control";
            }


            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                //dettagli template
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(SeoHelper.IntString(ddlTemplate.SelectedValue));
                if (dataTemplate != null)
                {
                    string oggetto = dataTemplate.Oggetto;
                    string corpo = dataTemplate.Corpo;

                    if (opzione.ToUpper() == "PROVA")
                    {
                        //invio mail di prova
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        MailHelper.SendMail("", "web@araneamarketing.it", "mimezzina@deloitte.it", "mprezzano@deloitte.it", "", "", "TEST " + oggetto, servizioUtility.InsTextEmail(corpo,"","","","","","150,01","","","","","","","","",""), "", datiUtente.ReturnObjectTenant());
                    }


                    /*if (opzione.ToUpper() == "TUTTI")
                    {
                        bool resultMail; 

                        //ricerca tutte le email degli utenti ai quali inviare la mail
                        List<IUtilitys> dataUserMail = servizioUtility.SelectAllUserEmail();

                        if (dataUserMail != null && dataUserMail.Count > 0)
                        {
                            foreach (IUtilitys resultUserMail in dataUserMail)
                            {
                                //invio mail
                                resultMail = MailHelper.SendMail("", resultUserMail.Email, "", "", "", "", oggetto, servizioUtility.InsTextEmail(corpo, resultUserMail.Nome, resultUserMail.Cognome,
                                    resultUserMail.Matricola, resultUserMail.Codsocieta, resultUserMail.Codgrade, resultUserMail.Param1, resultUserMail.Param2, resultUserMail.Param3, resultUserMail.Param4,
                                    resultUserMail.Param5, resultUserMail.Param6, resultUserMail.Param7, resultUserMail.Param8, resultUserMail.Param9, resultUserMail.Param10), "");

                                if (resultMail) //se mail andata a buon fine aggiorna flg inviato e data invio
                                {
                                    servizioUtility.UpdateInvioMail(resultUserMail.Idinvio);
                                }
                            }
                        }
                    }*/

                }


                Response.Redirect("InsMail?ins=ok");



            }
        }

    }
}
