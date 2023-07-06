<%@ Page Title="Scegli Benefit" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ConfermaBenefit.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ConfermaBenefit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Fai la tua scelta di mobilità</h3>
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
        <div class="text-center">   
            <div class="alert alert-warning">ATTENZIONE!!! Confermare la scelta del pacchetto. Questa operazione &egrave; irreversibile.</div>

            <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" Text="TORNA INDIETRO" CssClass="btn btn-primary font-18 " /> 
            <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="CONFERMA" CssClass="btn btn-primary font-18 " />  
        </div>
        
        <br /><br /><br /><br /><br />
     </div>


</div>


</asp:Content>