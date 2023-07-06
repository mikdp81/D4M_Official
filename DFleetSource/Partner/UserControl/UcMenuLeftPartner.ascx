<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMenuLeftPartner.ascx.cs" Inherits="DFleet.Partner.UserControl.UcMenuLeftPartner" %>


<div class="scroll-sidebar">
   
    <nav class="sidebar-nav">
        <ul id="side-menu">
            <li>
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/Dashboard")%>" aria-expanded="false"><img src="../../../plugins/images/ico_dashboard.svg" class="icon20"/> <span class="hide-menu" style="color:#fff;"> Dashboard </span></a>
            </li>
            <li>
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/DatiPersonali")%>" aria-expanded="false"><img src="../../../plugins/images/dati_personali.svg" class="icon20"/> <span class="hide-menu" style="color:#fff;"> Dati personali </span></a>
            </li>         
            <li>
                <a class="waves-effect" href="javascript:void(0);" aria-expanded="false"><img src="../../../plugins/images/documentazione.svg" class="icon20"/> <span class="hide-menu" style="color:#fff;"> Documentazione e FAQ</span></a>
                <ul aria-expanded="false" class="collapse">
                    <li><a href="<%=ResolveUrl("~/Partner/Modules/Dash/Documenti")%>" style="color:#fff;">Documentazione</a></li>
                    <li><a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewFaq")%>" style="color:#fff;">FAQ</a></li>
                </ul>
            </li>   
            <li>
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewComunicazioni")%>" aria-expanded="false"><i class="icon-bubble fa-fw text-white"></i> <span class="hide-menu" style="color:#fff;"> Help Desk </span></a>
            </li>  
            <li>
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewPenali")%>" aria-expanded="false"><img src='../../../plugins/images/auto_in_corso.svg' class='icon20'/> <span class="hide-menu" style="color:#fff;"> Penali </span></a>
            </li>    

            <!-- MENU AUTO IN CORSO (si visualizza solo se c'è un'auto in assegnazione nel periodo di validità) -->               
            <asp:Literal ID="ltAutoCorso" runat="server"></asp:Literal>           
            
            <!-- MENU STORICO AUTO (si visualizza solo se c'è stato almeno un contratto) -->
            <asp:Literal ID="ltStoricoAuto" runat="server"></asp:Literal>

            <!-- MENU ORDINI IN CORSO (si visualizza solo se c'è un'ordine in corso) -->
            <asp:Literal ID="ltOrdiniCorso" runat="server"></asp:Literal>
            
        </ul>
    </nav>
</div>