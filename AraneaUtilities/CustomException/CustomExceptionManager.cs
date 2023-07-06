// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CustomExceptionManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Permissions;
using System.Web.Configuration;

namespace AraneaUtilities.CustomException
{
    [Serializable]
    public abstract class CustomExceptionManager
    {
        [NonSerialized]
        private ICustomException customException;
        protected CustomExceptionManager()
        { }

        public string Execute(Exception e)
        { 

            //raccolta dati
            customException = CollectData(e);

            //salviamo i dati => metodo privato
            Store(customException);

            return Response();

        }

        //** raccogliere i dati di interesse di Exception in un oggetto che implementi ICustomException
        protected abstract ICustomException CollectData(Exception e);

        //** salva l'oggetto di ICustomException
        protected abstract void Store(ICustomException customException);

        //** restituisce la risposta utente dell'esito
        protected string Response()
        {
            return customException.Response();
        }

    }

}
