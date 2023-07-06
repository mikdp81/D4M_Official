<%@ Page Title="Modifica Team" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModTeam.aspx.cs" Inherits="DFleet.Admin.Modules.Users.ModTeam" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Team</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewTeam")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Status *</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Seleziona</asp:ListItem>
                                    <asp:ListItem Value="ATTIVO">ATTIVO</asp:ListItem>
                                    <asp:ListItem Value="SOSPESO">SOSPESO</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Team *</label>      
                                <asp:TextBox ID="txtTeam" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Utenti </label>
                                <asp:ListBox ID="ddlUtenti" CssClass="select2 select2-multiple" SelectionMode="Multiple" multiple="multiple"
                                    runat="server" AppendDataBoundItems="True">
                                </asp:ListBox>      
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="control-label">Attivit&agrave; </label>      
                                <asp:ListBox ID="ddlAttivit" CssClass="select2 select2-multiple" SelectionMode="Multiple" multiple="multiple"
                                    runat="server" AppendDataBoundItems="True">
                                </asp:ListBox>  
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-actions">
                    <asp:HiddenField ID="hdidteam" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div>
            </div>

        </div>
    </div>
</div>


</asp:Content>