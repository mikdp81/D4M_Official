<%@ Page Title="Modifica Societa" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModSocieta.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModSocieta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Societ&agrave;</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewSocieta")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Legacy Company Code *</label>
                                <asp:TextBox ID="txtCodice" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Legacy Company Code"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Company Code *</label>
                                <asp:TextBox ID="txtCompany" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Company Code"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Sigla *</label>
                                <asp:TextBox ID="txtSigla" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Sigla"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>       
                    </div>           
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Societ&agrave; *</label>
                                <asp:TextBox ID="txtSocieta" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Societ&agrave;"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Service Area</label>
                                <asp:TextBox ID="txtServiceArea" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Service Area"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>           
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Partita IVA *</label>
                                <asp:TextBox ID="txtPartitaIVA" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Partita IVA"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Codice CDC *</label>
                                <asp:TextBox ID="txtCodiceCDC" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Codice CDC"></asp:TextBox> 
                            </div>
                        </div>     
                    </div> 
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>