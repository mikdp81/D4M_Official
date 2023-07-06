﻿<%@ Page Title="Inserimento Fuel Card Driver" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsFuelCardDriver.aspx.cs" Inherits="DFleet.Admin.Modules.Users.InsFuelCardDriver" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Fuel Card Driver</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewFuelCardDriver")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Status *</label> 
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Stato"></asp:ListItem>
                                    <asp:ListItem Value="ATTIVA" Text="">ATTIVA</asp:ListItem>
                                    <asp:ListItem Value="BLOCCATA" Text="">BLOCCATA</asp:ListItem>
                                    <asp:ListItem Value="INATTIVAZIONE" Text="">IN ATTIVAZIONE</asp:ListItem>
                                    <asp:ListItem Value="SCADUTA" Text="">SCADUTA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Compagnia *</label> 
                                <asp:DropDownList ID="ddlCompagnie" runat="server" DataSourceID="odscompagnia" DataTextField="compagnia" 
                                    DataValueField="idcompagnia" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="compagnia"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscompagnia" runat="server" SelectMethod="SelectCompagnie" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Targa *</label>
                                <asp:DropDownList ID="ddlTarga" runat="server" DataSourceID="odstarga" DataTextField="targa" 
                                    DataValueField="targa" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Targa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstarga" runat="server" SelectMethod="SelectAllTarghe" TypeName="BusinessLogic.MulteBL" >
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
                                    DataValueField="codsocieta" CssClass="form-control" AppendDataBoundItems="True">
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
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Numero *</label> 
                                <asp:TextBox ID="txtNumero" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Numero"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Attivazione *</label> 
                                <asp:TextBox ID="txtDataAttivazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Attivazione"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Scadenza *</label> 
                                <asp:TextBox ID="txtScadenza" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">PIN *</label> 
                                <asp:TextBox ID="txtPIN" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="PIN"></asp:TextBox> 
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