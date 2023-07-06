<%@ Page Title="Inserimento Task" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="InsTask.aspx.cs" Inherits="DFleet.Users.Modules.Dash.InsTask" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Task</h3>
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
                                <label class="control-label">Data *</label>
                                <asp:TextBox ID="txtData" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data"></asp:TextBox> 
                            </div>
                        </div>          
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Link </label>
                                <asp:TextBox ID="txtLink" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Link"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Testo *</label>
                                <asp:TextBox ID="txtTesto" runat="server" Rows="3" CssClass="form-control" placeholder="Testo" TextMode="MultiLine"></asp:TextBox> 
                            </div>
                        </div>   
                    </div>  
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>