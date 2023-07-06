<%@ Page Title="Lista Comunicazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DetailCom.aspx.cs" Inherits="DFleet.Admin.Modules.Ticket.DetailCom" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-6">
                <h3 class="box-title m-b-0">Ticket N. <asp:Label ID="lblNumTicket" runat="server" Text="" /> del <asp:Label ID="lblDataIns" runat="server" Text="" /></h3>
            </div>
            <div class="col-md-6">
                Oggetto <h3 class="font-bold m-t-0"> <asp:Label ID="lblOggetto" runat="server" Text=""></asp:Label></h3>
            </div>			
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <!-- Visualizzazione Errori -->
			<asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
				<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
			</asp:Panel>
        </div>
    </div>
    
    <div class="white-box">	
        <div class="row">        
            <div class="col-md-12">
                <h5><asp:Label ID="lblUtente" runat="server" Text=""></asp:Label></h5>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblSocieta" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>


    <div class="row">
		<div class="col-12">	
            <div class="white-box-nobg">	
			    <asp:GridView ID="gvComCorr" runat="server"
					    AutoGenerateColumns="False" DataSourceID="odsComCorr"
					    GridLines="None" PageSize="50" Width="100%" HorizontalAlign="Center">
				    <Columns>
					    <asp:TemplateField HeaderText="">
						    <ItemTemplate>
                                <div class="font-weight-bold text-muted text-right"><%# Eval("datainvio") %></div>
                                <div class="white-box">
                                    <div class="m-b-30"><h5><%# Eval("cognome") %> -> <%# ReturnDestinatario(Eval("destinatario").ToString()) %> </h5></div>

							        <%# ReturnTesto(Eval("testocomunicazione").ToString()) %><br /><br />
							        <%# ReturnAllegati(Eval("Uidcomunicazione").ToString()) %>                             
                                </div>
						    </ItemTemplate>
					    </asp:TemplateField>  
				    </Columns>    
				    <PagerStyle HorizontalAlign="Right" />    
			    </asp:GridView>

			    <asp:ObjectDataSource ID="odsComCorr" runat="server" OldValuesParameterFormatString="original_{0}" 
					    SelectMethod="SelectComunicazioniCorrelate" TypeName="BusinessLogic.ComunicazioniBL">
				    <SelectParameters>
					    <asp:ControlParameter ControlID="hduidcomunicazione" DbType="Guid" Name="UIDcomunicazione" PropertyName="Value" />
				    </SelectParameters>
			    </asp:ObjectDataSource> 
            </div>
		</div>
    </div>


    <div class="white-box">	

        <div class="row" id="kt_inbox_reply">
		    <div class="col-12">		
                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtText" Rows="10" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Scrivi messaggio..." />
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
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Invia il messaggio" CssClass="btn btn-success" /> 
                </div>
		    </div>
        </div>
    </div>
</div>

<asp:HiddenField ID="hduidcomunicazionepadre" runat="server" />
<asp:HiddenField ID="hduidcomunicazione" runat="server" />
<asp:HiddenField ID="hdMittente" runat="server" />
<asp:HiddenField ID="hdpriorita" runat="server" />
<asp:HiddenField ID="hdidoggetto" runat="server" />


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
$(document).ready(function () {  
    $("#apriscrivimsg").click(function () {
        $("#kt_inbox_reply").show(500);
    });
});  
</script>

</asp:Content>