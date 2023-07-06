<%@ Page Title="Carica File" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="insMovision.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.insMovision" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Carica File</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewMovision")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body panel-body form-horizontal">
                    <div class="row">                         
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Carica File * (file accettati: .pdf, .doc, .docx, .xls, .xlsx, .csv)</label> 
                                <asp:FileUpload ID="fuFileDoc"  CssClass="form-control" runat="server" />
                            </div>
                        </div>  
                    </div>  
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Carica" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>