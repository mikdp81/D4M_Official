﻿<%@ Page Title="Rinuncia a configurazione" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="Rinuncia.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.Rinuncia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Rinuncia a configurazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Dash/Dashboard")%>" class="btn btn-info waves-effect waves-light m-t-10">Ritorna alla dashboard</a> 
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