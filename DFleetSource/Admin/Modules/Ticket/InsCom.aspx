<%@ Page Title="Nuova Comunicazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsCom.aspx.cs" Inherits="DFleet.Admin.Modules.Ticket.InsCom" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Nuova Comunicazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ticket/ViewComunicazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Indietro</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12 mail_listing">
                <!-- Visualizzazione Errori -->
			    <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
				    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
			    </asp:Panel>
      

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">                                
                                <label class="control-label">Priorit&agrave; *</label>
								<asp:DropDownList ID="ddlPriorita" runat="server" CssClass="form-control" AppendDataBoundItems="True">
									<asp:ListItem Value="0">NO</asp:ListItem>
									<asp:ListItem Value="1">SI</asp:ListItem>
								</asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Oggetto *</label>
                                <asp:DropDownList ID="ddlOggetto" runat="server" DataSourceID="odsoggetto" DataTextField="oggetto" 
                                    DataValueField="idoggetto" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Oggetto"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsoggetto" runat="server" SelectMethod="SelectOggetto" TypeName="BusinessLogic.ComunicazioniBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="blockuser" runat="server">
                        <div class="col-md-12">
                            <div class="form-group">                                
                                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Email Utente"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsersEmail" TypeName="BusinessLogic.AccountBL">
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
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Invia" CssClass="btn btn-success" /> 
                </div>
		    </div>
        </div>
    </div>
</div>

<asp:HiddenField ID="hduidcomunicazionepadre" runat="server" />
<asp:HiddenField ID="hduidcomunicazione" runat="server" />
<asp:HiddenField ID="hdMittente" runat="server" />
<asp:HiddenField ID="hdpriorita" runat="server" />
<asp:HiddenField ID="hdautorizz" runat="server" />


</asp:Content>
