<%@ Page Title="Modifica Assegnazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModAssegnazioni.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.ModAssegnazioni" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Assegnazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/Assegnazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Driver</label>
                                <asp:DropDownList ID="ddlUserAss" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
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
                                <label for="message-text" class="control-label">Data inizio assegnazione</label>
                                <asp:TextBox ID="txtDataInizioAssegnazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio assegnazione"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="message-text" class="control-label">Data fine assegnazione</label>
                                <asp:TextBox ID="txtDataFineAssegnazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine assegnazione"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-action">                    
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div>

            </div>
        </div>
    </div>
</div>


</asp:Content>
