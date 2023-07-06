<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeaderRental.ascx.cs" Inherits="DFleet.Rental.UserControl.UcHeaderRental" %>


<div class="navbar-header">
    <a class="navbar-toggle font-20 hidden-sm hidden-md hidden-lg " href="javascript:void(0)" data-toggle="collapse" data-target=".navbar-collapse">
        <i class="fa fa-bars"></i>
    </a>
    <div class="top-left-part">
        <a href="javascript:void(0)" class="sidebartoggler font-20 waves-effect waves-light"><i class="icon-arrow-left-circle"></i></a>
    </div>
    <ul class="nav navbar-top-links navbar-left hidden-xs">
        <li>
            <a class="logo" href="<%=ResolveUrl("~/Rental/Modules/Dash/Dashboard")%>"><asp:Literal ID="ltLogo" runat="server"></asp:Literal></a>
        </li>
        <li>
            <div role="search" class="app-search hidden-xs">
                <i class="icon-magnifier"></i>
                <input type="text" placeholder="Cerca..." class="form-control">
            </div>
        </li> 
    </ul>
    <ul class="nav navbar-top-links navbar-right pull-right">        
        <li class="right-side-toggle">
           <a class="right-side-toggler b-r-0 font-20 svg-icon-50 svg-icon-user" href="javascript:void(0)"></a>
        </li>
    </ul>
</div>


<asp:HiddenField ID="hduseridteam" runat="server" />   