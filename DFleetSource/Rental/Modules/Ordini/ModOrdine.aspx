﻿<%@ Page Title="Carica Offerta" Language="C#" MasterPageFile="~/Rental/MasterpageRental.Master" AutoEventWireup="true" CodeBehind="ModOrdine.aspx.cs" Inherits="DFleet.Rental.Modules.Ordini.ModOrdine" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Carica Offerta</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Rental/Modules/Ordini/ViewOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Carica Offerta (*pdf)</label>
                                <asp:FileUpload ID="fuFileConferma"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileConfermaRental" runat="server" />
                                <asp:Label ID="lblViewConfermaRental" runat="server" Text=""></asp:Label>
                            </div>
                        </div>    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Note</label>
                                <asp:TextBox ID="txtNote" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control" placeholder="Note"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data Consegna Prevista</label>
                                <asp:TextBox ID="txtDataConsegnaPrevista" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Consegna Prevista"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                    <asp:HiddenField ID="hdidordine" runat="server" />
                    <asp:HiddenField ID="hdidstatusordine" runat="server" />
                    <asp:HiddenField ID="hduserid" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Invia Offerta" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>



    <div class="white-box">
        <div class="row">
            <div class="col-sm-6">
                <h5>Dati Ordine</h5>
                <asp:Label ID="lblDatiOrdine" runat="server" Text="" />
            </div>            
            <div class="col-sm-6">
                <h5>Dati Richiedente</h5>
                <asp:Label ID="lblDatiDriver" runat="server" Text="" />
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                
                <div class="col-md-6">    
                    <div class='table-responsive'>
                        <table class='table'>
                            <tr>
                                <td class="width30p nopadding">COD. JATO</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblCodjatoauto" runat="server" Text=""></asp:Label></h4> </td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Marca</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> </td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Modello</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Alimentazione</td>
                                <td class="width70p nopadding"><h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> / <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Cilindrata</td>
                                <td class="width70p nopadding"><h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Fringe benefit base</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Optional canone</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblcanoneleasing" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                        </table>
                    </div>                            
                </div>
                <div class="col-md-6"> 
                    <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        

        <div class="row">
            <div class="col-12">  
                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                <h5>Optional</h5>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal>

            </div>
        </div>
    </div>
</div>


</asp:Content>