<%@ Page Title="Nuova Comunicazione" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="InsCom.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.InsCom" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">D4M TICKETING</h3>
                <h5>Assistenza generale e supporto sulla gestione auto ed eventuali problematiche </h5>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewComunicazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Indietro</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-8">
                <!-- Visualizzazione Errori -->
			    <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
				    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
			    </asp:Panel>
      

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Oggetto *</label>
                                <asp:DropDownList ID="ddlOggetto" runat="server" DataSourceID="odsoggetto" DataTextField="oggetto" 
                                    DataValueField="idoggetto" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Oggetto"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsoggetto" runat="server" SelectMethod="SelectOggettoDriver" TypeName="BusinessLogic.ComunicazioniBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtText" Rows="3" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Scrivi messaggio..." />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">                                
							    <label class="control-label"><strong>Allega uno o pi&ugrave; file</strong> (*.pdf, *.doc, *.docx, *.xls, *.xlsx) </label>
							    <input type="file" id="myfile" multiple="multiple" name="myfile" runat="server" size="100" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Invia" CssClass="btn btn-success" /> 
                </div>
		    </div>

            <div class="col-md-4">
                <table border="0" style="width:100%">
                    <tr>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-info.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="INFORMAZIONI SULL'ORDINE Informazioni in tempo reale sullo stato dell'ordine" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-denuncia.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="DENUNCIA DANNI Supporto nella procedura di denuncia danni con o senza controparte" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-multe.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="GESTIONE MULTE Presa in carico dei verbali ed elaborazione diretta di questi" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-proroghe.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="GESTIONE PROROGHE Alla scadenza del contratto di leasing, sono gestite le eventuali proroghe in attesa dell'arrivo della nuova vettura" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-fuelcard.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="GESTIONE FUEL CARD E SERVIZI TELEPASS Creazione e assistenza per fuel card e servizi telepass" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"><br /><br /></td>
                    </tr>
                    <tr>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-incidente.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="ASSISTENZA IN CASO DI INCIDENTE Supporto ed assistenza diretta in caso di incidente" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-furto.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="SEGNALAZIONE FURTO Assistenza in caso di segnalazione furto della vettura" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-autosostitutiva.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="RICHIESTA AUTO SOSTITUTIVA In attesa della riparazione della propria auto, D4M provvede a reperire un'auto sostitutiva in maniera celere" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-pneumatici.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="TRASFERIMENTO PNEUMATICI Supporto in tutti i passaggi del trasferimento pneumatici" />
                        </td>
                        <td style="width:60px"><img src="../../../plugins/images/ico-ticket-amministrazione.svg" width="50" alt="" border="0" data-toggle="tooltip" title="" data-placement="top" 
                            data-original-title="SERVIZI DI AMMINISTRAZIONE Gestione amministrativa in collaborazione con team partner affaire" />
                        </td>
                    </tr>
                </table>
                
            </div>
        </div>
    </div>
</div>

<asp:HiddenField ID="hduidcomunicazionepadre" runat="server" />
<asp:HiddenField ID="hduidcomunicazione" runat="server" />
<asp:HiddenField ID="hdMittente" runat="server" />
<asp:HiddenField ID="hdpriorita" runat="server" />


</asp:Content>
