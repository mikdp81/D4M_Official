<%@ Page Title="Carica Tracciati" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Importa.aspx.cs" Inherits="DFleet.Admin.Modules.Tracciati.Importa" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Carica Tracciati</h3>
            </div>		
            <div class="col-md-5 text-right">
                <a href="ViewImportazioni" class="btn btn-info">Elenco Importazioni</a>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">  
                <h4>Scarica le demo:</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <ul>
                    <li><a href="../../../Repository/documenti/tracciato_eni.xlsx" target="_blank">Tracciato Carburante ENI (formato .xlsx)</a></li> 
                    <li><a href="../../../Repository/documenti/tracciato_ip.xlsx" target="_blank">Tracciato Carburante IP (formato .xlsx)</a></li> 
                    <li><a href="../../../Repository/documenti/fringe_benefit_2021.xlsx" target="_blank">Tracciato Fringe Benefit ACI (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_fattura.xml" target="_blank">Tracciato Fattura (formato .xml)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_anagrafiche.csv" target="_blank">Tracciato Anagrafiche (formato .csv)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_concur.xlsx" target="_blank">Tracciato Concur Car Mileage (formato .xlsx)</a></li>
                </ul>
            </div>
            <div class="col-md-6">
                <ul>
                    <li><a href="../../../Repository/documenti/tracciato_concur_storni.xlsx" target="_blank">Tracciato Concur Storni (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_concur_fuel.xlsx" target="_blank">Tracciato Concur Fuel (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/traciato_telepass_consumi.xls" target="_blank">Tracciato Consumi Telepass (formato .xls)</a></li>
                    <li><a href="../../../Repository/documenti/demo_fuelcard.xlsx" target="_blank">Tracciato FuelCard (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_email.xlsx" target="_blank">Invio Email (formato .xlsx)</a></li>
                </ul>
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
                                <label class="control-label">Tipo File * </label>
                                <asp:DropDownList ID="ddlTipoFile" runat="server" DataSourceID="odstipofile" DataTextField="tipofile" 
                                    DataValueField="idtipofile" CssClass="form-control select2 tipofile" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Tipo File"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstipofile" runat="server" SelectMethod="SelectTipoFile" TypeName="BusinessLogic.FileTracciatiBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div> 
                        <div class="col-md-4" id="periodo" style="display:none;">
                            <div class="form-group">
                                <label class="control-label col-md-12">Periodo dal - al </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPeriododal" runat="server" Columns="10" MaxLength="10" CssClass="form-control datePicker" placeholder="Periodo dal"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPeriodoal" runat="server" Columns="10" MaxLength="10" CssClass="form-control datePicker" placeholder="Periodo al"></asp:TextBox>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-4" id="template" style="display:none;">
                            <div class="form-group">
                                <label class="control-label">Seleziona Template</label>                                
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">File Tracciato * (.xls, .xlsx, .csv, .txt, .xml) </label>
                                <input type="file" id="fuFileTracc" multiple="multiple" name="fuFileTracc" runat="server" size="100" />   
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


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $("#ContentBody_ddlTipoFile").click(function () {
            var idprog = $(this).val();

            if (idprog == "3") {
                $("#periodo").show();
                $("#template").hide();
            }
            else {
                if (idprog == "11") {
                    $("#template").show();
                    $("#periodo").hide();
                }
                else {
                    $("#template").hide();
                    $("#periodo").hide();
                }
            }

        });   
    });
</script>

</asp:Content>