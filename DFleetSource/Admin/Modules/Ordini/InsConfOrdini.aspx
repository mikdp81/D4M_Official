<%@ Page Title="Inserimento Nuova Configurazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsConfOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.InsConfOrdini" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Nuova Configurazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/ViewConfDriver")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                    DataValueField="iduser" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Scegli Driver</asp:ListItem>
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
                                    <asp:ListItem Value="" Text="Societa"></asp:ListItem>
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
                                <label class="control-label">CarPolicy</label>
                                <asp:DropDownList ID="ddlCodCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
                                     DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                    <asp:ListItem Value="" Text="Codice Car Policy"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscarpolicy" runat="server" SelectMethod="SelectAllCarPolicy" TypeName="BusinessLogic.CarsBL">
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
                                <label class="control-label">Car Policy (solo file .pdf)</label>                                
                                <asp:FileUpload ID="fuFileCarPolicy"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileCarPolicy" runat="server" />
                                <asp:Label ID="lblViewFileCarPolicy" runat="server" Text=""></asp:Label>
                            </div>
                        </div>    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Patente (solo file .pdf)</label>                                
                                <asp:FileUpload ID="fuFilePatente"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFilePatente" runat="server" />
                                <asp:Label ID="lblViewFilePatente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>   
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Inserisci" CssClass="btn btn-success" />
                </div>

            </div> 
        </div>
    </div>

</div>



</asp:Content>