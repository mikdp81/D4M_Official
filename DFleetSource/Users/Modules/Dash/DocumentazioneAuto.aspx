<%@ Page Title="Riconsegna Auto" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="DocumentazioneAuto.aspx.cs" Inherits="DFleet.Users.Modules.Dash.DocumentazioneAuto" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Documentazione Auto</h3>
            </div>				
        </div>
    </div>
    
    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Literal ID="ltdati" runat="server"></asp:Literal><br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
               <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">        
                    <div class="row">         
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">File Assicurazione *</label>
                                <asp:FileUpload ID="fuFileAssicurazione" CssClass="form-control" runat="server" />
                            </div>
                        </div>       
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Anno *</label>
                                <asp:TextBox ID="txtAnno" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Anno"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hdtarga" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

</div>


</asp:Content>

