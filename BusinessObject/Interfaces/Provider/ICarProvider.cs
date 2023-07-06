// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICarProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface ICarsProvider : IOdsCars
    {
        ICars DetailCarListAutoId(Guid Uid);
        ICars DetailCarListId(Guid Uid);
        ICars DetailCarPolicyId(Guid Uid);
        ICars DetailCategoriaOptionalId(Guid Uid);
        ICars DetailOptionalId(Guid Uid);
        ICars DetailOptionalXCod(string codoptional);
        ICars ExistOptionalAuto(string codjatoauto, string codoptional);
        bool ExistOrdineOptionalAuto(int idordine, string codoptional);
        ICars DetailCarListAutoXCodjato(string codjatoauto, string codcarlist);
        bool ExistCarPolicy(string codcarpolicy);
        bool ExistCodCarList(string codcarlist);
        bool ExistCodOptional(string codoptional);
        ICars DetailImportoOrdineOptionalAuto(int idordine, string codoptional);
        ICars DetailCarListAutoId2(string codjatoauto, string codcarlist, string codfornitore);
    }
}
