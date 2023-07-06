<%@ Page Title="Abbina Fattura" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModAbbinaFattura.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.ModAbbinaFattura" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Abbina Fattura</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="#" class="btn btn-info waves-effect waves-light m-t-10">Torna indietro</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div> 
        <div class="row"> 
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label">Centro Costo</label>
                    
                </div>
            </div> 
            <div class="row"> 
                <div class="col-md-12">
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Abbina" CssClass="btn btn-success" />
                </div>
            </div>   
        </div>   
    </div>
</div>

<asp:HiddenField ID="hduid" runat="server" />
<asp:HiddenField ID="hduidfattura" runat="server" />

</asp:Content>