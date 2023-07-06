<%@ Page Title="Documenti" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="Documenti.aspx.cs" Inherits="DFleet.Users.Modules.Dash.Documenti" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Documenti</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
              In questa sezione sono disponibili i documenti utili per muoverti nel mondo D4M.<br /><br />

                <asp:Literal ID="ltdati" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>


</asp:Content>
