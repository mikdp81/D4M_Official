// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSCar.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using BusinessProvider;
using BusinessObject;
using DataProvider;

namespace BusinessProvider
{
    [DataObject(true)]

    public class OdsCars : ODSProvider<CarsProvider>, IOdsCars
    {
        private readonly CarsProvider carsProvider = (CarsProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarListAuto(ICars value)
        {
            return carsProvider.UpdateCarListAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCarListAuto(ICars value)
        {
            return carsProvider.DeleteCarListAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCarListAuto(ICars value)
        {
            return carsProvider.InsertCarListAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return carsProvider.SelectCarListAuto(codcarlist, codfornitore, marca, modello, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant)
        {
            return carsProvider.SelectCountCarListAuto(codcarlist, codfornitore, marca, modello, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCarList(Guid Uidtenant)
        {
            return carsProvider.SelectAllCarList(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarList(ICars value)
        {
            return carsProvider.UpdateCarList(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCarList(ICars value)
        {
            return carsProvider.DeleteCarList(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCarList(ICars value)
        {
            return carsProvider.InsertCarList(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarList(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return carsProvider.SelectCarList(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarList(string keysearch, Guid Uidtenant)
        {
            return carsProvider.SelectCountCarList(keysearch, Uidtenant);
        }




        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarPolicy(ICars value)
        {
            return carsProvider.UpdateCarPolicy(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCarPolicy(ICars value)
        {
            return carsProvider.DeleteCarPolicy(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCarPolicy(ICars value)
        {
            return carsProvider.InsertCarPolicy(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return carsProvider.SelectCarPolicy(keysearch, codsocieta, codgrade, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant)
        {
            return carsProvider.SelectCountCarPolicy(keysearch, codsocieta, codgrade, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarPolicySocieta(ICars value)
        {
            return carsProvider.UpdateCarPolicySocieta(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCarPolicySocieta(ICars value)
        {
            return carsProvider.DeleteCarPolicySocieta(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCarPolicySocieta(ICars value)
        {
            return carsProvider.InsertCarPolicySocieta(value);
        }


        public int UpdateCategorieOptional(ICars value)
        {
            return carsProvider.UpdateCategorieOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCategorieOptional(ICars value)
        {
            return carsProvider.DeleteCategorieOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCategorieOptional(ICars value)
        {
            return carsProvider.InsertCategorieOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCategoriaOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return carsProvider.SelectCategoriaOptional(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCategoriaOptional(string keysearch, Guid Uidtenant)
        {
            return carsProvider.SelectCountCategoriaOptional(keysearch, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriaOptional()
        {
            return carsProvider.SelectAllCategoriaOptional();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriePrimoLivello2(Guid Uidtenant)
        {
            return carsProvider.SelectAllCategoriePrimoLivello2(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriePrimoLivello(Guid Uidtenant)
        {
            return carsProvider.SelectAllCategoriePrimoLivello(Uidtenant);
        }

        public int UpdateOptional(ICars value)
        {
            return carsProvider.UpdateOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteOptional(ICars value)
        {
            return carsProvider.DeleteOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertOptional(ICars value)
        {
            return carsProvider.InsertOptional(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return carsProvider.SelectOptional(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptionalTerm(string keysearch, Guid Uidtenant)
        {
            return carsProvider.SelectOptionalTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptional(string keysearch, Guid Uidtenant)
        {
            return carsProvider.SelectCountOptional(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategorieSecondoLivello(Guid Uidtenant)
        {
            return carsProvider.SelectAllCategorieSecondoLivello(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategorieSecondoLivelloXCod(string codcategoriaoptional)
        {
            return carsProvider.SelectAllCategorieSecondoLivelloXCod(codcategoriaoptional);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllOptionalXCod(string codcategoria, string codsottocategoria)
        {
            return carsProvider.SelectAllOptionalXCod(codcategoria, codsottocategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteOptionalAuto(ICars value)
        {
            return carsProvider.DeleteOptionalAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertOptionalAuto(ICars value)
        {
            return carsProvider.InsertOptionalAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptionalAuto(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            return carsProvider.SelectOptionalAuto(codjatoauto, codcategoria, codsottocategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptionalAuto(string codjatoauto)
        {
            return carsProvider.SelectCountOptionalAuto(codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptionalAutoCat(string codjatoauto, string codcategoria)
        {
            return carsProvider.SelectCountOptionalAutoCat(codjatoauto, codcategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptionalAutoSottoCat(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            return carsProvider.SelectCountOptionalAutoSottoCat(codjatoauto, codcategoria, codsottocategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptionalAutoCatDiSerie(string codjatoauto, string codcategoria)
        {
            return carsProvider.SelectCountOptionalAutoCatDiSerie(codjatoauto, codcategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOptionalAutoSottoCatDiSerie(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            return carsProvider.SelectCountOptionalAutoSottoCatDiSerie(codjatoauto, codcategoria, codsottocategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCarPolicy(Guid Uidtenant)
        {
            return carsProvider.SelectAllCarPolicy(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllColori(string codjatoauto, Guid Uidtenant)
        {
            return carsProvider.SelectAllColori(codjatoauto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllAuto(Guid Uidtenant)
        {
            return carsProvider.SelectAllAuto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant, int numrecord, int pagina)
        {
            return carsProvider.SelectDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparc, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant)
        {
            return carsProvider.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparc, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteOptionalOrdine(int idordine, string codoptional, Guid Uidtenant)
        {
            return carsProvider.DeleteOptionalOrdine(idordine, codoptional, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllOptionalAuto(string codjatoauto)
        {
            return carsProvider.SelectAllOptionalAuto(codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            return carsProvider.SelectViewCarList(codsocieta, codcarlist, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            return carsProvider.SelectCountViewCarList(codsocieta, codcarlist, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarListContrattoAuto(ICars value)
        {
            return carsProvider.UpdateCarListContrattoAuto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteOptionalAuto(Guid Uid, Guid Uidtenant)
        {
            return carsProvider.DeleteOptionalAuto(Uid, Uidtenant);
        }

    }
}
