// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsDelega.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class InsDelega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                //recupero societa
                IAccount dataD = servizioAccount.DetailId(UserId);
                if (dataD != null)
                {
                    hdcodsocieta.Value = dataD.Codsocieta;
                }


                List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner(UserId);
                if (dataOpt != null && dataOpt.Count > 0)
                {
                    int count = 1;

                    foreach (IContratti resultOpt in dataOpt)
                    {
                        if (count == 1)
                        {
                            ddlUsers.SelectedValue = resultOpt.UserId.ToString();

                            if (resultOpt.Flgemailmulte == 1)
                            {
                                flgemailmulte.Checked = true;
                            }
                            else
                            {
                                flgemailmulte.Checked = false;
                            }

                            if (resultOpt.Flgemailpenali == 1)
                            {
                                flgemailpenali.Checked = true;
                            }
                            else
                            {
                                flgemailpenali.Checked = false;
                            }

                            if (resultOpt.Flgemailticket == 1)
                            {
                                flgemailticket.Checked = true;
                            }
                            else
                            {
                                flgemailticket.Checked = false;
                            }
                        }

                        if (count == 2)
                        {
                            ddlUsers2.SelectedValue = resultOpt.UserId.ToString();

                            if (resultOpt.Flgemailmulte == 1)
                            {
                                flgemailmulte2.Checked = true;
                            }
                            else
                            {
                                flgemailmulte2.Checked = false;
                            }

                            if (resultOpt.Flgemailpenali == 1)
                            {
                                flgemailpenali2.Checked = true;
                            }
                            else
                            {
                                flgemailpenali2.Checked = false;
                            }

                            if (resultOpt.Flgemailticket == 1)
                            {
                                flgemailticket2.Checked = true;
                            }
                            else
                            {
                                flgemailticket2.Checked = false;
                            }
                        }

                        if (count == 3)
                        {
                            ddlUsers3.SelectedValue = resultOpt.UserId.ToString();

                            if (resultOpt.Flgemailmulte == 1)
                            {
                                flgemailmulte3.Checked = true;
                            }
                            else
                            {
                                flgemailmulte3.Checked = false;
                            }

                            if (resultOpt.Flgemailpenali == 1)
                            {
                                flgemailpenali3.Checked = true;
                            }
                            else
                            {
                                flgemailpenali3.Checked = false;
                            }

                            if (resultOpt.Flgemailticket == 1)
                            {
                                flgemailticket3.Checked = true;
                            }
                            else
                            {
                                flgemailticket3.Checked = false;
                            }
                        }
                        count++;
                    }
                }
            }
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IContrattiBL servizioContratti = new ContrattiBL();

            string operazioneok = string.Empty;
            Guid UserId1 = SeoHelper.GuidString(ddlUsers.SelectedValue);
            Guid UserId2 = SeoHelper.GuidString(ddlUsers2.SelectedValue);
            Guid UserId3 = SeoHelper.GuidString(ddlUsers3.SelectedValue);

            //reset deleghe
            IContratti DeleteDelega = new Contratti
            {
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            servizioContratti.DeleteDeleghePartner(DeleteDelega);

            //se primo utente delegato
            if (UserId1 != Guid.Empty)
            {
                IContratti DelNew = new Contratti
                {
                    UserId = UserId1,
                    Uidtenant = Uidtenant
                };

                if (flgemailmulte.Checked)
                {
                    DelNew.Flgemailmulte = 1;
                }
                else
                {
                    DelNew.Flgemailmulte = 0;
                }

                if (flgemailpenali.Checked)
                {
                    DelNew.Flgemailpenali = 1;
                }
                else
                {
                    DelNew.Flgemailpenali = 0;
                }

                if (flgemailticket.Checked)
                {
                    DelNew.Flgemailticket = 1;
                }
                else
                {
                    DelNew.Flgemailticket = 0;
                }



                if (servizioContratti.InsertDelegaDriver(DelNew) == 1)
                {
                    operazioneok += "1";
                }
                else
                {
                    operazioneok += "0";
                }
            }

            //se secondo utente delegato
            if (UserId2 != Guid.Empty)
            {
                IContratti DelNew2 = new Contratti
                {
                    UserId = UserId2,
                    Uidtenant = Uidtenant
                };

                if (flgemailmulte2.Checked)
                {
                    DelNew2.Flgemailmulte = 1;
                }
                else
                {
                    DelNew2.Flgemailmulte = 0;
                }

                if (flgemailpenali2.Checked)
                {
                    DelNew2.Flgemailpenali = 1;
                }
                else
                {
                    DelNew2.Flgemailpenali = 0;
                }

                if (flgemailticket2.Checked)
                {
                    DelNew2.Flgemailticket = 1;
                }
                else
                {
                    DelNew2.Flgemailticket = 0;
                }

                if (servizioContratti.InsertDelegaDriver(DelNew2) == 1)
                {
                    operazioneok += "1";
                }
                else
                {
                    operazioneok += "0";
                }
            }

            //se terzo utente delegato
            if (UserId3 != Guid.Empty)
            {
                IContratti DelNew3 = new Contratti
                {
                    UserId = UserId3,
                    Uidtenant = Uidtenant
                };

                if (flgemailmulte3.Checked)
                {
                    DelNew3.Flgemailmulte = 1;
                }
                else
                {
                    DelNew3.Flgemailmulte = 0;
                }

                if (flgemailpenali3.Checked)
                {
                    DelNew3.Flgemailpenali = 1;
                }
                else
                {
                    DelNew3.Flgemailpenali = 0;
                }

                if (flgemailticket3.Checked)
                {
                    DelNew3.Flgemailticket = 1;
                }
                else
                {
                    DelNew3.Flgemailticket = 0;
                }

                if (servizioContratti.InsertDelegaDriver(DelNew3) == 1)
                {
                    operazioneok += "1";
                }
                else
                {
                    operazioneok += "0";
                }
            }

            if (operazioneok.IndexOf("0") != -1)
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Errore inserimento delega. Riprova. ";
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Delega salvata correttamente</a>";
            }            
        }
    }
}
