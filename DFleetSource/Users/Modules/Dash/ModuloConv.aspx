<%@ Page Title="Documento Convivenza" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ModuloConv.aspx.cs" Inherits="DFleet.Users.Modules.Dash.ModuloConv" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Documento Convivenza</h3>
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
                            <div class="form-group font-18">
                                <asp:Label ID="lblViewFileDocConv" runat="server" Text=""></asp:Label>

                                <label class="control-label">Carica File</label> (solo file .pdf)
                                <asp:FileUpload ID="fuFileDocConv"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileDocConv" runat="server" />
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