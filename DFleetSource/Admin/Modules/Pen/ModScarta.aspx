<%@ Page Title="Non Autorizza" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModScarta.aspx.cs" Inherits="DFleet.Admin.Modules.Pen.ModScarta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Non Autorizza</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Pen/OrdiniInCorso")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Motivo Scarto</label>
                                <asp:TextBox ID="txtMotivoScarto" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Motivo Scarto" TextMode="MultiLine"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Scarta" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>