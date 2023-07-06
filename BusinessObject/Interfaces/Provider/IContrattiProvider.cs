// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IContrattiProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IContrattiProvider : IOdsContratti
    {
        IContratti DetailContrattiId(Guid Uid);
        IContratti DetailOrdiniId(Guid Uid);
        IContratti ReturnContrattoUser(DateTime datainfrazione, string targa);
        bool ExistUserCarPolicyActive(int idutente);
        bool ExistUserCarPolicy(int idutente);
        IContratti ReturnIdApprovazione(int idutente);
        IContratti ReturnCodCarPolicy(string codsocieta, string gradecode);
        IContratti DetailUserCarPolicyId(Guid Uid);
        IContratti ReturnCodCarList(string codcarpolicy);
        IContratti ReturnUltimoIdOrdine();
        IContratti ReturnUltimoNumeroOrdine();
        IContratti DetailVeicoloAttualeDriver(Guid UserId);
        IContratti DetailVeicoloAttualePartner(Guid UserId);
        IContratti ReturnApprovatore(int idutente);
        IContratti ReturnUidCarPolicy(Guid UserId);
        IContratti ReturnUltimoNumeroOrdinePool();
        IContratti DetailOrdiniPoolId(Guid UserId);
        IContratti DetailContrattiId2(int idcontratto);
        IContratti ReturnUltimoIdContratto();
        IContratti ReturnUltimoIdDelega();
        IContratti DetailDocDelegaXId(Guid UserId, string targa);
        IContratti DetailContrattiAssId(int idcontratto, Guid UserId);
        IContratti DetailContrattiXUidordine(Guid Uidordine);
        IContratti ReturnUserIdAssPool(Guid Uidtenant);
        IContratti ReturnUserIdAssRitiro();
        IContratti ReturnUltimoIdZTL();
        IContratti DetailDocZTLXId(Guid UserId, string targa);
        IContratti DetailFattureId(Guid Uid);
        IContratti DetailFattureDetId(Guid Uid);
        bool ExistAssegnazioneContratto(Guid UserID, int idcontratto);
        IContratti SelectKmPercorsiAttuali(string targa);
        IContratti ExistOldUserCarPolicy(int idutente);
        bool ExistStoricoAuto(Guid UserID);
        IContratti DetailAssegnazioniContrattiXId(int idassegnazione);
        IContratti DetailDriverXCdc(string tipocentro, Guid Uid);
        IContratti DetailTemplateFattureId(int idtemplate);
        IContratti ReturnAssegnatoAlMaggiore(int idcontratto);
        IContratti DetailDelega(Guid Uid);
        IContratti ReturnFileAuto(int idassegnazione);
        IContratti DetailAutoSostId(Guid Uid);
        bool ExistTargaAss(string targa);
        bool ExistAssegnazione(Guid UserId, string codsocieta, DateTime assegnatodal, DateTime assegnatoal, string targa);
        IContratti ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa);
        IContratti ReturnModConv(Guid Uid);
        IContratti ReturnLuogoRestituzioneXTarga(string targa);
        IContratti ReturnTypeCarPolicy(int idutente);
        IContratti ReturnDatiBenefitCarPolicy(int idapprovazione);
        IContratti ReturnIdConf();
        IContratti DetailConfigurazionePartner(Guid Uid);
        IContratti DetailIdPenale(Guid Uid);
        IContratti ExistCarPolicyMobilita(string codcarpolicy);
        IContratti DetailRevisioniId(Guid Uid);
        bool ExistPrenotazioneAutoServizio(DateTime datadal, DateTime dataal, string targa);
        IContratti ReturnOrdineFirma(Guid Uidtenant);
        IContratti DetailAutoServizioId(int idassegnazione);
        IContratti DetailLibrettoAutoServizioXTarga(string targa);
    }
}
