<%@ Page Title="Dati Personali" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="DatiPersonali.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.DatiPersonali" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Dati Personali</h3>
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
 
               </div>  
     </div>  
    </div>
</div>


</asp:Content>
