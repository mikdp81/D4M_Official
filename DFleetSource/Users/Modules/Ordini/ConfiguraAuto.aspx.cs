// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ConfiguraAuto.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;

namespace DFleet.Users.Modules.Ordini
{
    public partial class ConfiguraAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            hdcodsocieta.Value = ReturnCodSocieta();
            hdcodgrade.Value = ReturnCodGrade();
            hdcodcarlist.Value = ReturnCodCarList();
            hdidutente.Value = ReturnIdUtente();
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            pnlMaxConf.Visible = false;
            loadPage();
            loadPage2();


            //recupero idapprovazione
            int idutente = 0;
            int idapprovazione = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //conta configurazioni effettuate
            if (servizioContratti.SelectCountConfigurazioni(idapprovazione) >= SeoHelper.MaxNumConfigurazioni())
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = false;
                pnlMaxConf.Visible = true;
                buttonrinuncia.Visible = false;
                lblMaxConf.Text = "Spiacente Hai raggiunto il limite massimo di quotazioni effettuate.";
            }

            if (servizioContratti.SelectCountConfigurazioni(idapprovazione) >= 1 && servizioContratti.SelectCountConfigurazioni(idapprovazione) < SeoHelper.MaxNumConfigurazioni())
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                pnlMaxConf.Visible = false;
                buttonrinuncia.Visible = false;
            }

            //conta configurazioni effettuate
            if (servizioContratti.SelectCountConfigurazioniPool(UserId) >= SeoHelper.MaxNumConfigurazioniPool())
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = false;
                pnlMaxConf.Visible = true;
                buttonrinuncia.Visible = false;
                lblMaxConf.Text = "Hai raggiunto il limite massimo di configurazioni.";
            }


            IContratti dataP = servizioContratti.ReturnUidCarPolicy(UserId);
            if (dataP != null)
            {
                if (string.IsNullOrEmpty(dataP.Documentocarpolicy))
                {
                    pnlStep1.Visible = false;
                    pnlStep2.Visible = false;
                    pnlMaxConf.Visible = true;
                    lblMaxConf.Text = "<img src='../../../plugins/images/alert.svg' width='300' alt='' border='0' /><br /><br />Firma il documento di Car Policy che trovi nella sezione <a href='../Dash/Documenti'>documenti</a> <br />Allega il pdf della tua patente in corso di validit&agrave;. <br /><br /><a href='UploadCarPolicy'>Carica qui il documento firmato</a>";
                }
            }

            //controllo se polizza e attiva
            if (!servizioContratti.ExistUserCarPolicyActive(idutente))
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = false;
                pnlMaxConf.Visible = true;
                buttonrinuncia.Visible = false;
                lblMaxConf.Text = "Spiacente. Non puoi effettuare una nuova configurazione.";
            }
        }
        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            int totaleRighe = servizioContratti.SelectCountCarPolicyPool(SeoHelper.EncodeString(hdcodsocieta.Value), SeoHelper.EncodeString(hdcodgrade.Value));

            /*if (gvRicCarListPool.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicCarListPool.HeaderRow.TableSection = TableRowSection.TableHeader;
            }*/

            if (totaleRighe == 0)
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }
        }

        public void loadPage2()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage2.Visible = false;
            int totaleRighe = servizioContratti.SelectCountCarPolicyStep2(SeoHelper.IntString(hdidutente.Value));

            /*if (gvRicCarListStep2.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicCarListStep2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }*/

            if (totaleRighe == 0)
            {
                lblMessage2.Text = "Nessuna auto disponibile.";
                pnlMessage2.Visible = true;
            }
            else
            {
                pnlMessage2.Visible = false;
            }
        }

        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Codsocieta;
            }

            return retVal;
        }
        public string ReturnCodGrade()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Gradecode;
            }

            return retVal;
        }

        public string ReturnCodCarList()
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(dataId.Codsocieta, dataId.Gradecode);
                if (dataCodPol != null)
                {
                    IContratti dataCodLis = servizioContratti.ReturnCodCarList(dataCodPol.Codcarpolicy);
                    if (dataCodLis != null)
                    {
                        retVal = dataCodLis.Codcarlist;
                    }
                }
            }

            return retVal;
        }
        public string ReturnIdUtente()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Iduser.ToString();
            }

            return retVal;
        }


        protected void btnIgnora_Click(object sender, EventArgs e)
        {
            pnlStep2.Visible = true;
            pnlStep1.Visible = false;
        }
        public string ReturnFotoAuto(string fotoauto)
        {
            string retVal;

            if (!string.IsNullOrEmpty(fotoauto))
            {
                retVal = "<img src='../../../DownloadFile?type=auto&nomefile=" + fotoauto + "' class='img-responsive' >";
            }
            else
            {
                retVal = "<img src='../../../Repository/auto/nofoto.png' class='img-responsive' >";
            }

            return retVal;
        }
    }
}
