// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IMulteProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IMulteProvider : IOdsMulte
    {
        IMulte DetailMulteId(Guid Uid);
        IMulte UltimoIDMulta();
        IMulte ExistCedolino(int idmulta, int idtipologiacedolino);
        bool ExistVerbaleMulta(string numeroverbale, string targa);
    }
}
