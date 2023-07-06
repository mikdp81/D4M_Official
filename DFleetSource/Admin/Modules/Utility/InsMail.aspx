<%@ Page Title="Inserimento Mail" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsMail.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.InsMail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Mail</h3>
            </div>
            <%--<div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewConti")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>--%>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                1. Vai su Tracciati -> <a href="https://d4m.deloitte.it/Admin/Modules/Tracciati/Importa">Carica File</a><br />
                2. Scarica e compila il template "Invio mail"<br />
                3. Carica il tracciato selezionando "Invio mail" su "Tipo file" e scegliendo il template mail desiderato<br />
                4. Vai su <a href="https://d4m.deloitte.it/Admin/Modules/Tracciati/ViewImportazioni">Elenco Importazioni</a> e cliccare su "Importa"<br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Seleziona Template *</label>                                
                                <asp:DropDownList ID="ddlTemplate" runat="server" DataSourceID="odsTemplate" DataTextField="titolo" 
                                    DataValueField="idtemplate" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">-Seleziona-</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsTemplate" runat="server" SelectMethod="SelectAllTemplateEmail" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>    
                    </div>  
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Invia Prova" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>