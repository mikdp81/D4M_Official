<%@ Page Title="Inserimento auto sostitutiva" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsAutoSost.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsAutoSost" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento auto sostitutiva</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewAutoSostitutive")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Driver</label>
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Societ&agrave;</label>
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Targa</label>
                                <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Data inizio assegnazione</label>
                                <asp:TextBox ID="txtDataInizioAssegnazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio assegnazione" Text="01/01/2000"></asp:TextBox>                 
                            </div>
                        </div>    
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Data fine assegnazione </label>
                                <asp:TextBox ID="txtDataFineAssegnazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine assegnazione" Text="31/12/2099"></asp:TextBox>                                               
                            </div>
                        </div> 
                    </div>                                    
                    <div class="row"> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Annotazioni</label>
                                <asp:TextBox ID="txtAnnotazioni" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>

</div>


</asp:Content>