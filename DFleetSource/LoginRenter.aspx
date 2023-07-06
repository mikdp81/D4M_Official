<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRenter.aspx.cs" Inherits="DFleet.LoginRenter" %>
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
            string htmlBody = "<!doctype><html><head><title>D4M - Reset Password </title><body> " +
            "<div style='font-size:14px;'>" +
            "Gentile utente, <br />" +
            "per la modifica della password clicca sul seguente pulsante: <br />" +
            "Attenzione: il link ha durata di 24 ore <br /><br />" +
            "<a href='https://" + HttpContext.Current.Request.Url.Host + "/ResetPassword-" + UserId + "' style='text-decoration:none; color:#ffffff; background-color:#86bc25; font-size:16px; padding:5px 20px 5px 20px;'>Reset Password</a><br /><br />" +
            "In caso di problemi copiare l'indirizzo di seguito in una nuova finestra del browser:<br /> <br />" +
            "<a href='https://" + HttpContext.Current.Request.Url.Host + "/ResetPassword-" + UserId + "'>https://" + HttpContext.Current.Request.Url.Host + "/ResetPassword-" + UserId + "</a><br />" +
            "La presente e-mail e' stata generata automaticamente si chiede pertanto di non rispondere al messaggio.</div>" +
            "</body></html>";

            bool result = MailHelper.SendMail("", Email.Text, "", "", "", "", "D4M - Richiesta Cambio Password", htmlBody, "", "D4M - ");

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

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        IAccountBL servizioAccount = new AccountBL();

        bool auth = servizioAccount.Authenticate(Login1.UserName, Login1.Password);

        string returnUrl = Request.QueryString["ReturnUrl"];

        if (auth)
        {
            returnUrl = "Authenticator";
        }
        else
        {
            returnUrl = "LoginRenter";
        }

        if (!string.IsNullOrEmpty(returnUrl))
        {
            Response.Redirect(returnUrl);
        }
        else
        {
            Response.Redirect("LoginRenter");
        }
    }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png" />
    <title>D4M</title>
    <!-- ===== Bootstrap CSS ===== -->
    <link href="bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- ===== Plugin CSS ===== -->
    <!-- ===== Animation CSS ===== -->
    <link href="css/animate.css" rel="stylesheet" />
    <!-- ===== Custom CSS ===== -->
    <link href="css/style.css" rel="stylesheet" />
    <!-- ===== Color CSS ===== -->
    <link href="css/colors/green-dark.css" id="theme" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>


<body class="mini-sidebar">


<form id="form1" runat="server">

    <!-- Preloader -->
    <div class="preloader">
        <div class="cssload-speeding-wheel"></div>
    </div>

    <section id="wrapper" class="login-register">
        <div class="login-box">
            <div class="white-box">
                <div class="form-horizontal form-material" id="loginform">
                    <h3 class="box-title m-b-20">LogIn</h3>

                    <asp:Panel runat="server" ID="pnlMessage" EnableViewState="false" Visible="false">
                        <asp:Literal runat="server" ID="lMessage" EnableViewState="false" />
                    </asp:Panel>
                    <asp:Textbox id="Textbox1" runat="server" Visible="false" />
                    <asp:Login ID="Login1" runat="server" DestinationPageUrl="modules/dash/dashboard.aspx" 
                        onauthenticate="Login1_Authenticate" DisplayRememberMe="False" RenderOuterTable="false">
                        <LayoutTemplate>            
                            <div class="form-group ">
                                <div class="col-xs-12">
							        <asp:TextBox ID="UserName" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="Email obbligatoria." 
                                    ToolTip="Email obbligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
						        </div>
                            </div>
                            <div class="form-group ">
                                <div class="col-xs-12">
								    <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Password"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password obbligatoria." 
                                        ToolTip="Password obbligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
							    </div>
                            </div>
                            <div class="form-group text-center m-t-20">
                                <div class="col-xs-12">
								    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entra" CssClass="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light"
                                        ValidationGroup="Login1" />
							    </div>
						    </div>
                            <a href="javascript:void(0)" id="to-recover" class="text-dark pull-right"><i class="fa fa-lock m-r-5"></i> Recupera password</a>
                        </LayoutTemplate>
                    </asp:Login>
                </div>



            
                <!-- RECUPERA PASSWORD -->      
                <div id="recoverform" class="form-horizontal"> 
                    <div class="form-group ">
                        <div class="col-xs-12">
                            <h3>Recupera Password</h3>
                            <p class="text-muted">Inserisci la mail </p>
                        </div>
                    </div>

                    <asp:Panel ID="pnlMessage2" runat="server">
                        <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                    </asp:Panel>
        
                    <div class="form-group">
                        <div class="col-xs-12">
                            <asp:TextBox ID="Email" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group text-center m-t-20">
                            <div class="col-xs-12">
                                <br /><asp:Button ID="btnRecuperaPwd" runat="server" Text="Invia" OnClick="btnRecuperaPwd_Click" CssClass="btn btn-primary btn-lg btn-block text-uppercase waves-effect waves-light" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section>

                     
</form>


    <!-- jQuery -->
    <script src="plugins/components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Menu Plugin JavaScript -->
    <script src="js/sidebarmenu.js"></script>
    <!--slimscroll JavaScript -->
    <script src="js/jquery.slimscroll.js"></script>
    <!--Wave Effects -->
    <script src="js/waves.js"></script>
    <!-- Custom Theme JavaScript -->
    <script src="js/custom.js"></script>

</body>
</html>