<%@ Page Title="Inserimento Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsOptional.aspx.cs" Inherits="DFleet.Admin.Modules.Car.InsOptional" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Optional</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/ViewOptional")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Optional *</label>
                                <asp:TextBox ID="txtOptional" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Optional"></asp:TextBox> 
                            </div>
                        </div>     
                    </div>  
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Categoria *</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" DataSourceID="odscat" DataTextField="categoriaoptional" 
                                    DataValueField="codcategoriaoptional" CssClass="form-control select2 ddlCategoria" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Categoria"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscat" runat="server" SelectMethod="SelectAllCategoriePrimoLivello2" TypeName="BusinessLogic.CarsBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Sotto Categoria </label>
                                <asp:DropDownList ID="ddlSottoCategoria" runat="server" DataSourceID="odssottocat" DataTextField="categoriaoptional" 
                                    DataValueField="codcategoriaoptional" CssClass="form-control select2 ddlSottoCategoria" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Sotto Categoria"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odssottocat" runat="server" SelectMethod="SelectAllCategorieSecondoLivello" TypeName="BusinessLogic.CarsBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>     
                    </div>
                    <div class="row">                         
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Note </label>
                                <asp:TextBox ID="txtNote" runat="server" Columns="30" Rows="3" TextMode="MultiLine" CssClass="form-control" placeholder="Note"></asp:TextBox> 
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


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".ddlCategoria").change(function () {
            var codcategoria = $(this).val();

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListSottoCategorie.ashx?codcategoria=" + codcategoria,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded,
                error: AjaxFailed
            });
        });   
    });  


    function AjaxSucceeded(result) {
        BindCheckBoxList(result);
    }
    function AjaxFailed(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList(result, myId);
    }
    function CreateCheckBoxList(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value=''>Sotto Categoria</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlSottoCategoria").html(listItems);
    }
</script>

</asp:Content>