<%@ Page Title="Ritiro Auto" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="RichiestaAuto.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.RichiestaAuto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ritiro Auto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Ordini/RitiroAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
            <div class="col-12"  id="blockaccetta" runat="server">
                <asp:Panel ID="pnlMessage2" runat="server">
                    <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Documenti auto ritirata</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">                            
                        <div class="col-md-6">
                            <div class="form-group">                              
                                <label class="control-label">File Verbale </label> (sono accettati solo i file .pdf)
                                <asp:FileUpload ID="fuFileVerbale"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileVerbale" runat="server" />
                                <asp:Label ID="lblViewFileVerbale" runat="server" Text=""></asp:Label>
                            </div>
                        </div>                            
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">File Libretto </label> (sono accettati solo i file .pdf)
                                <asp:FileUpload ID="fuFileLibretto"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileLibretto" runat="server" />
                                <asp:Label ID="lblViewFileLibretto" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnAccetta" runat="server" onclick="btnAccetta_Click" Text="Salva" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

    
    <div class="white-box">
        <div class="row">
            <div class="col-12" id="blockrifiuto" runat="server">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Documenti auto rifiutata</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">                            
                        <div class="col-md-6">
                            <div class="form-group">                              
                                <label class="control-label">Verbale Rifiuto </label> (sono accettati solo i file .pdf)
                                <asp:FileUpload ID="fuFileRifiuto"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileRifiuto" runat="server" />
                                <asp:Label ID="lblViewFileRifiuto" runat="server" Text=""></asp:Label>
                            </div>
                        </div>                            
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Motivo Rinuncia</label>
                                <asp:TextBox ID="txtMotivoRinuncia" runat="server" Columns="30" Rows="1" CssClass="form-control" placeholder="Motivo Rinuncia" TextMode="MultiLine"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hdidass" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnRifiuta" runat="server" onclick="btnRifiuta_Click" Text="Salva" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

</div>


</asp:Content>