<%@ Page Title="Cancella Comunicazione" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="DelCom.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.DelCom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">D4M TICKETING</h3>
                <h5>Assistenza generale e supporto sulla gestione auto ed eventuali problematiche </h5>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewComunicazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div> 
    </div>
</div>


</asp:Content>