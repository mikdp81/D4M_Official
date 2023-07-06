<%@ Page Title="Consegna Auto Assegnata" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModConsegna.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ModConsegna" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Consegna Auto Assegnata</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/Assegnazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                Targa<br />
                <h4><asp:Label ID="lblTarga" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
                <h4><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h4>
                Driver <br />
                <h4> <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label></h4>
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data Consegna</label>
                                <asp:TextBox ID="txtDataConsegna" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Consegna"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Ora Consegna</label>
                                <asp:TextBox ID="txtOraConsegna" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Ora Consegna"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Luogo Consegna</label>
                                <asp:TextBox ID="txtLuogoConsegna" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Luogo Consegna"></asp:TextBox>
                            </div>
                        </div>
                    </div>                                   
                    <div class="row"> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Annotazioni Consegna</label>
                                <asp:TextBox ID="txtAnnotazioniConsegna" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hdidass" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Aggiorna" CssClass="btn btn-success" />
                    <asp:Button ID="btnMail" runat="server" onclick="btnMail_Click" Text="Invio Mail" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                <asp:Label ID="lblDati" runat="server" Text=""></asp:Label> 
            </div>
        </div>
    </div>


</div>


</asp:Content>