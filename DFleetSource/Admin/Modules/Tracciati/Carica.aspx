<%@ Page Title="Carica Tracciati" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Carica.aspx.cs" Inherits="DFleet.Admin.Modules.Tracciati.Carica" %>
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
                <h4>Scarica le demo:</h4> <br />
                <ul>
                    <li><a href="../../../Repository/documenti/tracciato_eni.xlsx" target="_blank">Tracciato Carburante ENI (formato .xlsx)</a></li> 
                    <li><a href="../../../Repository/documenti/tracciato_ip.xlsx" target="_blank">Tracciato Carburante IP (formato .xlsx)</a></li> 
                    <li><a href="../../../Repository/documenti/fringe_benefit_2021.xlsx" target="_blank">Tracciato Fringe Benefit ACI (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_fattura.xml" target="_blank">Tracciato Fattura (formato .xml)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_anagrafiche.csv" target="_blank">Tracciato Anagrafiche (formato .csv)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_concur.xlsx" target="_blank">Tracciato Concur Car Mileage (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_concur_storni.xlsx" target="_blank">Tracciato Concur Storni (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/tracciato_concur_fuel.xlsx" target="_blank">Tracciato Concur Fuel (formato .xlsx)</a></li>
                    <li><a href="../../../Repository/documenti/traciato_telepass_consumi.xls" target="_blank">Tracciato Consumi Telepass (formato .xls)</a></li>
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


    
    <div class="white-box">
        <div class="row">
            <div class="col-12">    

                <asp:GridView ID="gvFileCaricati" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsFileCaricati" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Tipo Caricamento">
                            <ItemTemplate>
                               <%# Eval("tipofile")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                                        
                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                               <a href="../../../DownloadFile?type=import&nomefile=<%# Eval("filexml")%>" target="_blank"><%# Eval("filexml")%></a>
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Caricato il">
                            <ItemTemplate>
                                <%# Eval("datacaricato")%>
                            </ItemTemplate>
                        </asp:TemplateField>   

                        <asp:TemplateField HeaderText="Importato">
                            <ItemTemplate>
                               <%# ReturnImportazione(Eval("importato").ToString(), Eval("dataimportazione").ToString())%>  
                            </ItemTemplate>
                        </asp:TemplateField>          
                        
                        <asp:TemplateField HeaderText="Azioni">
                            <ItemTemplate>
                                <input type="button" value="ELABORA" class="elabora" data-id="<%# Eval("idprog")%>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFileCaricati" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectFileCaricati" TypeName="BusinessLogic.FileTracciatiBL">
                </asp:ObjectDataSource>  

            </div>
        </div>
    </div>

</div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".elabora").click(function () {
            var idprog = $(this).attr("data-id");
            var periododal = $("#ContentBody_txtPeriododal").val();
            var periodoal = $("#ContentBody_txtPeriodoal").val();

            var verificaoperazione = $.ajax({
                async: false,
                url: "../../../Handler/ElaboraTracciati.ashx?idprog=" + idprog + "&periododal=" + periododal + "&periodoal=" + periodoal,
                type: 'POST',
                dataType: 'html'
            }).responseText;


            if (verificaoperazione == "OK") {
                alert("Elaborazione avvenuta correttamente.")
            }
            else {
                alert("Errore! Riprova.")
            }
        });   
    });
</script>

</asp:Content>