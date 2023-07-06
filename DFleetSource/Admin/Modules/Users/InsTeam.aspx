<%@ Page Title="Inserimento Team" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsTeam.aspx.cs" Inherits="DFleet.Admin.Modules.Users.InsTeam" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Team</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewTeam")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Status *</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Seleziona</asp:ListItem>
                                    <asp:ListItem Value="ATTIVO">ATTIVO</asp:ListItem>
                                    <asp:ListItem Value="SOSPESO">SOSPESO</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Team *</label>      
                                <asp:TextBox ID="txtTeam" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Utenti </label>
                                <asp:ListBox ID="ddlUtenti" CssClass="select2 select2-multiple" SelectionMode="Multiple" multiple="multiple"
                                    runat="server" DataSourceID="odsusers"  DataTextField="cognome" DataValueField="iduser" AppendDataBoundItems="True">
                                </asp:ListBox>      
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsersSearch" TypeName="BusinessLogic.AccountBL">
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Attivit&agrave; </label>      
                                <asp:ListBox ID="ddlAttivit" CssClass="select2 select2-multiple" SelectionMode="Multiple" multiple="multiple"
                                    runat="server" DataSourceID="odsattivita"  DataTextField="pagina" DataValueField="idpagina" AppendDataBoundItems="True">
                                </asp:ListBox>  
                                <asp:ObjectDataSource ID="odsattivita" runat="server" SelectMethod="SelectAllAttivita" TypeName="BusinessLogic.UtilitysBL">
                                </asp:ObjectDataSource>
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