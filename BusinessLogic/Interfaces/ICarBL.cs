// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICar.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface ICarsBL
    {
        int UpdateCarListAuto(ICars value);
        int DeleteCarListAuto(ICars value);
        int InsertCarListAuto(ICars value);
        ICars DetailCarListAutoId(Guid Uid);
        int SelectCountCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant);
        List<ICars> SelectCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        List<ICars> SelectAllCarList(Guid Uidtenant);
        int UpdateCarList(ICars value);
        int DeleteCarList(ICars value);
        int InsertCarList(ICars value);
        ICars DetailCarListId(Guid Uid);
        List<ICars> SelectCarList(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountCarList(string keysearch, Guid Uidtenant);
        int UpdateCarPolicy(ICars value);
        int DeleteCarPolicy(ICars value);
        int InsertCarPolicy(ICars value);
        ICars DetailCarPolicyId(Guid Uid);
        List<ICars> SelectCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant);
        int UpdateCarPolicySocieta(ICars value);
        int DeleteCarPolicySocieta(ICars value);
        int InsertCarPolicySocieta(ICars value);
        int UpdateCategorieOptional(ICars value);
        int DeleteCategorieOptional(ICars value);
        int InsertCategorieOptional(ICars value);
        ICars DetailCategoriaOptionalId(Guid Uid);
        List<ICars> SelectCategoriaOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountCategoriaOptional(string keysearch, Guid Uidtenant);
        List<ICars> SelectAllCategoriaOptional();
        List<ICars> SelectAllCategoriePrimoLivello2(Guid Uidtenant);
        List<ICars> SelectAllCategoriePrimoLivello(Guid Uidtenant); 
        int UpdateOptional(ICars value);
        int DeleteOptional(ICars value);
        int InsertOptional(ICars value);
        ICars DetailOptionalId(Guid Uid);
        List<ICars> SelectOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        List<ICars> SelectOptionalTerm(string keysearch, Guid Uidtenant);
        int SelectCountOptional(string keysearch, Guid Uidtenant);
        List<ICars> SelectAllCategorieSecondoLivello(Guid Uidtenant);
        List<ICars> SelectAllCategorieSecondoLivelloXCod(string codcategoriaoptional);
        List<ICars> SelectAllOptionalXCod(string codcategoria, string codsottocategoria);
        int DeleteOptionalAuto(ICars value);
        int InsertOptionalAuto(ICars value);
        ICars ExistOptionalAuto(string codjatoauto, string codoptional);
        List<ICars> SelectOptionalAuto(string codjatoauto, string codcategoria, string codsottocategoria);
        int SelectCountOptionalAuto(string codjatoauto);
        List<ICars> SelectAllCarPolicy(Guid Uidtenant);
        bool ExistOrdineOptionalAuto(int idordine, string codoptional);
        ICars DetailCarListAutoXCodjato(string codjatoauto, string codcarlist);
        bool ExistCarPolicy(string codcarpolicy);
        List<ICars> SelectAllColori(string codjatoauto, Guid Uidtenant);
        bool ExistCodCarList(string codcarlist);
        bool ExistCodOptional(string codoptional);
        List<ICars> SelectAllAuto(Guid Uidtenant);
        int SelectCountOptionalAutoCat(string codjatoauto, string codcategoria);
        int SelectCountOptionalAutoSottoCat(string codjatoauto, string codcategoria, string codsottocategoria);
        int SelectCountOptionalAutoCatDiSerie(string codjatoauto, string codcategoria);
        int SelectCountOptionalAutoSottoCatDiSerie(string codjatoauto, string codcategoria, string codsottocategoria);
        List<ICars> SelectDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant);
        ICars DetailImportoOrdineOptionalAuto(int idordine, string codoptional); 
        int DeleteOptionalOrdine(int idordine, string codoptional, Guid Uidtenant);
        List<ICars> SelectAllOptionalAuto(string codjatoauto);
        ICars DetailOptionalXCod(string codoptional);
        ICars DetailCarListAutoId2(string codjatoauto, string codcarlist, string codfornitore);
        List<ICars> SelectViewCarList(string codsocieta, string codcarlist, Guid Uidtenant);
        int SelectCountViewCarList(string codsocieta, string codcarlist, Guid Uidtenant);
        int UpdateCarListContrattoAuto(ICars value);
        int DeleteOptionalAuto(Guid Uid, Guid Uidtenant);
    }
}