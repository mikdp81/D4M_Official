<%@ Page Title="Dimissionari" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewDimissionari.aspx.cs" Inherits="DFleet.Admin.Modules.Car.ViewDimissionari" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Dimissionari</h3>
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
                                        <asp:TextBox ID="txtDriver" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Nominativo o Matricola"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                            DataValueField="grade" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Value="" Text="Grade"></asp:ListItem>
                                        </asp:DropDownList> 
                                        <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
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
                                        <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                            DataValueField="siglasocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Value="" Text="Societa"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odssocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL" >
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
                                        <asp:TextBox ID="txtFornitore" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Fornitore"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataAssdal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data assunzione dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataAssal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data assunzione al"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataPresDimdal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data dimissioni dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataPresDimal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data dimissioni al"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">                                        
                                        <asp:DropDownList ID="ddlAutoParco" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                data-toggle="tooltip" data-placement="top" data-original-title="Auto in parco">
                                            <asp:ListItem Value="">Tutte</asp:ListItem>
                                            <asp:ListItem Value="SI">SI</asp:ListItem>
                                            <asp:ListItem Value="NO">NO</asp:ListItem>
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

                <asp:GridView ID="gvRicDim" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicDim" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Cognome">
                            <ItemTemplate>
                                <%# Eval("cognome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <%# Eval("nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Matricola">
                            <ItemTemplate>
                                <%# Eval("matricola")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate>
                                <%# Eval("grade")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sigla <br />societa">
                            <ItemTemplate>
                                <%# Eval("siglasocieta")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data <br />assunzione">
                            <ItemTemplate>
                                <%# ReturnData(Eval("dataassunzione").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data prevista <br />dimissione">
                            <ItemTemplate>
                                <%# ReturnData(Eval("dataprevistadimissione").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data <br />dimissioni">
                            <ItemTemplate>
                               <%# ReturnData(Eval("datadimissioni").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data <br />carpolicy">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datadocpolicy").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ordine <br />Pending">
                            <ItemTemplate>
                                <%# Eval("ordinecorrente")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data <br />ordine">
                            <ItemTemplate>
                                <%# ReturnData(Eval("dataordine").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status<br />ordine ">
                            <ItemTemplate>
                                <%# ReturnData(Eval("ordinestatus").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Auto <br />in parco">
                            <ItemTemplate>
                                <%# Eval("Note")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Targa">
                            <ItemTemplate>
                                <%# Eval("targa")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fornitore">
                            <ItemTemplate>
                                <%# Eval("fornitore")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data inizio<br /> contratto">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datainiziocontratto").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data inizio<br /> uso">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datainiziouso").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data fine<br /> contratto">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datafinecontratto").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Durata">
                            <ItemTemplate>
                                <%# Eval("mesicontratto")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Canone <br />leasing">
                            <ItemTemplate>
                                <%# ReturnCanone(Eval("canoneleasing").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importo <br />forfettario">
                            <ItemTemplate>
                                <%# Eval("importoforfettario")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penale <br />Ordine">
                            <ItemTemplate>
                                <%# Eval("penaleordine")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penale<br /> Ritiro">
                            <ItemTemplate>
                                <%# Eval("penaleritiro")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penale sede <br />restituzione">
                            <ItemTemplate>
                                <%# Eval("erratasederestituzione")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penale cambio <br />gomme">
                            <ItemTemplate>
                                <%# Eval("erratarestituzionegomme")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penale mancata<br /> denuncia ">
                            <ItemTemplate>
                                <%# Eval("penaledenuncia")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Canone <br />optional">
                            <ItemTemplate>
                                <%# Eval("canoneoptional")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mesi <br />residui">
                            <ItemTemplate>
                                <%# Eval("mesiresidui")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Residuo <br />optional">
                            <ItemTemplate>
                                <%# Eval("residuooptional")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Multe">
                            <ItemTemplate>
                                <%# Eval("multe")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fuel">
                            <ItemTemplate>
                                <%# Eval("fuel")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rimborso <br />concur">
                            <ItemTemplate>
                                <%# Eval("rimborsoconcur")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spese <br />amministrative">
                            <ItemTemplate>
                                <%# Eval("speseamministrative")%>
                            </ItemTemplate>
                        </asp:TemplateField>                            
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicDim" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectDimissionari" TypeName="BusinessLogic.CarsBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDriver" Name="nominativo" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="ddlCodGrade" Name="codgrade" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlCodsocieta" Name="codsocieta" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txtFornitore" Name="codfornitore" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtDataAssdal" Name="dataassdal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataAssal" Name="dataassal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataPresDimdal" Name="datapresdimdal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataPresDimal" Name="datapresdimal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="ddlAutoParco" Name="totautoparc" PropertyName="SelectedValue" Type="String" />
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