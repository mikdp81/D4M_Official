<%@ Page Title="Cartelle Movesion" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewMovision.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ViewMovision" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Cartelle Movesion</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/insMovision")%>" class="btn btn-info waves-effect waves-light m-t-10">Carica file</a> 
            </div>				
        </div>
    </div>

        
    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <h2>MOVESION</h2>
                <asp:Label runat="server" ID="lblContainer" Text=""></asp:Label>
                <h2>MOVESIONARCHIVIO</h2>
                <asp:Label runat="server" ID="lblContainer2" Text=""></asp:Label>
                <h2>MOVESIONPAYROLL</h2>
                <asp:Label runat="server" ID="lblContainer3" Text=""></asp:Label>
            </div>            
        </div>
    </div>
</div>


</asp:Content>