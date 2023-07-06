// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ILoginBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface ILoginBL
    {
        bool ExistUser(string emailuser);
        IAccount Detail(string emailuser);
        IAccount DetailId(Guid UserId);
        int UpdateDataInvioMail(IAccount value);
    }
}