<%@ Page Title="Modifica TelePass / ViaCard Driver" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModTelePassDriver.aspx.cs" Inherits="DFleet.Admin.Modules.Users.ModTelePassDriver" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica TelePass / ViaCard Driver</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewTelePassDriver")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                    <asp:ListItem Value="" Text="Stato"></asp:ListItem>
                                    <asp:ListItem Value="ATTIVA" Text="">ATTIVA</asp:ListItem>
                                    <asp:ListItem Value="BLOCCATA" Text="">BLOCCATA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Driver *</label>
                                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Targa *</label>
                                <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Targa"></asp:TextBox>   
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Numero *</label> 
                                <asp:TextBox ID="txtNumero" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Numero"></asp:TextBox> 
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
                                <label class="control-label">Tipo *</label> 
                                <asp:DropDownList ID="ddlCompagnie" runat="server" DataSourceID="odscompagnia" DataTextField="compagnia" 
                                    DataValueField="idcompagnia" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Tipo"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscompagnia" runat="server" SelectMethod="SelectCompagnieRoot" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>         
                        </div>
                    </div>
                </div>

                <div class="form-actions">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div>
            </div>

        </div>
    </div>
</div>


</asp:Content>