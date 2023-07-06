<%@ Page Title="Restituzione Auto" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="RiconsegnaAuto.aspx.cs" Inherits="DFleet.Users.Modules.Dash.RiconsegnaAuto" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Restituzione Auto</h3>
            </div>				
        </div>
    </div>
    
    <div class="white-box">
        <div class="row">
            <div class="col-md-6">
                <asp:Literal ID="ltdati" runat="server"></asp:Literal>
            </div>
            <div class="col-md-6">
                <asp:Literal ID="ltdati2" runat="server"></asp:Literal>
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
                                <label class="control-label">File verbale consegna *</label>
                                <asp:FileUpload ID="fuFileVerbale" CssClass="form-control" runat="server" />
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">File relazione perito *</label>
                                <asp:FileUpload ID="fuFileRelazione" CssClass="form-control" runat="server" />
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">File denunce </label>
                                <asp:FileUpload ID="fuFileDenunce" CssClass="form-control" runat="server" />
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Annotazioni</label>
                                <asp:TextBox ID="txtAnnotazionicontratto" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <div class="row">         
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Tipo gomme *</label>                                
								<asp:DropDownList ID="ddlTipoGomme" runat="server" CssClass="form-control" AppendDataBoundItems="True">
									<asp:ListItem Value="">-Seleziona-</asp:ListItem>
									<asp:ListItem Value="ESTIVO">ESTIVO</asp:ListItem>
									<asp:ListItem Value="INVERNALE">INVERNALE</asp:ListItem>
								</asp:DropDownList>
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Luogo gomme *</label>
                                <asp:TextBox ID="txtLuogoGomme" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Luogo gomme"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data ultimo cambio gomme *</label>
                                <asp:TextBox ID="txtDataCambioGomme" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data ultimo cambio gomme"></asp:TextBox> 
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Km restituzione *</label>
                                <asp:TextBox ID="txtKmRestituzione" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Km restituzione"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hdidass" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

</div>


</asp:Content>

