<%@ Page Title="Modifica Ordine" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.ModOrdini" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Ordine</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Codice Societ&agrave; *</label>
                                <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                    DataValueField="codsocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Societa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odssocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL" >
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Utente *</label>
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
                                <label class="control-label">Codjato Auto *</label>
                                <asp:TextBox ID="txtCodjatoAuto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codjato Auto"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice Car Policy</label>
                                <asp:TextBox ID="txtCodcarpolicy" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codice Car Policy"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>  
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice Car List</label>
                                <asp:TextBox ID="txtCodcarlist" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codice Car List"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice Fornitore *</label>                                
                                <asp:DropDownList ID="ddlFornitore" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                    DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
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
                                <label class="control-label">Numero Ordine *</label>
                                <asp:TextBox ID="txtNumeroOrdine" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine"></asp:TextBox> 
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data Ordine</label>
                                <asp:TextBox ID="txtDataOrdine" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Ordine"></asp:TextBox> 
                            </div>
                        </div>  
                    </div>   
                    <div class="row">   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data prima consegna prevista</label>
                                <asp:TextBox ID="txtDataprimaconsegnaprevista" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data prima consegna prevista"></asp:TextBox> 
                            </div>
                        </div>    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data consegna prevista</label>
                                <asp:TextBox ID="txtDataconsegnaprevista" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data consegna prevista"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data consegna prevista update</label>
                                <asp:TextBox ID="txtDataconsegnaprevistaupdate" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data consegna prevista update"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data conferma ricezione</label>
                                <asp:TextBox ID="txtDataconfermaricezione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data conferma ricezione"></asp:TextBox> 
                            </div>
                        </div>  
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data invio link</label>
                                <asp:TextBox ID="txtDatainviolink" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data invio link"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Annotazioni ordine</label>
                                <asp:TextBox ID="txtAnnotazioniordine" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni ordine" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Canone leasing</label>
                                <asp:TextBox ID="txtCanoneleasing" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone leasing"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Optional Canone</label>
                                <asp:TextBox ID="txtDeltaCanone" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Optional Canone"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Status ordine *</label>
                                <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statusordine" 
                                    DataValueField="idstatusordine" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Status Ordine"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusOrdine" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="row">                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Motivo Scarto (compilare solo se si scarta)</label>
                                <asp:TextBox ID="txtMotivoScarto" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Motivo Scarto" TextMode="MultiLine"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>