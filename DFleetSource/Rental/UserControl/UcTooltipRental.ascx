<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTooltipRental.ascx.cs" Inherits="DFleet.Rental.UserControl.UcTooltipRental" %>


<div class="slimscrollright">
    <div class="rpanel-title"> Pannello utente <span><i class="icon-close right-side-toggler"></i></span> </div>
    <div class="r-panel-body">

        <ul  class="m-t-20">
            <li><b><asp:Label ID="lblnomeutente" runat="server" Text=""></asp:Label></b></li>
            <li> <a href="/Rental/Logout"  class="svg-icon-30L svg-icon-logout p-l-30">Log-out</a></li>

          
        </ul>
       
    </div>
</div>