// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICustomException.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace AraneaUtilities
{
    public interface ICustomException
    {        
        //** specificare la fonte per recuperare l'id utente che ha causato l'eccezione
        int UserID();

        //** messaggio di risposta al verificarsi dell'eccezione
        string Response();
    }
}
