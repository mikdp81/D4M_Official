<%@ Page Title="Cancella Assegnazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DelAssegnazione.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.DelAssegnazione" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Cancella Assegnazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/Assegnazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                Targa<br />
                <h4><asp:Label ID="lblTarga" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
                <h4><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h4>
                Driver <br />
                <h4> <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label></h4>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                Sei sicuro di voler cancellare questa assegnazione? <br />

                <asp:Button ID="btnElimina" runat="server" Text="SI" OnClick="btnElimina_Click" OnClientClick="return confirm('Sei sicuro di voler cancellare questa assegnazione?');" />
            </div>            
        </div> 
    </div>
</div>

<asp:HiddenField ID="hdidass" runat="server" />

</asp:Content>