using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using Google.Authenticator;
using DFleet.Classes;
using AraneaUtilities.Auth;


namespace DFleet
{
    public partial class ChangePartner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string returnUrl;

            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                IAccountBL servizioAccount = new AccountBL();

                IAccount data = servizioAccount.DetailId(uid);
                if (data != null)
                {                    
                    bool ok;
                    string sessionID = "U" + "idUtente" + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                    HttpContext.Current.Session["UIDsession"] = sessionID;

                    //autorizza gli accessi
                    ok = AuthManager.SignIn(sessionID, data.Email, false);

                    if (ok)
                    {
                        returnUrl = "Partner/Modules/Dash/Dashboard";
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("UnauthorizedAccess.html"));
                    }                    
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }        
    }
}
