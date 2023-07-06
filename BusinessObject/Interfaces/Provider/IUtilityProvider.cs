// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IUtilityProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IUtilitysProvider : IOdsUtilitys
    {
        IUtilitys DetailSocietaId(Guid Uid);
        IUtilitys DetailContiId(Guid Uid);
        IUtilitys DetailFornitoriId(Guid Uid);
        IUtilitys DetailFuelCardId(Guid Uid);
        IUtilitys DetailGradeId(Guid Uid);
        IUtilitys DetailPersonTypeId(Guid Uid);
        IUtilitys ReturnTemplateEmail(int idtemplate);
        IUtilitys DetailDocumentoId(Guid Uid);
        IUtilitys DetailReportId(int idreport);
        IUtilitys DetailTaskId(Guid Uid);
        IUtilitys ViewDashAdmin(Guid Uidtenant);
        IUtilitys ViewDashPEP(string codsocieta, Guid Uidtenant);
        IUtilitys ViewDashHR(string codsocieta, Guid Uidtenant);
        IUtilitys ViewDashFlotta(Guid Uidtenant);
        IUtilitys ViewDashPool(Guid Uidtenant);
        IUtilitys ViewDashDriver(Guid Uidtenant);
        IUtilitys ViewDashOrdini(Guid Uidtenant);
        IUtilitys DetailFornitoriCod(string codfornitore);
        IUtilitys DetailSocietaXPIVA(string partitaiva);
        IUtilitys DetailArgomentoFAQId(Guid Uid);
        IUtilitys DetailFAQId(Guid Uid);
        IUtilitys DetailFornitoriPIva(string partitaiva);
        IUtilitys DetailPenaleId(Guid Uid);
        IUtilitys DetailSocietaXCodS(string codsocieta);
        IUtilitys DetailAvvisoId(Guid Uid);
        IUtilitys ViewDashPartner(Guid Uidtenant);
        IUtilitys ReturnGradeXCod(string codgrade);
        IUtilitys DetailCentriId(Guid Uid);
        IUtilitys ViewDashRenter(Guid Uidtenant);
        IUtilitys ViewDashMulte(Guid Uidtenant);
        IUtilitys ViewDashContabilita(Guid Uidtenant);
    }
}
