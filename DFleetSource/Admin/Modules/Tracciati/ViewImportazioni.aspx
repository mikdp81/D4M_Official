<%@ Page Title="Importazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewImportazioni.aspx.cs" Inherits="DFleet.Admin.Modules.Tracciati.ViewImportazioni" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Importazioni</h3>
            </div>			
            <div class="col-md-5 text-right">
                <a href="Importa" class="btn btn-info">Nuova Importazione</a>
            </div>			
        </div>
    </div>

    <div class="row m-b-20">
        <div class="col-md-12 text-right"> 
             <a class="btn btn-filter svg-icon-30 svg-icon-filter" ID="btnFiltra" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Filtra"></a>
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
                                        <asp:DropDownList ID="ddlTipoFile" runat="server" DataSourceID="odstipofile" DataTextField="tipofile" 
                                            DataValueField="idtipofile" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Tipo Importazione"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odstipofile" runat="server" SelectMethod="SelectTipoFile" TypeName="BusinessLogic.FileTracciatiBL" >
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
                                        <asp:TextBox ID="txtNomefile" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Nome file"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data dal"></asp:TextBox>                                    
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data al"></asp:TextBox> 
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

                <asp:GridView ID="gvImpo" runat="server" AutoGenerateColumns="False" DataSourceID="odsImpo" CssClass="display nowrap dataTable" 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Tipo Importazione">
                            <ItemTemplate>
                                <%# Eval("tipofile")%>                
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                                <span class="text-break width200"><%# Eval("nomefile")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Generato il">
                            <ItemTemplate>
                               <%# Eval("datacaricato", "{0:dd/MM/yyyy}")%>                    
                            </ItemTemplate>
                        </asp:TemplateField>   
                    
                        <asp:TemplateField HeaderText="Esito">
                            <ItemTemplate>
                                <%# Eval("importato")%><br />
                                Importate N. righe <%# Eval("righeimportate")%> su <%# Eval("righetotali")%>
                            </ItemTemplate>
                        </asp:TemplateField>   
    
                        <asp:TemplateField HeaderText="Dettagli">
                            <ItemTemplate>                            
                                <a href="DetailImport-<%# Eval("idprog")%>" class="text-inverse p-r-10" data-toggle="tooltip" data-placement="left" title="" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Importa">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdimportato"  Value='<%#Eval("importato") %>' runat="server"></asp:HiddenField>  
                                <asp:HiddenField ID="hdidprog"  Value='<%#Eval("idprog") %>' runat="server"></asp:HiddenField>   
                            
                                <input type="button" class="btn btn-success" runat="server" onserverclick="btnAggiorna_Click" id="btnAggiorna" value="Aggiorna" />
                                <asp:Button ID="btnImporta" runat="server" OnCommand="btnImporta_Click" CommandArgument='<%# Eval("idprog") %>' Text="Importa" CssClass="btn btn-success" />
                            </ItemTemplate>
                        </asp:TemplateField>                         
                    </Columns>    
                    <PagerStyle HorizontalAlign="right" /> 
                </asp:GridView>

                <asp:ObjectDataSource ID="odsImpo" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectImportazioni" TypeName="BusinessLogic.FileTracciatiBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlTipoFile" Name="idtipofile" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="txtNomefile" Name="nomefile" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtDatadal" Name="datadal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataal" Name="dataal" PropertyName="Text" Type="DateTime" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                
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