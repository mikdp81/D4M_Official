﻿<%@ Page Title="Richieste Ordini" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="RichiesteOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.RichiesteOrdini" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Richieste Ordini</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/InsOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo</a> 
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
                                        <asp:TextBox ID="txtSearch" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Auto"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCodSocieta" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsSoc"
                                    DataTextField="societa" DataValueField="codsocieta">
                                    <asp:ListItem Value="" Selected="True">Scegli Societa</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSoc" runat="server" DataObjectTypeName="BusinessObject.Utilitys" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                    DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="">Scegli Grade</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>  
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlStatusOrdini" runat="server" DataSourceID="odsstatusordini" DataTextField="statusordine" 
                                            DataValueField="idstatusordine" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1" Text="">Scegli Status Ordine</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsstatusordini" runat="server" SelectMethod="SelectAllStatusOrdineAdmin" TypeName="BusinessLogic.ContrattiBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">                                
                                <asp:DropDownList ID="ddlCodCarList" runat="server" DataSourceID="odscodcarlist" DataTextField="carlist" 
                                    DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="">Scegli CarList</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscodcarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlFornitore" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                            DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="">Scegli Fornitore</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL">
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
                                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data ordine dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data ordine al"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser" placeholder="Inserisci Driver"></asp:TextBox>
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
                <!-- Richieste Ordini -->
                <asp:GridView ID="gvRicOrdini" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicOrdini" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Ordine">
                            <ItemTemplate>
                                N. <%# Eval("numeroordine")%> <br />  <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Societ&agrave;">
                            <ItemTemplate>
                                <%# Eval("societa")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Driver">
                            <ItemTemplate>
                                <%# Eval("cognome")%> <%# Eval("nome")%><br />
                                (<%# Eval("matricola")%>)
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Grade / CarList">
                            <ItemTemplate>
                                <%# Eval("grade")%> <br /><%# Eval("codcarlist")%>                    
                            </ItemTemplate>
                        </asp:TemplateField>                       
                                        
                        <asp:TemplateField HeaderText="Fornitore">
                            <ItemTemplate>
                                <%# Eval("codfornitore")%>                     
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("marca")%><br /><%# Eval("modello")%></div>                  
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Opt. Canone">
                            <ItemTemplate>
                                <div class="text-right">&euro; <%# Eval("deltacanone")%></div>               
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <%# Eval("statusordine")%>    
                                <br /><span class="text-red"><%# ReturnData(Eval("dataconsegnaprevista").ToString()) %></span>           
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <%# ReturnAzioni(Eval("Uid").ToString(), Eval("idstatusordine").ToString()) %>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectRichiesteOrdini" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSearch" Name="keysearch" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="ddlCodSocieta" Name="codsocieta" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddlCodGrade" Name="codgrade" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddlCodCarList" Name="codcarlist" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddlFornitore" Name="codfornitore" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="txtDatadal" Name="datadal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtDataal" Name="dataal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="hdusers" DbType="Guid" Name="UserId" PropertyName="Value" />
                            <asp:ControlParameter ControlID="ddlStatusOrdini" Name="idstatusordine" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                            <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="hdusers" runat="server" />

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

<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js"></script>

<script type="text/javascript">  
    $(document).ready(function () {  
        $(".autouser").autocomplete({
            source: "../../../Handler/ListDriver.ashx",
            select: function (event, ui) {
                $("#ContentBody_txtUsers").val(ui.item.label);
                $("#ContentBody_hdusers").val(ui.item.value);
                return false;
            }
        });         
    });  
</script>

</asp:Content>