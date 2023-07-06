// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="recuperadatiuser.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.Security;
using AraneaUtilities.Auth.Roles;
using BusinessLogic;
using BusinessObject;

namespace DFleet.Classes
{
    public class Recuperadatiuser
    {
        public event EventHandler ErrorDataBound;
        public static string _stringEmpty = string.Empty;

#pragma warning disable IDE0052 // Remove unread private members
        private string _nomeuser = _stringEmpty;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private string _emailuser = _stringEmpty;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private string _tipouser = _stringEmpty;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private string _idteam = _stringEmpty;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private string _codfornitore = _stringEmpty;
#pragma warning restore IDE0052 // Remove unread private members

        public string Nomeuser
        {
            get { return ReturnNomeUser(); }
            set { _nomeuser = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; }
        }
        public int Flgadmin
        {
            get { return ReturnFlgAdmin(); }
            set { }
        }
        public string Emailuser
        {
            get { return ReturnEmailUser(); }
            set { _emailuser = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; }
        }
        public string Tipouser
        {
            get { return ReturnTipoUser(); }
            set { _tipouser = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; }
        }
        public string Idteam
        {
            get { return ReturnIdteamUser(); }
            set { _idteam = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; }
        }
        public string Codfornitore
        {
            get { return ReturnCodFornitoreRental(); }
            set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; }
        }
        public int Flgdriver
        {
            get { return ReturnFlgDriver(); }
            set { }
        }
        public int Autorizzatore
        {
            get { return ReturnAutorizzatore(); }
            set { }
        }

        public bool ReturnExistPage(int idpagina)
        {
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            string tmpidteam;
            int idteam;
            if (HttpContext.Current.Session["IdTeam"] != null)
            {
                tmpidteam = HttpContext.Current.Session["IdTeam"].ToString();
            }
            else
            {
                //crea sessione idteam                
                HttpContext.Current.Session["IdTeam"] = Idteam;
                tmpidteam = HttpContext.Current.Session["IdTeam"].ToString();
            }
            idteam = SeoHelper.IntString(tmpidteam);

            return servizioAccount.ExistPageUser(UserId, idteam, idpagina);
        }

        public string ReturnIdteamUser()
        {
            string retVal = _stringEmpty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.ReturnIdteam(iduser, Uidtenant);
            if (data != null)
            {
                retVal = data.Idteam.ToString();
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;
        }

        public string ReturnNomeUser()
        {
            string retVal = _stringEmpty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;   

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                retVal = data.Nome + " " + data.Cognome;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;
        
        }


        public int ReturnFlgAdmin()
        {
            int retVal = 0;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                bool isAdmin = Roles.IsUserInRole(data.Email, DFleetGlobals.UserRoles.Admin);
                if (isAdmin)
                {
                    retVal = 1;
                }
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;
            
        }

        public int ReturnFlgDriver()
        {
            int retVal = 0;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                retVal = data.Flgdriver;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public string ReturnEmailUser()
        {
            string retVal = _stringEmpty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                retVal = data.Email;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public string ReturnTipoUser()
        {
            string retVal = _stringEmpty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailGruppoUserId(iduser);
            if (data != null)
            {
                retVal = data.Gruppouser;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public string ReturnCodFornitoreRental()
        {
            string retVal = _stringEmpty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                retVal = data.Codfornitore;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public int ReturnAutorizzatore()
        {
            int retVal = 0;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            string tmpidteam;
            int idteam;
            if (HttpContext.Current.Session["IdTeam"] != null)
            {
                tmpidteam = HttpContext.Current.Session["IdTeam"].ToString();
            }
            else
            {
                //crea sessione idteam                
                HttpContext.Current.Session["IdTeam"] = Idteam;
                tmpidteam = HttpContext.Current.Session["IdTeam"].ToString();
            }
            idteam = SeoHelper.IntString(tmpidteam);


            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailTeamXId(idteam);
            if (data != null)
            {
                retVal = data.Autorizzatore;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public Guid ReturnUidTenant()
        {
            Guid retVal = Guid.Empty;
            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                retVal = data.Uidtenant;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
        public string ReturnObjectTenant()
        {
            string retVal = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.ReturnPropertyTenant(Uidtenant);
            if (data != null)
            {
                retVal = data.Oggettomail;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }

            return retVal;

        }
    }
}
