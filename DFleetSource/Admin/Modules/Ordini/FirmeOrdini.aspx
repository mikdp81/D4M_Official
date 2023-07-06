<%@ Page Title="Ordini da firmare" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="FirmeOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.FirmeOrdini" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ordini da firmare</h3>
            </div>			
        </div>
    </div>



    <div class="white-box">
        <div class="row ">
            <div class="col-12">
                
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab" aria-expanded="true"><span class="visible-xs"><i class="ti-home"></i></span><span class="hidden-xs"> Da Firmare</span></a></li>
                    <li role="presentation" class=""><a href="#home2" aria-controls="home2" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Firmati</span></a></li>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="home">
                        <div class="col-md-12">
                            <h3>Da Firmare</h3>
                            

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
                                                    <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser" placeholder="Scegli Driver"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
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
                                            <div class="col-md-10">
                                                <div class="form-group marginbottmnull">
                                                    <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra" CssClass="btn btn-info" />
                                                    <asp:Button ID="btnSvuotaFiltri" runat="server" onclick="btnSvuotaFiltri_Click" Text="Svuota Filtri" CssClass="btn btn-info" />
                                                </div>
                                            </div>
                                            <div class="col-md-2 text-right">                                                
                                                <asp:Button ID="btnFirmaMultipla" runat="server" Text="Firma Multipla" CssClass="btn btn-info" OnClick="btnFirmaMultipla_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>    
                            </div>



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

                                  
                                    <asp:TemplateField HeaderText="Driver">
                                        <ItemTemplate>
                                            <%# Eval("societa")%>     <br /> 
                                            <%# Eval("denominazione")%><br />
                                            (<%# Eval("matricola")%>)
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Grade / CarList">
                                        <ItemTemplate>
                                            <%# Eval("grade")%> <br /><%# Eval("codcarlist")%>                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                
                                        
                                    <asp:TemplateField HeaderText="Auto">
                                        <ItemTemplate>
                                              <%# Eval("fornitore")%>    <br />
                                             <div class="text-break width300"><%# Eval("marca")%><br /><%# Eval("modello")%></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                        
                                    <asp:TemplateField HeaderText="Opt. Can.">
                                        <ItemTemplate>
                                            <%# Eval("deltacanone")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                        
                                    <asp:TemplateField HeaderText="Azioni"> 
                                        <ItemTemplate>
                                            <a href="EditConferma-<%# Eval("Uid")%>" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Firma Automatica"><img src="../../../plugins/images/firma_e_conferma.svg" class="icon20" border="0" alt="" /></a>
                                            <a href="EditConferma2-<%# Eval("Uid")%>" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Firma Manuale"><img src="../../../plugins/images/mano_sx.png" class="icon20" border="0" alt="" /></a>
                                            <a href="../../../Repository/ordini/<%# Eval("fileordinepdf")%>" target="_blank" class="text-inverse p-r-10" data-placement="left" data-toggle="tooltip" title="" data-original-title="Visualizza File Ordine"><img src="../../../plugins/images/visualizza_file_ordine.svg" class="icon20" border="0" alt="" /></a>
                                        </ItemTemplate>                                
                                    </asp:TemplateField>     
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectOrdiniDaFirmare" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtSearch" Name="keysearch" PropertyName="Text" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodSocieta" Name="codsocieta" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodGrade" Name="codgrade" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodCarList" Name="codcarlist" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlFornitore" Name="codfornitore" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="txtDatadal" Name="datadal" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="txtDataal" Name="dataal" PropertyName="Text" Type="DateTime" />
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
                    <div role="tabpanel" class="tab-pane" id="home2">
                        <div class="col-md-12">
                            <h3>Firmati</h3>



                            <div class="form-body">
                                <div class="form-group row marginbottmnull">
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:TextBox ID="txtSearch2" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Auto"></asp:TextBox> 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlCodSocieta2" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsSoc"
                                                DataTextField="societa" DataValueField="codsocieta">
                                                <asp:ListItem Value="" Selected="True">Scegli Societa</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlCodGrade2" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                                DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="">Scegli Grade</asp:ListItem>
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">                                
                                            <asp:DropDownList ID="ddlCodCarList2" runat="server" DataSourceID="odscodcarlist" DataTextField="carlist" 
                                                DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="">Scegli CarList</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div> 
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:DropDownList ID="ddlFornitore2" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                                        DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="">Scegli Fornitore</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:TextBox ID="txtDatadal2" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data ordine dal"></asp:TextBox> 
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:TextBox ID="txtDataal2" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data ordine al"></asp:TextBox> 
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:TextBox ID="txtUsers2" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser2" placeholder="Scegli Driver"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="col-md-2">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull"> 
                                                    <asp:DropDownList ID="ddlNRecord2" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                            data-toggle="tooltip" data-placement="top" data-original-title="N.Record">
                                                        <asp:ListItem Value="50">50</asp:ListItem>
                                                        <asp:ListItem Value="100">100</asp:ListItem>
                                                        <asp:ListItem Value="200">200</asp:ListItem>
                                                        <asp:ListItem Value="500">500</asp:ListItem>
                                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                                        <asp:ListItem Value="2000">2000</asp:ListItem>
                                                        <asp:ListItem Value="5000">5000</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdPagina2" runat="server" Value="" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>  
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:Button ID="btnCerca2" runat="server" onclick="btnCerca2_Click" Text="Filtra" CssClass="btn btn-info" />
                                                    <asp:Button ID="btnSvuotaFiltri2" runat="server" onclick="btnSvuotaFiltri_Click" Text="Svuota Filtri" CssClass="btn btn-info" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>    
                            </div>


                            

                            <asp:GridView ID="gvOrdini2" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsRicOrdini2" CssClass="display nowrap dataTable2" 
                                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                <Columns>

                                    <asp:TemplateField HeaderText="Ordine">
                                        <ItemTemplate>
                                            N. <%# Eval("numeroordine")%> <br />  <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                  
                                    <asp:TemplateField HeaderText="Driver">
                                        <ItemTemplate>
                                            <%# Eval("societa")%>     <br /> 
                                            <%# Eval("denominazione")%><br />
                                            (<%# Eval("matricola")%>)
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Grade / CarList">
                                        <ItemTemplate>
                                            <%# Eval("grade")%> <br /><%# Eval("codcarlist")%>                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                
                                        
                                    <asp:TemplateField HeaderText="Auto">
                                        <ItemTemplate>
                                              <%# Eval("fornitore")%>    <br />
                                             <div class="text-break width300"><%# Eval("marca")%><br /><%# Eval("modello")%></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                        
                                    <asp:TemplateField HeaderText="Opt. Can.">
                                        <ItemTemplate>
                                            <%# Eval("deltacanone")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                        
                                    <asp:TemplateField HeaderText="Azioni"> 
                                        <ItemTemplate>
                                            <a href="../../../DownloadFile?type=ordini&nomefile=<%# Eval("filefirma")%>" target="_blank" class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Visualizza File Firmato"><img src="../../../plugins/images/visualizza_file_ordine.svg" class="icon20" border="0" alt="" /></a>
                                        </ItemTemplate>                                
                                    </asp:TemplateField>     
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicOrdini2" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectOrdiniFirmati" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtSearch2" Name="keysearch" PropertyName="Text" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodSocieta2" Name="codsocieta" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodGrade2" Name="codgrade" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlCodCarList2" Name="codcarlist" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlFornitore2" Name="codfornitore" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="txtDatadal2" Name="datadal" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="txtDataal2" Name="dataal" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="hdusers2" DbType="Guid" Name="UserId" PropertyName="Value" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                        <asp:ControlParameter ControlID="ddlNRecord2" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="hdPagina2" Name="pagina" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdusers2" runat="server" />

                            <div class="dataTables_wrapper">
                                <div class="dataTables_info">
                                    <asp:Label ID="lblNumRecord2" runat="server" Text=""></asp:Label>       
                                </div>            

                                <div class="dataTables_paginate paging_simple_numbers">
                                    <asp:LinkButton ID="pagingprec2" runat="server" OnClick="pagingprec2_Click" CssClass="paginate_button"><</asp:LinkButton>
                                    <asp:TextBox ID="txtnumpag2" runat="server" Text="1" style="width:50px;text-align:center;" OnTextChanged="txtnumpag2_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                                    <asp:LinkButton ID="pagingnext2" runat="server" OnClick="pagingnext2_Click" CssClass="paginate_button">></asp:LinkButton>
                                </div>
                            </div>

                            <!-- Visualizzazione Errori -->
                            <asp:Panel ID="pnlMessage2" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                                <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="clearfix"></div>



                    </div>               

                </div>


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

        $(".autouser2").autocomplete({
            source: "../../../Handler/ListDriver.ashx",
            select: function (event, ui) {
                $("#ContentBody_txtUsers2").val(ui.item.label);
                $("#ContentBody_hdusers2").val(ui.item.value);
                return false;
            }
        });  
    });  
</script>

</asp:Content>