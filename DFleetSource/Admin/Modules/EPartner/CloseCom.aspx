<%@ Page Title="Chiudi Ticket" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="CloseCom.aspx.cs" Inherits="DFleet.Admin.Modules.EPartner.CloseCom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Chiudi Ticket</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/EPartner/ViewComunicazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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