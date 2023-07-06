<%@ Page Title="Inserimento Fattura" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsFattura.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsFattura" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Fattura</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewFatture")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Tipo Documento *</label>
                                <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Tipo Documento"></asp:ListItem>
                                    <asp:ListItem Value="TD01" Text="">Fattura</asp:ListItem>
                                    <asp:ListItem Value="TD04" Text="">Nota Credito</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Divisa *</label>
                                <asp:DropDownList ID="ddlDivisa" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Divisa"></asp:ListItem>
                                    <asp:ListItem Value="EUR" Text="">EUR</asp:ListItem>
                                    <asp:ListItem Value="USD" Text="">USD</asp:ListItem>
                                    <asp:ListItem Value="GBP" Text="">GBP</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data Documento *</label>
                                <asp:TextBox ID="txtDataDoc" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Documento"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Numero Documento *</label>
                                <asp:TextBox ID="txtNumeroDoc" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Importo Totale *</label>
                                <asp:TextBox ID="txtImportoTotale" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo Totale"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Fornitore *</label>                                
                                <asp:DropDownList ID="ddlFornitore" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                    DataValueField="partitaiva" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Fornitore"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice Societ&agrave; *</label>
                                <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                    DataValueField="partitaiva" CssClass="form-control ddlSocieta" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Societa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odssocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL" >
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
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