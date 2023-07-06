﻿<%@ Page Title="Cancella Categorie Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DelCategorieOptional.aspx.cs" Inherits="DFleet.Admin.Modules.Car.DelCategorieOptional" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Cancella Categorie Optional</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/ViewCategorieOptional")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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