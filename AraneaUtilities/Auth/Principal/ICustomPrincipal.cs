// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICustomPrincipal.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AraneaUtilities.Auth
{
    public interface ICustomPrincipal
    {
        IPrincipal Principal { get; }
        IIdentity Identity { get; }

        bool Start(bool toSession);

        bool SetInstanceToSession();

        bool IsAuthenticated();

        bool IsInRole(string role);

        bool Activate();

    }
}
