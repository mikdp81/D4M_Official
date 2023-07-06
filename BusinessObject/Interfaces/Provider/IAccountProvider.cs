// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IAccountProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IAccountProvider : IOdsAccount
    {
        IAccount GetAccountFromFormIdentity();
        IAccount Detail(string emailuser);
        IAccount DetailId(Guid UserId);
        IAccount DetailGruppoUserId(Guid UserId);
        IAccount DetailId2(int iduser);
        bool ExistUser(string emailuser);
        bool ExistUserStatus(string emailuser);
        IAccount UltimoIDUser();
        IAccount DetailTeamId(Guid Uid);
        IAccount DetailTeamXId(int idteam);
        IAccount UltimoIDTeam();
        IAccount ReturnIdteam(Guid UserId, Guid Uidtenant);
        bool ExistPageUser(Guid UserId, int idteam, int idpagina);
        IAccount DetailFuelCardUserId(Guid Uid);
        IAccount DetailTelePassUserId(Guid Uid);
        bool ExistLogin(Guid iduser);
        IAccount ExistAnagraficaMatricola(string matricola);
        IAccount ReturnPlafond(Guid UserId);
        IAccount ReturnPropertyTenant(Guid Uidtenant);
    }
}
