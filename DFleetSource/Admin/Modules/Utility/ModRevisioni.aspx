<%@ Page Title="Modifica Revisione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModRevisioni.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModRevisioni" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Revisione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewRevisioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                            <asp:Label ID="lblDatiRev" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-action m-t-30">  
                    <div class="row">
                        <div class="col-md-2">                            
                            NON EFFETTUATA <input type="checkbox" id="flgcheck" class="js-switch" data-color="#13dafe" runat="server" /> EFFETTUATA
                        </div>                        
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">File * (sono accettati i file .pdf, .doc, docx)</label>
                                <asp:FileUpload ID="fuFileRev"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileRev" runat="server" />
                                <asp:Label ID="lblViewFileRev" runat="server" Text=""></asp:Label>
                            </div>
                        </div> 
                        <div class="col-md-6">     
                            <asp:HiddenField ID="hduid" runat="server" />
                            <asp:Button ID="btnCheck" runat="server" onclick="btnCheck_Click" Text="SALVA" CssClass="btn btn-success" /><br />
                        </div>
                    </div>
                </div>  
            </div> 
        </div>
    </div>
</div>



</asp:Content>