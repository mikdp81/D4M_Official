// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CCarBL.cs" company="">
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
    public class CarsBL : BaseBL, ICarsBL
    {

        public CarsBL() {
        }

        private ICarsProvider ServizioCar
        {
            get { return ProviderFactory.ServizioCar; }
        }

        public int UpdateCarListAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCarListAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        
        public int DeleteCarListAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteCarListAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        
        public int InsertCarListAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertCarListAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }       
        
        public ICars DetailCarListAutoId(Guid Uid)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCarListAutoId(Uid);
            return data;
        }
                
        public int SelectCountCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountCarListAuto( codcarlist,  codfornitore,  marca,  modello, Uidtenant);
            return retVal;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectCarListAuto( codcarlist,  codfornitore,  marca,  modello, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCarList(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllCarList(Uidtenant);
        }


        public int UpdateCarList(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCarList(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteCarList(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteCarList(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertCarList(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertCarList(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public ICars DetailCarListId(Guid Uid)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCarListId(Uid);
            return data;
        }

        public int SelectCountCarList(string keysearch, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountCarList(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarList(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectCarList(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        public int UpdateCarPolicy(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteCarPolicy(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertCarPolicy(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public ICars DetailCarPolicyId(Guid Uid)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCarPolicyId(Uid);
            return data;
        }

        public int SelectCountCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountCarPolicy(keysearch, codsocieta, codgrade, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectCarPolicy(keysearch, codsocieta, codgrade, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int UpdateCarPolicySocieta(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCarPolicySocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteCarPolicySocieta(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteCarPolicySocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertCarPolicySocieta(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertCarPolicySocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int UpdateCategorieOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCategorieOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteCategorieOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteCategorieOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertCategorieOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertCategorieOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public ICars DetailCategoriaOptionalId(Guid Uid)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCategoriaOptionalId(Uid);
            return data;
        }

        public int SelectCountCategoriaOptional(string keysearch, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountCategoriaOptional(keysearch, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectCategoriaOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectCategoriaOptional(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriaOptional()
        {
            return OdsCars.DefaultProvider.SelectAllCategoriaOptional();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriePrimoLivello2(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllCategoriePrimoLivello2(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategoriePrimoLivello(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllCategoriePrimoLivello(Uidtenant);
        }

        public int UpdateOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertOptional(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public ICars DetailOptionalId(Guid Uid)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailOptionalId(Uid);
            return data;
        }

        public int SelectCountOptional(string keysearch, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptional(keysearch, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectOptional(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptionalTerm(string keysearch, Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectOptionalTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategorieSecondoLivello(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllCategorieSecondoLivello(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCategorieSecondoLivelloXCod(string codcategoriaoptional)
        {
            return OdsCars.DefaultProvider.SelectAllCategorieSecondoLivelloXCod(codcategoriaoptional);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllOptionalXCod(string codcategoria, string codsottocategoria)
        {
            return OdsCars.DefaultProvider.SelectAllOptionalXCod(codcategoria, codsottocategoria);
        }
        public int DeleteOptionalAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteOptionalAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertOptionalAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.InsertOptionalAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICars ExistOptionalAuto(string codjatoauto, string codoptional)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.ExistOptionalAuto(codjatoauto, codoptional);
            return data;
        }
        public int SelectCountOptionalAuto(string codjatoauto)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptionalAuto(codjatoauto);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectOptionalAuto(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            return OdsCars.DefaultProvider.SelectOptionalAuto(codjatoauto, codcategoria, codsottocategoria);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllCarPolicy(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllCarPolicy(Uidtenant);
        }
        public bool ExistOrdineOptionalAuto(int idordine, string codoptional)
        {
            ICarsProvider servizioCar = ServizioCar;
            bool retVal;
            retVal = servizioCar.ExistOrdineOptionalAuto(idordine, codoptional);
            return retVal;
        }
        public ICars DetailCarListAutoXCodjato(string codjatoauto, string codcarlist)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCarListAutoXCodjato(codjatoauto, codcarlist);
            return data;
        }
        public bool ExistCarPolicy(string codcarpolicy)
        {
            ICarsProvider servizioCar = ServizioCar;
            bool retVal;
            retVal = servizioCar.ExistCarPolicy(codcarpolicy);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllColori(string codjatoauto, Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllColori(codjatoauto, Uidtenant);
        }
        public bool ExistCodCarList(string codcarlist)
        {
            ICarsProvider servizioCar = ServizioCar;
            bool retVal;
            retVal = servizioCar.ExistCodCarList(codcarlist);
            return retVal;
        }
        public bool ExistCodOptional(string codoptional)
        {
            ICarsProvider servizioCar = ServizioCar;
            bool retVal;
            retVal = servizioCar.ExistCodOptional(codoptional);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllAuto(Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectAllAuto(Uidtenant);
        }
        public int SelectCountOptionalAutoCat(string codjatoauto, string codcategoria)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptionalAutoCat(codjatoauto, codcategoria);
            return retVal;
        }
        public int SelectCountOptionalAutoSottoCat(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptionalAutoSottoCat(codjatoauto,  codcategoria, codsottocategoria);
            return retVal;
        }
        public int SelectCountOptionalAutoCatDiSerie(string codjatoauto, string codcategoria)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptionalAutoCatDiSerie(codjatoauto, codcategoria);
            return retVal;
        }
        public int SelectCountOptionalAutoSottoCatDiSerie(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountOptionalAutoSottoCatDiSerie(codjatoauto, codcategoria, codsottocategoria);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsCars.DefaultProvider.SelectDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparc, Uidtenant, numrecord, pagina);
        }
        public int SelectCountDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparc, Uidtenant);
            return retVal;
        }
        public ICars DetailImportoOrdineOptionalAuto(int idordine, string codoptional)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailImportoOrdineOptionalAuto(idordine, codoptional);
            return data;
        }
        public int DeleteOptionalOrdine(int idordine, string codoptional, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteOptionalOrdine(idordine, codoptional, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectAllOptionalAuto(string codjatoauto)
        {
            return OdsCars.DefaultProvider.SelectAllOptionalAuto(codjatoauto);
        }
        public ICars DetailOptionalXCod(string codoptional)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailOptionalXCod(codoptional);
            return data;
        }
        public ICars DetailCarListAutoId2(string codjatoauto, string codcarlist, string codfornitore)
        {
            ICarsProvider servizioCar = ServizioCar;
            ICars data = servizioCar.DetailCarListAutoId2(codjatoauto, codcarlist, codfornitore);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICars> SelectViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            return OdsCars.DefaultProvider.SelectViewCarList(codsocieta, codcarlist, Uidtenant);
        }
        public int SelectCountViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal;
            retVal = servizioCar.SelectCountViewCarList(codsocieta, codcarlist, Uidtenant);
            return retVal;
        }
        public int UpdateCarListContrattoAuto(ICars value)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.UpdateCarListContrattoAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteOptionalAuto(Guid Uid, Guid Uidtenant)
        {
            ICarsProvider servizioCar = ServizioCar;
            int retVal = 0;
            if (servizioCar.DeleteOptionalAuto(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

    }
}
