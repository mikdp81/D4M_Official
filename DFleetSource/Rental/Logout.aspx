<%@ Page Title="Logout" Language="C#" Inherits="System.Web.UI.Page" %>
<%@ Import Namespace="AraneaUtilities.Auth" %>
<%@ Import Namespace="DFleet" %>
<%@ Import Namespace="Microsoft.Owin.Security" %>
<%@ Import Namespace="Microsoft.Owin.Security.Cookies" %>
<%@ Import Namespace="Microsoft.Owin.Security.OpenIdConnect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        AuthManager.SignOut();
        HttpContext.Current.Session.Abandon();

        // clear authentication cookie
        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
        cookie1.Expires = DateTime.UtcNow.AddYears(-1);
        HttpContext.Current.Response.Cookies.Add(cookie1);
        // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
        HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        cookie2.Secure = true;
        cookie2.Expires = DateTime.UtcNow.AddYears(-1);
        HttpContext.Current.Response.Cookies.Add(cookie2);

        HttpContext.Current.GetOwinContext().Authentication.SignOut(
        new AuthenticationProperties { RedirectUri = "https://d4m.deloitte.it/SignOut.html" },
        OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        
        //Response.Redirect("../SignOut.html");
    }
</script>