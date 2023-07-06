<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DFleet.casillo.Default" %>

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

protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
{
    IAccountBL servizioAccount = new AccountBL();

    bool auth = servizioAccount.Authenticate(Login1.UserName, Login1.Password);

    string returnUrl = Request.QueryString["ReturnUrl"];

    if (auth)
    {
        returnUrl = "Authenticator";        
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
						<asp:Textbox id="Textbox1" runat="server" Visible="false" />
						<asp:Login ID="Login1" runat="server" DestinationPageUrl="modules/dash/dashboard.aspx" 
							onauthenticate="Login1_Authenticate" DisplayRememberMe="False" RenderOuterTable="false">
							<LayoutTemplate>            
								<div class="fv-plugins-icon-container ">
									<asp:TextBox ID="UserName" runat="server" placeholder="Email" CssClass="form-control form-control-solid h-auto py-5 px-6"></asp:TextBox>
									<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
									ControlToValidate="UserName" ErrorMessage="Email obbligatoria." 
									ToolTip="Email obbligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>							
								</div>
								<div class="fv-plugins-icon-container ">
									<asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Password"  CssClass="form-control form-control-solid h-auto py-5 px-6"></asp:TextBox>
									<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
										ControlToValidate="Password" ErrorMessage="Password obbligatoria." 
										ToolTip="Password obbligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
							
								</div>
								<div class="text-center">
									<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entra" CssClass="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light"
										ValidationGroup="Login1" /><br /><br />                                    
									<a href="RecuperaPwd" class="text-dark-50 text-hover-primary my-3 mr-2">Recupera Password?</a>
								</div>
							</LayoutTemplate>
						</asp:Login>
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