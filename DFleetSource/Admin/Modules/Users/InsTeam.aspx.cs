// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insUser.aspx.cs" company="">
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
using System.Web.UI.WebControls;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Users
{
    public partial class InsTeam : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(2)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertTeam("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertTeam("salvachiudi");
        }


        public void InsertTeam(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();

            IAccount teamNew = new Account();

            string error = string.Empty;

            string tmputenti = string.Empty;
            string tmpattivita = string.Empty;
            int idteam = 0;

            foreach (ListItem item in ddlUtenti.Items)
            {
                if (item.Selected)
                {
                    tmputenti += SeoHelper.EncodeString(item.Value) + ",";
                }
            }

            foreach (ListItem item in ddlAttivit.Items)
            {
                if (item.Selected)
                {
                    tmpattivita += SeoHelper.EncodeString(item.Value) + ",";
                }
            }

            teamNew.Team = SeoHelper.EncodeString(txtTeam.Text);
            teamNew.Stato = SeoHelper.EncodeString(ddlStatus.SelectedValue);
            teamNew.Uidtenant = SeoHelper.ReturnSessionTenant();

            if (string.IsNullOrEmpty(teamNew.Team))
            {
                txtTeam.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Team<br />";
            }
            else
            {
                txtTeam.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(teamNew.Stato))
            {
                ddlStatus.CssClass = "form-control is-invalid";
                error += "Selezionare uno Status<br />";
            }
            else
            {
                ddlStatus.CssClass = "form-control";
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
                if (servizioAccount.InsertTeam(teamNew) == 1)
                {
                    //recupero ultimo idteam
                    IAccount dataIdt = servizioAccount.UltimoIDTeam();
                    if (dataIdt != null)
                    {
                        idteam = dataIdt.Idteam;
                    }

                    //inserimento utenti nel team
                    if (!string.IsNullOrEmpty(tmputenti))
                    {
                        string[] utenti = tmputenti.Split(',');

                        foreach (var word in utenti)
                        {
                            if (SeoHelper.IntString(word) > 0)
                            {
                                IAccount teamuserNew = new Account
                                {
                                    Iduser = SeoHelper.IntString(word),
                                    Idteam = idteam,
                                    Uidtenant = SeoHelper.ReturnSessionTenant()
                                };
                                servizioAccount.InsertUserTeam(teamuserNew);
                            }
                        }
                    }

                    //inserimento attivita nel team
                    if (!string.IsNullOrEmpty(tmpattivita))
                    {
                        string[] attivita = tmpattivita.Split(',');

                        foreach (var word2 in attivita)
                        {
                            if (SeoHelper.IntString(word2) > 0)
                            {
                                IAccount teampageNew = new Account
                                {
                                    Idpagina = SeoHelper.IntString(word2),
                                    Idteam = idteam,
                                    Uidtenant = SeoHelper.ReturnSessionTenant()
                                };
                                servizioAccount.InsertPageTeam(teampageNew);
                            }
                        }
                    }
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + teamNew.Team);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset di tutti campi
                        ddlStatus.ClearSelection();
                        txtTeam.Text = "";
                        ddlUtenti.ClearSelection();
                        ddlAttivit.ClearSelection();

                        ddlStatus.CssClass = "form-control";
                        txtTeam.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewTeam") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewTeam");
                    }
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
        }

    }
}
