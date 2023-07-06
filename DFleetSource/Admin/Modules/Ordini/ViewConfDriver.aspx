<%@ Page Title="Autorizzazioni dipendente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewConfDriver.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ViewConfDriver" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazioni Driver</h3>
            </div>	            	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/InsConfOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuova Configurazione</a>
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
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull"> 
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
                                        <asp:DropDownList ID="ddlCodSocieta" runat="server" DataSourceID="odscodsocieta" DataTextField="societa" 
                                        DataValueField="codsocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Societa"></asp:ListItem>
                                    </asp:DropDownList>     
                                    <asp:ObjectDataSource ID="odscodsocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
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
                                        <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser" placeholder="Inserisci Driver"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
                                                DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                            <asp:ListItem Selected="True" Value="" Text="Car Policy"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscarpolicy" runat="server" SelectMethod="SelectAllCarPolicy" TypeName="BusinessLogic.CarsBL">
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
                                        <asp:DropDownList ID="ddlFlgMail" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                data-toggle="tooltip" data-placement="top" data-original-title="Invio Mail">
                                            <asp:ListItem Value="-1">TUTTI</asp:ListItem>
                                            <asp:ListItem Value="1">INVIATO</asp:ListItem>
                                            <asp:ListItem Value="0">NON INVIATO</asp:ListItem>
                                        </asp:DropDownList>
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

                <asp:GridView ID="gvRicAppr" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicAppr" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Driver">
                            <ItemTemplate>
                                <%# Eval("denominazione")%> <br />
                                <%# Eval("matricola")%> <br />
                                <%# Eval("grade")%>
                            </ItemTemplate>
                        </asp:TemplateField>                      
                                        
                        <asp:TemplateField HeaderText="CarPolicy">
                            <ItemTemplate>
                                <%# Eval("codcarpolicy")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  
                                    
                        <asp:TemplateField HeaderText="CarBenefit">
                            <ItemTemplate>
                                <%# Eval("codcarbenefit")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Scelta Benefit">
                            <ItemTemplate>
                                <%# Eval("codpacchetto")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Società">
                            <ItemTemplate>
                                <%# Eval("societa")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Preass">
                            <ItemTemplate>
                                <%# Eval("preassegnazione")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Approvato">
                            <ItemTemplate>
                                <%# ReturnData(Eval("dataapprovazione").ToString()) %> <br />                                
                                <%# ReturnData(Eval("datamail").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Decorrenza">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datadecorrenza").ToString())%> <br />
                                <%# ReturnData(Eval("datafinedecorrenza").ToString()) %>                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Motivazione">
                            <ItemTemplate>
                                <%# Eval("motivazione")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>    

                        <asp:TemplateField HeaderText="Accetta">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datadocpolicy").ToString()) %>                          
                            </ItemTemplate>
                        </asp:TemplateField>                                    

                        <asp:TemplateField HeaderText="Rinuncia">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datarinuncia").ToString()) %>                    
                            </ItemTemplate>
                        </asp:TemplateField> 
                                 
                        <asp:TemplateField HeaderText="Azioni">
                            <ItemTemplate>
                                <a href="EditConfOrdini-<%# Eval("Uid")%>" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Modifica"><img src="../../../plugins/images/ico_modify.svg" class="icon20" border="0" alt="" /></a>     
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicAppr" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectUserCarPolicyPageAdmin" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCodSocieta" Name="codsocieta" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddlCarPolicy" Name="carpolicy" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="hdusers" DbType="Guid" Name="UserId" PropertyName="Value" />
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
            <div class="clearfix"></div>
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