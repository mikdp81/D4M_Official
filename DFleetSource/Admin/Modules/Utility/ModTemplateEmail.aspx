<%@ Page Title="Modifica Template Email" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModTemplateEmail.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModTemplateEmail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Template Email</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewTemplateEmail")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Titolo *</label>
                                <asp:TextBox ID="txtTitolo" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Titolo"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Oggetto *</label>
                                <asp:TextBox ID="txtOggetto" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Oggetto"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>           
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Corpo Mail *</label>                                
                                <asp:TextBox ID="txtCorpo" runat="server" Columns="30" Rows="10" CssClass="form-control summernote" placeholder="Corpo Mail" TextMode="MultiLine"></asp:TextBox> 
                            </div>
                        </div>      
                    </div>  
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>