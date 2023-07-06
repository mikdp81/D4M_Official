<%@ Page Title="Inserimento Utente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsUserRobotFull.aspx.cs" Inherits="DFleet.Admin.Modules.Users.InsUserRobotFull" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
  
<asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Crea Nuovi Membership" CssClass="btn btn-success" /> 
 
    
<br /><br />
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


</asp:Content>
