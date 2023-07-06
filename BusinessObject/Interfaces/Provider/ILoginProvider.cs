// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ILoginProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace BusinessObject
{
    public interface ILoginProvider
    {
        bool ExistUser(string emailuser);
        IAccount Detail(string emailuser);
        IAccount DetailId(Guid UserId);
        int UpdateDataInvioMail(IAccount value);
    }
}