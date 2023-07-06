<%@ Page Title="Dettagli Ritiro Auto" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DetailRitiroAuto.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.DetailRitiroAuto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Dettagli Ritiro Auto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/ViewRitiroAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Label ID="lblAuto" runat="server" CssClass="font-bold" Text="" /><br />                
                <asp:Label ID="lblDatiAuto" runat="server" Text="" /><br /><br />
                     
                <asp:Label ID="lblDatiOrdine" runat="server" Text="" /><br />
                <asp:Label ID="lblViewFileRifiuto" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblViewFileVerbale" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblViewFileLibretto" runat="server" Text=""></asp:Label>


            </div>
        </div>
    </div>
</div>


</asp:Content>