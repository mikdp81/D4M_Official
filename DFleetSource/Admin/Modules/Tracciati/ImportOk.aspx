<%@ Page Title="Carica Tracciati" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ImportOk.aspx.cs" Inherits="DFleet.Admin.Modules.Tracciati.ImportOk" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Carica Tracciati</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-success">
                    Files Caricati Correttamente. <br /><a href="Carica" style="color:#fff;">Vuoi caricare un'altro file?</a>
                </asp:Panel>
            </div>
        </div>
    </div>

</div>

</asp:Content>