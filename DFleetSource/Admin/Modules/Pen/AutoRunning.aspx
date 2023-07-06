<%@ Page Title="Auto In Running" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="AutoRunning.aspx.cs" Inherits="DFleet.Admin.Modules.Pen.AutoRunning" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Auto In Running</h3>
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
                                        <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                            DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
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
                                        <asp:TextBox ID="txtMarca" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Marca"></asp:TextBox> 
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
                                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data contratto dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data contratto al"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">                                        
                                        <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statuscontratto" 
                                            DataValueField="idstatuscontratto" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Status Contratto"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusContratto" TypeName="BusinessLogic.ContrattiBL">
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

                <asp:GridView ID="gvRicRunning" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicRunning" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Targa" >
                            <ItemTemplate>
                              <a href='DetailAuto-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" data-placement="right" title="" data-original-title="Dettagli Auto"> <b class="text-verde"><%# Eval("targa")%></b></a>
                            </ItemTemplate>
                        </asp:TemplateField>                                       
                                        
                        <asp:TemplateField HeaderText="CarPolicy">
                            <ItemTemplate>
                               <%# Eval("codcarpolicy")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Modello">
                            <ItemTemplate>
                                <div class="text-break width200"><%# Eval("modello")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>                   
                    
                        <asp:TemplateField HeaderText="Driver">
                            <ItemTemplate>
                                  <div class="text-break width200"><b> <%# Eval("cognome")%></b></div>
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="O. Canone">
                            <ItemTemplate>
                            <div class="text-right">    <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("deltacanone")) %>   </div>             
                            </ItemTemplate>
                        </asp:TemplateField>                  
                                        
                        <asp:TemplateField HeaderText="Fringe">
                            <ItemTemplate>
                             <div class="text-right">    <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("fringebenefit")) %>  </div>              
                            </ItemTemplate>
                        </asp:TemplateField>       

                        <asp:TemplateField HeaderText="Km">
                            <ItemTemplate>
                               <div class="text-right"> <%# Eval("kmpercorsi")%>   </br>
                                (<%# Eval("kmcontratto")%>)</div>
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
                             
                        <asp:TemplateField HeaderText="Scadenza">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datafinecontratto")) %>                  
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
     
                                      
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicRunning" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectRunningTeamAppr" TypeName="BusinessLogic.ContrattiBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                        <asp:ControlParameter ControlID="ddlUsers" DbType="Guid" Name="UserId" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="txtMarca" Name="marca" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtModello" Name="modello" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtDatadal" Name="datacontrattodal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataal" Name="datacontrattoal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="ddlstatus" Name="idstatuscontratto" PropertyName="SelectedValue" Type="Int32" />
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

<asp:HiddenField ID="hdcodsocieta" runat="server" />


</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js">  
  
</script>

</asp:Content>