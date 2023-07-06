<%@ Page Title="Importazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DetailImport.aspx.cs" Inherits="DFleet.Admin.Modules.Tracciati.DetailImport" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Importazioni</h3>
            </div>		
            <div class="col-md-5 text-right">
                <a href="ViewImportazioni" class="btn btn-info">Indietro</a>
            </div>		
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</div>

</asp:Content>