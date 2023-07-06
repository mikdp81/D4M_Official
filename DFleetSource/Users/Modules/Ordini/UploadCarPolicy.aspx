<%@ Page Title="Documento Car Policy" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="UploadCarPolicy.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.UploadCarPolicy" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Documento Car Policy </h3>
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
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <div class="form-group font-18">Firma il documento di Car Policy che trovi nella sezione <a href='../Dash/Documenti'>documenti</a><br /><br />
                                <asp:Label ID="lblViewFileCarPolicy" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblViewFilePatente" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblViewFileFuelCard" runat="server" Text=""></asp:Label>

                                <label class="control-label">Carica File</label> (solo file .pdf)
                                <asp:FileUpload ID="fuFileCarPolicy"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileCarPolicy" runat="server" />
                                
                                <br /><br />
                                <label class="control-label">Carica Patente</label> (solo file .pdf)
                                <asp:FileUpload ID="fuFilePatente"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFilePatente" runat="server" />
                                
                                <br /><br />
                                <label class="control-label">Richiesta Fuel Card (solo per chi ha ritirato l'auto)</label> (solo file .pdf)
                                <asp:FileUpload ID="fuFileFuelCard"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileFuelCard" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions text-center">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Carica" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>