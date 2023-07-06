// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DFleetExceptionManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AraneaUtilities;
using AraneaUtilities.CustomException;
using BusinessObject;
using BusinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.exceptions
{
    public class DFleetExceptionManager : CustomExceptionManager
    {
        protected override ICustomException CollectData(Exception e)
        {
            return new DFleetException(e);
        }

        protected override void Store(ICustomException customException)
        {
            //DFleetExceptionProvider dfleetExceptionProvider = (DFleetExceptionProvider)new ProviderFactory().ServizioDFleetException;
            //dfleetExceptionProvider.Insert((DFleetException)customException);
        }
    }
}
