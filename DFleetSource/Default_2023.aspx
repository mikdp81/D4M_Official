<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_2023.aspx.cs" Inherits="DFleet.Default_2023" %>
<%@ Import Namespace="System.Globalization" %>

<%@ Import Namespace="BusinessObject" %>
<%@ Import Namespace="BusinessLogic" %>
<%@ Import Namespace="System.Security.Permissions" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.Threading" %>

<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //https://localhost:44392/default_2023?email=system@d4m.it&password=Dfleet2021.&cron=generateconcur

            string email = SeoHelper.EncodeString(Request.QueryString["email"]);
            string password = SeoHelper.EncodeString(Request.QueryString["password"]);
            string cron = SeoHelper.EncodeString(Request.QueryString["cron"]);

            IAccountBL servizioAccount = new AccountBL();
            string returnUrl = "";

            bool auth = servizioAccount.Authenticate(email, password);

            if (auth)
            {
                if (Roles.IsUserInRole(email, Account.ROLE_SYSTEM))
                {
                    returnUrl = "Crons/" + cron + ".ashx";
                }
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                Response.Redirect(returnUrl);
            }
            else
            {
                Response.Redirect("Default");
            }
        }

        base.OnLoad(e);
    }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>D4M</title>
</head>


<body class="mini-sidebar">


<form id="form1" runat="server">



</form>

</body>
</html>