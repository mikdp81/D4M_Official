<%@ Page Title="Nuova Voltura" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsVolturaOk.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsVolturaOk" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Nuova Voltura</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-success">
                    Voltura inserita correttamente. <br /><a href="InsVoltura" style="color:#fff;">Vuoi inserire un'altra voltura?</a>
                </asp:Panel>
            </div>
        </div>
    </div>

</div>

</asp:Content>