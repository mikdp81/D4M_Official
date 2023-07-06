// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IAccountAPI.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using BusinessObject;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IApiAccountBL
    {
        //Autenticazione
        string[] Authenticate(string emailuser, string password);


        //************************************************ ANAGRAFICA


        //Anagrafica Elenco
        List<IApiAccount> SelectUser(Guid Uidtenant, string codsocieta, string keysearch, int idstatususer, int idgruppouser, int pagina); // elenco di tutti gli utenti bloccati a 1000 a pagina


        //Anagrafica Dettaglio
        IApiAccount UserDetail(string emailuser); // dettaglio utente tramite mail

        //Anagrafica Update
        int UpdateUser(IApiAccount value);  // update utente tramite valori account


        //Anagrafica Insert
        int InsertUser(IApiAccount value);  // insert utente tramite valori account


        //Anagrafica Delete
        int DeleteUser(IApiAccount value); // da valutare se inserirlo nelle api




        //************************************************ TEAM


        //Team Elenco
        List<IApiAccount> SelectTeam(Guid Uidtenant, string keysearch, int pagina); // elenco di tutti i team bloccati a 1000 a pagina


        //Team Dettaglio
        IApiAccount TeamDetail(int idteam,Guid Uidtenant); // dettaglio team tramite idteam

        //Team Update
        int UpdateTeam(IApiAccount value);  // update team tramite valori account


        //Team Insert
        int InsertTeam(IApiAccount value);  // insert team tramite valori account


        //Team Delete
        int DeleteTeam(IApiAccount value); // da valutare se inserirlo nelle api



    }
}