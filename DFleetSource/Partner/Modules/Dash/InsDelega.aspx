<%@ Page Title="" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="InsDelega.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.InsDelega" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">    
    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Delega un assistente</h3> <br />
                <span class="colorred font-bold">*</span> L'assistente delegato avr&agrave; accesso a tutti i dati presenti in piattaforma
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
                                <label class="control-label">Scegli assistente 1 *</label>
                                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="seleziona"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                                <br /><br />
                                <label class="control-label">Abilita a ricevere email multe</label><br />
                                NO <input type="checkbox" id="flgemailmulte" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email penali</label><br /> 
                                NO <input type="checkbox" id="flgemailpenali" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email ticket</label><br />
                                NO <input type="checkbox" id="flgemailticket" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">                                
                                <label class="control-label">Scegli assistente 2</label>
                                <asp:DropDownList ID="ddlUsers2" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="seleziona"></asp:ListItem>
                                </asp:DropDownList>

                                <br /><br />
                                <label class="control-label">Abilita a ricevere email multe</label><br />
                                NO <input type="checkbox" id="flgemailmulte2" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email penali</label><br /> 
                                NO <input type="checkbox" id="flgemailpenali2" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email ticket</label><br />
                                NO <input type="checkbox" id="flgemailticket2" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Scegli assistente 3</label>
                                <asp:DropDownList ID="ddlUsers3" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="seleziona"></asp:ListItem>
                                </asp:DropDownList>

                                <br /><br />
                                <label class="control-label">Abilita a ricevere email multe</label><br />
                                NO <input type="checkbox" id="flgemailmulte3" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email penali</label><br /> 
                                NO <input type="checkbox" id="flgemailpenali3" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />

                                <label class="control-label">Abilita a ricevere email ticket</label><br />
                                NO <input type="checkbox" id="flgemailticket3" class="js-switch" data-color="#13dafe" runat="server" /> SI <br />
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

<asp:HiddenField ID="hdcodsocieta" runat="server" />

</asp:Content>