<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperaPwd.aspx.cs" Inherits="DFleet.casillo.RecuperaPwd" %>

<%@ Import Namespace="System.Globalization" %>

<%@ Import Namespace="BusinessObject" %>
<%@ Import Namespace="BusinessLogic" %>
<%@ Import Namespace="System.Security.Permissions" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.Threading" %>

<script runat="server">
protected override void OnLoad(EventArgs e)
{
    pnlMessage.Visible = false;

    if (!Page.IsPostBack)
    {
        if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
        {
            pnlMessage.Visible = true;
            lMessage.Text = "<h2>Ops, non hai l'autorizzazione ad accedere alla risorsa richiesta!<br /><a href='" + Page.ResolveUrl("dashboard.aspx") + "'>Dashboard</a><br /><br /></h2>";
        }
    }

    base.OnLoad(e);
}


protected void btnRecuperaPwd_Click(object sender, EventArgs e)
{
    ILoginBL servizioLogin = new LoginBL();
    
    bool auth = servizioLogin.ExistUser(Email.Text);

    if (auth)
    {
        //recupero UserId Utente
        Guid UserId = Guid.Empty;
        Guid Uidtenant = Guid.Empty;
        IAccount dataUid = servizioLogin.Detail(Email.Text);
        if (dataUid != null)
        {
            UserId = dataUid.UserId;
            Uidtenant = dataUid.Uidtenant;
        }

        //invio mail
        string htmlBody = "<!doctype><html><head><title>Reset Password </title><body> " +
        "<div style='font-size:14px;'>" +
        "<strong>RICHIESTA CAMBIO PASSWORD</strong><br />" +
        "Gentile utente, <br />" +
        "per effettuare la creazione della password clicca sul seguente pulsante: <br />" +
        "Attenzione: il link ha durata di 1 ora <br /><br />" +
        "<a href='https://" + HttpContext.Current.Request.Url.Host + "/casillo/ResetPassword-" + UserId + "' style='text-decoration:none; color:#ffffff; background-color:#86bc25; font-size:16px; padding:5px 20px 5px 20px;'>Reset Password</a><br /><br />" +
        "In caso di problemi copiare l'indirizzo di seguito in una nuova finestra del browser:<br /> <br />" +
        "<a href='https://" + HttpContext.Current.Request.Url.Host + "/casillo/ResetPassword-" + UserId + "'>https://" + HttpContext.Current.Request.Url.Host + "/casillo/ResetPassword-" + UserId + "</a><br />" +
        "La presente e-mail e' stata generata automaticamente si chiede pertanto di non rispondere al messaggio.</div>" +
        "</body></html>";
            
        //Response.Redirect("RecuperaPasswordOK");            

        bool result = MailHelper.SendMail("", Email.Text, "", "", "", "", "Richiesta Cambio Password", htmlBody, "", "4M - Casillo - ");

        if (result)
        {
                
            IAccount UpdDataInvio = new Account();
            UpdDataInvio.UserId = UserId;
            UpdDataInvio.Uidtenant = Uidtenant;
            servizioLogin.UpdateDataInvioMail(UpdDataInvio);

            Response.Redirect("RecuperaPasswordOK");
        }
        else
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = "alert alert-danger";
            lMessage.Text += "Errore Invio Mail";
        }
    }
    else
    {
        /*pnlMessage.Visible = true;
        pnlMessage.CssClass = "alert alert-danger";
        lMessage.Text = "Attenzione. Si sono verificati i seguenti errori:";
        lMessage.Text += "<br /><br /><b>Email non corretta o non esistente</b><br />";*/
        Response.Redirect("RecuperaPasswordOK");
    }
}

</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" type="image/png" sizes="16x16" href="images/favicon.png" />
    <title>4M</title>
	<!--begin::Page Custom Styles(used by this page)-->
	<link href="css/login-1.css?v=7.2.9" rel="stylesheet" type="text/css"/>
	<!--end::Page Custom Styles-->

	<!--begin::Global Theme Styles(used by all pages)-->
	<link href="css/plugins.bundle.css?v=7.2.9" rel="stylesheet" type="text/css"/>
	<link href="css/prismjs.bundle.css?v=7.2.9" rel="stylesheet" type="text/css"/>
	<link href="css/style.bundle.css?v=7.2.9" rel="stylesheet" type="text/css"/>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>


 <body class="header-fixed header-mobile-fixed subheader-enabled page-loading" id="kt_body">


<!-- Preloader -->
<div class="preloader">
	<div class="cssload-speeding-wheel"></div>
</div>

<div class="d-flex flex-column flex-root">
	<!--begin::Login-->
	<div class="login login-1 login-signin-on d-flex flex-column flex-lg-row flex-column-fluid">
		<!--begin::Aside-->
		<div class="login-aside d-flex flex-row-auto bgi-size-cover bgi-no-repeat p-10 p-lg-10">
			<!--begin: Aside Container-->
			<div class="d-flex flex-row-fluid flex-column justify-content-between">
				<!--begin: Aside content-->
				<div class="flex-column-fluid d-flex flex-column justify-content-center">
					<p class="font-weight-lighter text-white opacity-80">
						
					</p>
				</div>
				<!--end: Aside content-->

				<!--begin: Aside footer for desktop-->
				<div class="d-none flex-column-auto d-lg-flex justify-content-between mt-10">
					<div class="opacity-70 font-weight-bold	text-white">
						
					</div>
					<div class="d-flex">
					
					</div>
				</div>
				<!--end: Aside footer for desktop-->
			</div>
			<!--end: Aside Container-->
		</div>
		<!--begin::Aside-->
		
		<!--begin::Content-->
		<div class="d-flex flex-column flex-row-fluid position-relative p-7 overflow-hidden">
			<!--begin::Content body-->						
			<div class="d-flex flex-column-fluid flex-center mt-30 mt-lg-0">
				<!--begin::Signin-->
				<div class="login-form login-signin">
					<div class="text-center mb-15">
						<!--<img src="plugins/images/logo_casillo_group_blu.svg" width="250" alt="" border="0" />-->
						<!--<h3 class="font-size-h1 mt-10 colorgrey">LogIn</h3>-->
					</div>								

					<form id="form1" runat="server" class="form">
						<asp:Panel runat="server" ID="pnlMessage" EnableViewState="false" Visible="false">
							<asp:Literal runat="server" ID="lMessage" EnableViewState="false" />
						</asp:Panel>

                        <div class="text-center mb-10 mb-lg-20">
						    <h3 class="font-size-h1">Recupera Password ?</h3>
						    <p class="text-muted font-weight-bold">Inserici la email per resettare la password</p>

                            <asp:Panel ID="pnlMessage2" runat="server">
                                <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                            </asp:Panel>
					    </div>
					    <div class="form" id="kt_login_forgot_form">
						    <div class="form-group">
                                <asp:TextBox ID="Email" runat="server" placeholder="Email" CssClass="form-control form-control-solid h-auto py-5 px-6"></asp:TextBox>
						    </div>
						    <div class="form-group d-flex flex-wrap flex-center">
                                <asp:Button ID="btnRecuperaPwd" runat="server" Text="Invia" OnClick="btnRecuperaPwd_Click" CssClass="btn btn-primary font-weight-bold px-9 py-4 my-3 mx-4" />
						    </div>
					    </div>
					</form>
				</div>	
			</div>
			<div class="flex-column-auto d-lg-flex justify-content-between mt-10">
				<div class="opacity-70 font-weight-bold font10">
					<img src="images/logo4m_grigio.png" width="75" alt="" border="0" /><br />
					Cookie Policy | Privacy Policy | Terms & Conditions<br />
					&copy;2023. Il nome Deloitte si riferisce a una o più delle seguenti entità: Deloitte Touche Tohmatsu Limited, una società inglese a responsabilità limitata, e le member firm aderenti al suo network, ciascuna delle quali è un’entità giuridicamente separata e indipendente dalle altre. Si invita a leggere l’informativa completa relativa alla descrizione della struttura legale di Deloitte Touche Tohmatsu Limited e delle sue member firm sul sito www2.deloitte.com
				</div>
				<div class="d-flex">
				
				</div>
			</div>
		</div>
	</div>
</div>


<script>var HOST_URL = "/";</script>
<!--begin::Global Config(global config for global JS scripts)-->
<script>
	var KTAppSettings = {
    "breakpoints": {
        "sm": 576,
        "md": 768,
        "lg": 992,
        "xl": 1200,
        "xxl": 1200
    },
    "colors": {
        "theme": {
            "base": {
                "white": "#ffffff",
                "primary": "#0BB783",
                "secondary": "#E5EAEE",
                "success": "#1BC5BD",
                "info": "#8950FC",
                "warning": "#FFA800",
                "danger": "#F64E60",
                "light": "#F3F6F9",
                "dark": "#212121"
            },
            "light": {
                "white": "#ffffff",
                "primary": "#D7F9EF",
                "secondary": "#ECF0F3",
                "success": "#C9F7F5",
                "info": "#EEE5FF",
                "warning": "#FFF4DE",
                "danger": "#FFE2E5",
                "light": "#F3F6F9",
                "dark": "#D6D6E0"
            },
            "inverse": {
                "white": "#ffffff",
                "primary": "#ffffff",
                "secondary": "#212121",
                "success": "#ffffff",
                "info": "#ffffff",
                "warning": "#ffffff",
                "danger": "#ffffff",
                "light": "#464E5F",
                "dark": "#ffffff"
            }
        },
        "gray": {
            "gray-100": "#F3F6F9",
            "gray-200": "#ECF0F3",
            "gray-300": "#E5EAEE",
            "gray-400": "#D6D6E0",
            "gray-500": "#B5B5C3",
            "gray-600": "#80808F",
            "gray-700": "#464E5F",
            "gray-800": "#1B283F",
            "gray-900": "#212121"
        }
    },
    "font-family": "Poppins"
};
</script>
<!--end::Global Config-->
	
<!--begin::Global Theme Bundle(used by all pages)-->
<script src="js/plugins.bundle.js?v=7.2.9"></script>
<script src="js/prismjs.bundle.js?v=7.2.9"></script>
<script src="js/scripts.bundle.js?v=7.2.9"></script>
<!--end::Global Theme Bundle-->

<script>
$(document).ready(function(){
	var classCycle=['slidehp2','slidehp3','slidehp4','slidehp5'];

	var randomNumber = Math.floor(Math.random() * classCycle.length);
	var classToAdd = classCycle[randomNumber];
	
	$('.login-aside').addClass(classToAdd);

});
</script>

</body>
</html>