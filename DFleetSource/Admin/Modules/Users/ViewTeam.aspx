﻿<%@ Page Title="Lista Team" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewTeam.aspx.cs" Inherits="DFleet.Admin.Modules.Users.ViewTeam" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Lista Team</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/insTeam")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo</a> 
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
                                        <asp:TextBox ID="txtSearch" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Team"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>  
                      
                        <div class="col-md-2">
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

                <asp:GridView ID="gvRicTeam" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicTeam" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Team">
                            <ItemTemplate>
                                <%# Eval("team")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>                      
                                        
                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <%# Eval("stato")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='EditTeam-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip"  data-placement="left" title="" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicTeam" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectTeam" TypeName="BusinessLogic.AccountBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSearch" Name="keysearch" PropertyName="Text" Type="String" />
                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
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