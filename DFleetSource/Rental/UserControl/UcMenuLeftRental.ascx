<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMenuLeftRental.ascx.cs" Inherits="DFleet.Rental.UserControl.UcMenuLeftRental" %>


<div class="scroll-sidebar">
    <nav class="sidebar-nav">
        <ul id="side-menu">
            <li>
                <a href="<%=ResolveUrl("~/Rental/Modules/Dash/Dashboard")%>" aria-expanded="false"><img src="../../../plugins/images/ico_dashboard.svg" class="icon20"/> <span class="hide-menu"> Dashboard </span></a>
            </li>
            <li>
                <a class="waves-effect" href="javascript:void(0);" aria-expanded="false"><img src="../../../plugins/images/documentazione.svg" class="icon20"/> <span class="hide-menu"> Ordini</span></a>
                <ul aria-expanded="false" class="collapse">
                    <li><a href="<%=ResolveUrl("~/Rental/Modules/Ordini/ViewOrdini")%>"> Da evadere </a></li>
                    <li><a href="<%=ResolveUrl("~/Rental/Modules/Ordini/ViewOrdiniEvasi")%>"> Evasi </a></li>
                </ul>
            </li> 
            <li>
                <a href="<%=ResolveUrl("~/Rental/Modules/Dash/ViewComunicazioni")%>" aria-expanded="false"><i class="icon-bubble fa-fw text-white"></i> <span class="hide-menu"> Help Desk </span></a>
            </li> 
        </ul>
    </nav>
</div>