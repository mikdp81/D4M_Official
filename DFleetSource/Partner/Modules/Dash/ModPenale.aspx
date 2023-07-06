<%@ Page Title="Modifica Penale" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="ModPenale.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.ModPenale" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Penale</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewPenali")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    
    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
                                
                <asp:Literal ID="ltdati" runat="server"></asp:Literal>    
                
                
                <br /><br /><a href="InsCom" class="btn btn-success">Apri Ticket</a>
            </div>
        </div>
    </div>
</div>


</asp:Content>