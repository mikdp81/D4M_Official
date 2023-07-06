<%@ Page Title="Auto &amp; Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind  ="ViewCarList.aspx.cs" Inherits="DFleet.Admin.Modules.Car.ViewCarList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Auto &amp; Optional</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/InsCarList")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo</a> 
            </div>				
        </div>
    </div>


   <div class="row m-b-20">
     <div class="col-md-12 text-right"> 
         <a class="btn btn-filter svg-icon-30 svg-icon-filter" ID="btnFiltra" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Filtra"></a>
         <a class="btn btn-filter svg-icon-30 svg-icon-sort" ID="btnOrdina" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Criteri di ordinamento e numero records"> </a>
         <a class="btn btn-filter svg-icon-30 svg-icon-excel" ID="btnEsportaExcel" runat="server" onserverclick="btnEsporta_Click"></a>
    </div>
   </div>




    <div class="white-box" id="ordinamento" style="display:none;">
        <div class="row ">
            <div class="col-12">

                <div class="form-body">
                    <div class="col-md-2">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group marginbottmnull">
                                    <asp:DropDownList ID="ddlOrdina" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                            data-toggle="tooltip" data-placement="top" data-original-title="Ordina per">
                                        <asp:ListItem Value="">Ordina per</asp:ListItem>
                                        <asp:ListItem Value="codsocieta">Codice</asp:ListItem>
                                        <asp:ListItem Value="siglasocieta">Sigla</asp:ListItem>
                                        <asp:ListItem Value="societa">Societ&agrave;</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>  
                    <div class="col-md-2">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlTipoOrdina" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                            data-toggle="tooltip" data-placement="top" data-original-title="Tipo Ordine">
                                        <asp:ListItem Value="">Tipo Ordine</asp:ListItem>
                                        <asp:ListItem Value="ASC">Crescente</asp:ListItem>
                                        <asp:ListItem Value="DESC">Decrescente</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1"> 
                        <asp:DropDownList ID="ddlNRecord" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                            data-toggle="tooltip" data-placement="top" data-original-title="N.Record">
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                        <asp:ListItem Value="1000">1000</asp:ListItem>
                        <asp:ListItem Value="2000">2000</asp:ListItem>
                        <asp:ListItem Value="5000">5000</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdPagina" runat="server" Value="" />
                    </div>
                    <div class="col-md-3">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group marginbottmnull">
                                    <asp:Button ID="btnOrdinamento" runat="server" onclick="btnOrdina_Click" Text="Ordina" CssClass="btn btn-info" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>  
            </div>
        </div>  
    </div>

    <div class="white-box" id="filtri" style="display:none;">
        <div class="row">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlCodice" runat="server" DataSourceID="odscodcarlist" DataTextField="carlist" 
                                        DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="" Text="Car List"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscodcarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL" >
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlCodFornitore" runat="server" DataSourceID="odscodfornitore" DataTextField="fornitore" 
                                        DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Fornitore"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscodfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL" >
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtMarca" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Marca"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div> 
                         <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">                                      
                                        <asp:TextBox ID="txtModello" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Modello"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div> 
                                              
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra" CssClass="btn btn-info" />
                                        <asp:Button ID="btnSvuotaFiltri" runat="server" onclick="btnSvuotaFiltri_Click" Text="Svuota Filtri" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div> 
        </div>
    </div>
        
    <div class="white-box">

        <div class="row">
            <div class="col-12">

                <asp:GridView ID="gvRicCarList" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicCarList" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                 
                            <ItemStyle Width="5%" />   
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Codice Car List">
                            <ItemTemplate>
                               <%# Eval("codcarlist")%>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Codice Fornitore">
                            <ItemTemplate>
                               <%# Eval("codfornitore")%>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField> 
                                        
                        <asp:TemplateField HeaderText="Marca">
                            <ItemTemplate>
                                <%# Eval("marca")%>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Modello">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("modello")%></div>
                            </ItemTemplate>
                            <ItemStyle Width="40%" />
                        </asp:TemplateField>                     
                    
                        <asp:TemplateField HeaderText="Visibile">
                            <ItemTemplate>
                                <%# Eval("visibile")%>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='EditCarListAuto-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                                <a href='DelCarList-<%# Eval("Uid")%>' onClick="return confirm('Sei sicuro di voler cancellare questa car list?');" class="text-inverse p-r-10" title="" data-placement="left" data-toggle="tooltip" data-original-title="Cancella"><img src="../../../plugins/images/elimina.svg" class="icon20" border="0" alt="" /></a>
                                <a href='DetailAuto-<%# Eval("Uid")%>' class="text-inverse" title="" data-placement="left" data-toggle="tooltip" data-original-title="Visualizza Scheda"><img src="../../../plugins/images/visualizza_ordine.svg" class="icon20" border="0" alt="" /></a>
                            </ItemTemplate>  
                            <ItemStyle Width="15%" />                              
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicCarList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectCarListAuto" TypeName="BusinessLogic.CarsBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCodice" Name="codcarlist" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlCodFornitore" Name="codfornitore" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txtMarca" Name="marca" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtModello" Name="modello" PropertyName="Text" Type="String" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                        <asp:ControlParameter ControlID="ddlOrdina" Name="ordine" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlTipoOrdina" Name="tipoordine" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>  

                <div class="dataTables_wrapper">
                    <div class="dataTables_info">
                        <asp:Label ID="lblNumRecord" runat="server" Text=""></asp:Label>       
                    </div>            

                    <div class="dataTables_paginate paging_simple_numbers">
                        <asp:LinkButton ID="pagingprec" runat="server" OnClick="pagingprec_Click" CssClass="paginate_button"><</asp:LinkButton>
                        <asp:TextBox ID="txtnumpag" runat="server" Text="1" style="width:50px;text-align:center;" OnTextChanged="txtnumpag_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                        <asp:LinkButton ID="pagingnext" runat="server" OnClick="pagingnext_Click" CssClass="paginate_button">></asp:LinkButton>
                    </div>
                </div>

                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</div>


</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js">  
  
</script>

</asp:Content>