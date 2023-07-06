// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="BaseBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using BusinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public abstract class BaseBL
    {
        private static ProviderFactory providerFactory;
        protected ProviderFactory ProviderFactory
        {
            get
            {   
                // se null: inizializzo il providerFactory 
                if (providerFactory == null)
                    providerFactory = new ProviderFactory();
                return providerFactory; }
        }

        private static ProviderFactoryCron providerFactoryCron;
        protected ProviderFactoryCron ProviderFactoryCron
        {
            get
            {
                // se null: inizializzo il providerFactoryCron
                if (providerFactoryCron == null)
                    providerFactoryCron = new ProviderFactoryCron();
                return providerFactoryCron;
            }
        }

        protected BaseBL()
        {
            // se non attivo: riattivo il Principal per l'autorizzazione
            // if(!CustomPrincipalManager.IsActive())
            //    CustomPrincipalManager.Resume();

         
        }

    }
}
