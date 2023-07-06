<%@ Page Title="Inserimento Argomento FAQ" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="insArgomentoFAQ.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.insArgomentoFAQ" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Argomento FAQ</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewArgomentiFAQ")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Argomento *</label>
                                <asp:TextBox ID="txtArgomento" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Argomento"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Status *</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="">Status</asp:ListItem>
                                    <asp:ListItem Value="ATTIVO">ATTIVO</asp:ListItem>
                                    <asp:ListItem Value="SOSPESO">SOSPESO</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>  
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Immagine * (sono accettati i file .jpg, .png)</label>
                                <asp:FileUpload ID="fuImmagine"  CssClass="form-control" runat="server" />
                            </div>
                        </div>   
                    </div>  
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva e nuovo" CssClass="btn btn-success" /> 
                    <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva e chiudi" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>