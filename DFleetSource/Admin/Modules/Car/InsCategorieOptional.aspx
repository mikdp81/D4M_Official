<%@ Page Title="Inserimento Categoria Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsCategorieOptional.aspx.cs" Inherits="DFleet.Admin.Modules.Car.InsCategorieOptional" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Categoria Optional</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/ViewCategorieOptional")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Codice *</label>
                                <asp:TextBox ID="txtCodice" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Codice"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Categoria *</label>
                                <asp:TextBox ID="txtCategoria" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Categoria"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>  
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Ordine *</label>
                                <asp:TextBox ID="txtOrdine" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Ordine" TextMode="Number"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Categoria Padre (lasciare vuota se categoria di primo livello) </label>
                                <asp:DropDownList ID="ddlCategoriaPadre" runat="server" DataSourceID="odscatpadre" DataTextField="categoriaoptional" 
                                    DataValueField="codcategoriaoptional" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Categoria Padre"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscatpadre" runat="server" SelectMethod="SelectAllCategoriePrimoLivello" TypeName="BusinessLogic.CarsBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
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