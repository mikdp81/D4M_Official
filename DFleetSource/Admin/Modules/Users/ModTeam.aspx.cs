// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModTeam.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Linq;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Users
{
    public partial class ModTeam : System.Web.UI.Page
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
            IAccountBL servizioAccount = new AccountBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {

                    IAccount data = servizioAccount.DetailTeamId(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }
        private void BindData(IAccount data)
        {
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            string[] selectectusers = new string[] { };
            string[] selectectpage = new string[] { };
            int i = 0;
            int y = 0;

            ddlStatus.SelectedValue = Convert.ToString(data.Stato, CultureInfo.CurrentCulture);
            txtTeam.Text = data.Team;
            hdidteam.Value = SeoHelper.CheckIntString(data.Idteam);
            hduid.Value = SeoHelper.CheckGuidString(data.Uid);

            //recupero e assegnazione utenti
            List<IAccount> dataUserTeam = servizioAccount.SelectUserTeam(data.Idteam);

            if (dataUserTeam != null && dataUserTeam.Count > 0)
            {
                foreach (IAccount resultUserTeam in dataUserTeam)
                {
                    selectectusers = new List<string>(selectectusers) { resultUserTeam.Iduser.ToString() }.ToArray();
                }
            }

            List<IAccount> dataUser = servizioAccount.SelectUsersSearch();

            if (dataUser != null && dataUser.Count > 0)
            {
                foreach (IAccount resultUser in dataUser)
                {
                    ddlUtenti.Items.Insert(y, new ListItem(resultUser.Cognome, resultUser.Iduser.ToString()));
                    var item = ddlUtenti.Items[y];

                    if (selectectusers.Contains(item.Value))
                    {
                        ddlUtenti.Items[y].Selected = true;
                    }

                    y++;
                }
            }


            //recupero e assegnazione attivita
            List<IAccount> dataPageTeam = servizioAccount.SelectPageTeam(data.Idteam);

            if (dataPageTeam != null && dataPageTeam.Count > 0)
            {
                foreach (IAccount resultPageTeam in dataPageTeam)
                {
                    selectectpage = new List<string>(selectectpage) { resultPageTeam.Idpagina.ToString() }.ToArray();
                }
            }

            List<IUtilitys> dataPage = servizioUtility.SelectAllAttivita();

            if (dataPage != null && dataPage.Count > 0)
            {
                foreach (IUtilitys resultPage in dataPage)
                {
                    ddlAttivit.Items.Insert(i, new ListItem(resultPage.Pagina, resultPage.Idpagina.ToString()));
                    var item = ddlAttivit.Items[i];

                    if (selectectpage.Contains(item.Value))
                    {
                        ddlAttivit.Items[i].Selected = true;
                    }

                    i++;
                }
            }

        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateTeam("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateTeam("salvachiudi");
        }


        public void UpdateTeam(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();

            IAccount teamNew = new Account();

            string error = string.Empty;

            string tmputenti = string.Empty;
            string tmpattivita = string.Empty;
            int idteam = SeoHelper.IntString(hdidteam.Value);

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
            teamNew.Uid = new Guid(SeoHelper.EncodeString(hduid.Value));
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
                if (servizioAccount.UpdateTeam(teamNew) == 1)
                {
                    //reset utente nel team
                    IAccount teamuserDel = new Account
                    {
                        Idteam = idteam,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioAccount.DeleteUserTeam(teamuserDel);

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


                    //reset attivita nel team
                    IAccount teampageDel = new Account
                    {
                        Idteam = idteam,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioAccount.DeletePageTeam(teampageDel);

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
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + teamNew.Uid);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewTeam") + "'>Ritorna alla Lista</a>";
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
