<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="DFleet.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>D4M</title>
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    
<link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png" />

<style type="text/css">

body {font-family:Roboto,sans-serif;color:#4d4d4d;margin: 0;}
.registration-body{height:auto;margin:0 25px;width:100%;}
.card{box-shadow:4px 4px 15px 0 rgba(0,0,0,.35);padding:16px;text-align:center;background-color:#f1f1f1;}
.p-col-12{width:100%;}
.center{margin:auto;}
.p-col-4{width:33.3333%;}
.row{margin:0 -5px;}
.column{padding:0 10px;}
input{font-size:14px;color:#666;background:#fdfdff !important;padding:.429em;border:1px solid #dadada;}
.button{margin:0;color:#fdfdff;background-color:#86bc25 !important;border:1px solid #86bc25;font-size:13px;width:100%;}
.p-col-8{width:66.6667%;}
</style>

</head>
<body>

<form runat="server">  

<div style="margin:0 25px;">
    <div style="margin:0; display:flex; flex-direction:column; height:100%;">
        <div class="p-col-12 registration-body" style="height:90vh !important;">
            <div class="p-col-4 center" style="margin-top:30px;">
                <div class="row">
                    <div class="column">
                        <div class="card">
                            <div style="text-align:center;"><asp:Image ID="Image1" runat="server" Width="200" /></div> <br />


                            <h2>Cambia password</h2>

                            <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
							    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
						    </asp:Panel>

                            <div style="margin-top:30px;">
                                <span style="font-size:12px; color:#d43f3a">La password deve essere lunga almeno 8 caratteri, contenere almeno un carattere minuscolo, maiuscolo, numerico e speciale(#?!@$%^&*-.)</span>
                            </div>                                
                            <div style="margin-top:10px;">
                                <div class="p-col-12">
                                    Nuova password:
                                </div>
                                <div class="p-col-12">
                                    <asp:TextBox ID="txtNuovaPassword" Columns="50" MaxLength="255" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div style="margin-top:10px;">
                                <div class="p-col-12">
                                    Verifica nuova password:
                                </div>
                                <div class="p-col-12">
                                    <asp:TextBox ID="txtRipetiNuovaPassword" Columns="50" MaxLength="255" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>                            
                            <div style="margin-top:5px;">
                                <div class="p-col-12">
                                    <asp:Button ID="btnInvia" runat="server" Text="Invia"  OnClick="btnInvia_Click" CssClass="button p-col-4" />
                                    <asp:label ID="Label2" runat="server" />
                                </div>
                            </div>                           
                            

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</form>

</body>
</html>