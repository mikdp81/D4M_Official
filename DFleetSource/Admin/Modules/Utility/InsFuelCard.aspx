<%@ Page Title="Inserimento Fuel Card" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsFuelCard.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.InsFuelCard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Fuel Card</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewFuelCard")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Codice Fuel Card *</label>
                                <asp:TextBox ID="txtCodice" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codice Fuel Card"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Fuel Card *</label>
                                <asp:TextBox ID="txtFuelCard" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Fuel Card"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Valore Fuel Card *</label>
                                <asp:TextBox ID="txtValoreFuelCard" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Valore Fuel Card" TextMode="Number"></asp:TextBox> 
                            </div>
                        </div>  
                    </div>  
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva e nuovo" CssClass="btn btn-success" /> 
                    <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva e chiudi" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>