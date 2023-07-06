<%@ Page Title="Carica Documenti Auto" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="EditFileAuto.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.EditFileAuto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Carica Documenti Auto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/ViewFileAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                            <h3 class="box-title colorverded">Libretto</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Libretto auto </label>
                                <asp:FileUpload ID="fuFileLibrettoAuto" CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileLibrettoAuto" runat="server" />
                                <asp:Label ID="lblViewFileLibrettoAuto" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div> 


                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati Consegna auto</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>


                    <div class="row">                             
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Verbale presa in consegna auto </label>
                                <asp:FileUpload ID="fuFileVerbaleAuto" CssClass="form-control" runat="server" />
                            </div>
                        </div>  
                        
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Verbale rifiuto auto </label>
                                <asp:FileUpload ID="fuFileRifiutoAuto" CssClass="form-control" runat="server" />
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Verbale di restituzione </label>
                                <asp:FileUpload ID="fuFileVerbale" CssClass="form-control" runat="server" />
                            </div>
                        </div>     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Relazione perito </label>
                                <asp:FileUpload ID="fuFileRelazione" CssClass="form-control" runat="server" />
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Denunce </label>
                                <asp:FileUpload ID="fuFileDenunce" CssClass="form-control" runat="server" />
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Ritiro Fuel Card </label>
                                <asp:FileUpload ID="fuFuelCard" CssClass="form-control" runat="server" />
                            </div>
                        </div>
                    </div>
                 
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hduidcontratto" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:HiddenField ID="hdtarga" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
    <div class="white-box">
        <div class="row">
            <div class="form-body">        
                <div class="row">         
                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="control-label">File Assicurazione *</label>
                            <asp:FileUpload ID="fuFileAssicurazione" CssClass="form-control" runat="server" />
                        </div>
                    </div>       
                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="control-label">Anno *</label>
                            <asp:TextBox ID="txtAnno" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Anno"></asp:TextBox> 
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</div>


</asp:Content>