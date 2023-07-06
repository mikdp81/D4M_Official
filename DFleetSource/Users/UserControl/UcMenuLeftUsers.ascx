<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMenuLeftUsers.ascx.cs" Inherits="DFleet.Users.UserControl.UcMenuLeftUsers" %>


<div class="scroll-sidebar">
   
    <nav class="sidebar-nav">
        <ul id="side-menu">
            <li>
                <a href="<%=ResolveUrl("~/Users/Modules/Dash/Dashboard")%>" aria-expanded="false"><img src="../../../plugins/images/ico_dashboard.svg" class="icon20"/> <span class="hide-menu"> Dashboard </span></a>
            </li>            
            <asp:Literal ID="ltMenu" runat="server"></asp:Literal>            
        </ul>
    </nav>
</div>