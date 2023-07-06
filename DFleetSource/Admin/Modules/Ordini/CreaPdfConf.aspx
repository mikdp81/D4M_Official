<%@ Page Title="Rigenera Pdf Configurazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="CreaPdfConf.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.CreaPdfConf" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Rigenera Pdf Configurazione</h3>
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