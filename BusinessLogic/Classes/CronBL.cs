// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CCronBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Threading;
using BaseProvider;
using System.Web;
using System.Diagnostics;
using BusinessObject;
using BusinessProvider;
using AraneaUtilities.Auth;
using System.Security;
using System.Web.Security;

namespace BusinessLogic
{
    [Serializable]
    public class CronBL : BaseBL, ICronBL
    {
        private ICronProvider ServizioCron
        {
            get { return ProviderFactoryCron.ServizioCron; }
        }
        public CronBL() : base() { }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectMulteDapagare()
        {
            return OdsCron.DefaultProvider.SelectMulteDapagare();
        }
        public int UpdatePagamento(Guid Uid, Guid Uidtenant)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdatePagamento(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectCedolini(string mese, string anno)
        {
            return OdsCron.DefaultProvider.SelectCedolini(mese, anno);
        }
        public int InsertFileCron(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFileCron(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectContrattiUserInScadenza()
        {
            return OdsCron.DefaultProvider.SelectContrattiUserInScadenza();
        }
        public bool ExistUserCarPolicy(int idutente)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistUserCarPolicy(idutente);
            return retVal;
        }
        public int InsertUserCarPolicy(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertUserCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron DetailId(Guid UserId)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailId(UserId);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectContrattiDaChiudere()
        {
            return OdsCron.DefaultProvider.SelectContrattiDaChiudere();
        }
        public int UpdateContrattiDaChiudere(Guid Uid, Guid Uidtenant)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateContrattiDaChiudere(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateContrattiAssDaChiudere(int idcontratto, Guid Uidtenant)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateContrattiAssDaChiudere(idcontratto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron UrlBlob()
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.UrlBlob();
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectComunicazioniInserite()
        {
            return OdsCron.DefaultProvider.SelectComunicazioniInserite();
        }
        public ICron ReturnTemplateEmail(int idtemplate)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ReturnTemplateEmail(idtemplate);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcur()
        {
            return OdsCron.DefaultProvider.SelectViewConcur();
        }
        public int UpdateStoricoImportazione(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateStoricoImportazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron DetailImportazioni(int idprog)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailImportazioni(idprog);
            return data;
        }
        public int InsertStoricoImportazione(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertStoricoImportazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectImportazioni()
        {
            return OdsCron.DefaultProvider.SelectImportazioni();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectImportazioniCron(Guid Uidtenant)
        {
            return OdsCron.DefaultProvider.SelectImportazioniCron(Uidtenant);
        }
        public int UpdateFuelCardConsumoCount(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal;
            retVal = servizioCron.UpdateFuelCardConsumoCount(value);
            return retVal;
        }
        public int InsertFuelCardConsumo(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFuelCardConsumo(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistFuelCardConsumo2(idtransazione, numerofuelcard, datatransazione, importo);
            return retVal;
        }
        public bool ExistFuelCardConsumo3(string numerofuelcard, DateTime datatransazione, decimal importo)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistFuelCardConsumo3(numerofuelcard, datatransazione, importo);
            return retVal;
        }
        public ICron ExistCodjatoAuto(string marca, string modello, string serie)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ExistCodjatoAuto(marca, modello, serie);
            return data;
        }
        public int InsertFringeBenefit(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFringeBenefit(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistFattura(codfornitore, numerodocumento, datadocumento);
            return retVal;
        }
        public int InsertFattureXML(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFattureXML(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertFattureXMLDettaglio(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFattureXMLDettaglio(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron UltimoUidFattura()
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.UltimoUidFattura();
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectUsersDimissionariAttivi()
        {
            return OdsCron.DefaultProvider.SelectUsersDimissionariAttivi();
        }
        public int UpdateEmail(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateEmail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateUserNameMembership(NewUsername, LoweredNewUsername, OldUsername) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateUserNameMembership2(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateUserNameMembership2(NewUsername, LoweredNewUsername, OldUsername) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron ExistAnagraficaEmail(string email)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ExistAnagraficaEmail(email);
            return data;
        }
        public int UpdateAccountCount(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal;
            retVal = servizioCron.UpdateAccountCount(value);
            return retVal;
        }
        public int InsertAccount(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertAccount(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron ExistAnagraficaMatricola(string matricola)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ExistAnagraficaMatricola(matricola);
            return data;
        }
        public int InsertConcur(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertConcur(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertTelePassConsumo(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertTelePassConsumo(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistTelepassConsumo(numerodispositivo, dataora);
            return retVal;
        }
        public ICron ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ReturnTargaAssegnazioneXConcur(UserId, dataspesa);
            return data;
        }
        public ICron UltimoIDProg()
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.UltimoIDProg();
            return data;
        }
        public ICron DetailSocieta(string codcompany)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailSocieta(codcompany);
            return data;
        }
        public ICron ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ReturnCodCarPolicy(codsocieta, gradecode);
            return data;
        }
        public ICron DetailIdUser(Guid UserId)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailIdUser(UserId);
            return data;
        }
        public ICron CredNetwork()
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.CredNetwork();
            return data;
        }
        public ICron UltimoIDProgImp()
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.UltimoIDProgImp();
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectAutoImmatricolazione()
        {
            return OdsCron.DefaultProvider.SelectAutoImmatricolazione();
        }
        public int InsertRevisione(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertRevisione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectRevisioniDaEffettuare()
        {
            return OdsCron.DefaultProvider.SelectRevisioniDaEffettuare();
        }
        public bool ExistRevisione(string targa, int mese, int anno)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistRevisione(targa, mese, anno);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectAllUserEmail()
        {
            return OdsCron.DefaultProvider.SelectAllUserEmail();
        }
        public string InsTextEmail(string testomail, string nome, string cognome, string matricola, string codsocieta, string codgrade, string param1, string param2, string param3, string param4,
           string param5, string param6, string param7, string param8, string param9, string param10)
        {
            string retVal;

            testomail = testomail.Replace("[nome]", nome);
            testomail = testomail.Replace("[cognome]", cognome);
            testomail = testomail.Replace("[matricola]", matricola);
            testomail = testomail.Replace("[codsocieta]", codsocieta);
            testomail = testomail.Replace("[codgrade]", codgrade);
            testomail = testomail.Replace("[param1]", param1);
            testomail = testomail.Replace("[param2]", param2);
            testomail = testomail.Replace("[param3]", param3);
            testomail = testomail.Replace("[param4]", param4);
            testomail = testomail.Replace("[param5]", param5);
            testomail = testomail.Replace("[param6]", param6);
            testomail = testomail.Replace("[param7]", param7);
            testomail = testomail.Replace("[param8]", param8);
            testomail = testomail.Replace("[param9]", param9);
            testomail = testomail.Replace("[param10]", param10);

            retVal = testomail;

            return retVal;
        }
        public int UpdateInvioMail(int idinvio, Guid Uidtenant)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.UpdateInvioMail(idinvio, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertInvioMail(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertInvioMail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron DetailNumeroFuelCardEnelX(string targa)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailNumeroFuelCardEnelX(targa);
            return data;
        }
        public int InsertFuelCard(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertFuelCard(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistFuelCard(int idcompagnia, string numerofuelcard)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistFuelCard(idcompagnia, numerofuelcard);
            return retVal;
        }
        public int UpdateFuelCardCount(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal;
            retVal = servizioCron.UpdateFuelCardCount(value);
            return retVal;
        }
        public ICron ReturnSocietaXSigla(string siglasocieta)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ReturnSocietaXSigla(siglasocieta);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcurTxt()
        {
            return OdsCron.DefaultProvider.SelectViewConcurTxt();
        }
        public bool ExistDataConcur()
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistDataConcur();
            return retVal;
        }
        public ICron DetailConcur900(string matricola)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.DetailConcur900(matricola);
            return data;
        }
        public int InsertConcur900(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal = 0;
            if (servizioCron.InsertConcur900(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcur900Txt()
        {
            return OdsCron.DefaultProvider.SelectViewConcur900Txt();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewMovisionAnagrafiche()
        {
            return OdsCron.DefaultProvider.SelectViewMovisionAnagrafiche();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewMovisionBenefit()
        {
            return OdsCron.DefaultProvider.SelectViewMovisionBenefit();
        }
        public int UpdateZucchetti(ICron value)
        {
            ICronProvider servizioCron = ServizioCron;
            int retVal;
            retVal = servizioCron.UpdateZucchetti(value);
            return retVal;
        }
        public bool ExistMatricola(string matricola, string codsocieta)
        {
            ICronProvider servizioCron = ServizioCron;
            bool retVal;
            retVal = servizioCron.ExistMatricola(matricola, codsocieta);
            return retVal;
        }
        public ICron ReturnCodSocieta(string codzucchetti)
        {
            ICronProvider servizioCron = ServizioCron;
            ICron data = servizioCron.ReturnCodSocieta(codzucchetti);
            return data;
        }
    }
}
