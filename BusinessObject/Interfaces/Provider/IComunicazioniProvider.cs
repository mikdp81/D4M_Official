// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IComunicazioniProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IComunicazioniProvider : IOdsComunicazioni
    {
        IComunicazioni ReturnUidCom();
        IComunicazioni DetailAllegato(Guid UIDallegato);
        IComunicazioni DetailComunicazioni(Guid UIDcomunicazione);
        IComunicazioni SelectEmailMittente(Guid UIDcomunicazionePadre);
    }
}
