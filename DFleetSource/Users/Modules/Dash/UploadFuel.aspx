<%@ Page Title="Carica Documenti" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="UploadFuel.aspx.cs" Inherits="DFleet.Users.Modules.Dash.UploadFuel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Carica Documenti</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Dash/StoricoAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna Indietro</a> 
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
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati Consegna auto</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>


                    <div class="row">                             
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Verbale presa in consegna auto </label>
                                <asp:Label ID="lblViewFileVerbaleAuto" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileVerbaleAuto" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileVerbaleAuto" runat="server" />
                            </div>
                        </div>  
                        
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Verbale rifiuto auto </label>
                                <asp:Label ID="lblViewFileRifiutoAuto" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileRifiutoAuto" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileRifiutoAuto" runat="server" />
                            </div>
                        </div>     
               
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Libretto auto </label>
                                <asp:Label ID="lblViewFileLibrettoAuto" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileLibrettoAuto" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileLibrettoAuto" runat="server" />
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati Restituzione</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">                             
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Verbale di restituzione </label>
                                <asp:Label ID="lblViewFileFileVerbale" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileVerbale" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileVerbale" runat="server" />
                            </div>
                        </div>     
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Relazione perito </label>
                                <asp:Label ID="lblViewFileRelazione" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileRelazione" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileRelazione" runat="server" />
                            </div>
                        </div>   
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Denunce </label>
                                <asp:Label ID="lblViewFileDenunce" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFileDenunce" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileDenunce" runat="server" />
                            </div>
                        </div>  
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Ritiro Fuel Card</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">                             
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Ritiro Fuel Card </label>
                                <asp:Label ID="lblViewFileFuelCard" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="fuFuelCard" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFuelCard" runat="server" />
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