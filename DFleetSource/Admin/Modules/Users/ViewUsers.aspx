<%@ Page Title="Lista Utenti" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind  ="ViewUsers.aspx.cs" Inherits="DFleet.Admin.Modules.Users.ViewUsers" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Lista Utenti</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/InsUserRobot")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo 2</a> 
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/insUser")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo</a> 
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
                                        <asp:ListItem Value="cognome">Cognome</asp:ListItem>
                                        <asp:ListItem Value="nome">Nome</asp:ListItem>
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
        <div class="row ">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Nome / Cognome / Matricola"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>                                
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">                                                        
                                        <asp:DropDownList ID="ddlgruppo" runat="server" DataSourceID="odsgruppo" DataTextField="gruppouser" 
                                            DataValueField="idgruppouser" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Ruolo"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsgruppo" runat="server" DataObjectTypeName="BusinessObject.Account" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="SelectGruppi" 
                                            TypeName="BusinessLogic.AccountBL">
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
                                        <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statusutente" 
                                            DataValueField="idstatususer" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Status"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsstatus" runat="server" DataObjectTypeName="BusinessObject.Account" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="SelectStatus" 
                                            TypeName="BusinessLogic.AccountBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
              
                      
                        <div class="col-md-3  text-right">
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

                <asp:GridView ID="gvRicUsers" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicUsers" CssClass="display nowrap dataTable" 
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

                        <asp:TemplateField HeaderText="Società">
                            <ItemTemplate>
                                 <%# Eval("codsocieta")%>
                            </ItemTemplate>
                        </asp:TemplateField>   
                    
                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate>
                                 <%# Eval("gradecode")%>
                            </ItemTemplate>
                        </asp:TemplateField>    
                    
                        <asp:TemplateField HeaderText="Ruolo">
                            <ItemTemplate>
                                 <%# Eval("gruppouser")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%# Eval("statusutente")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='Edit-<%# Eval("UserId")%>' data-toggle="tooltip" data-placement="left" title="" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                                <a href='Storico-<%# Eval("UserId")%>' data-toggle="tooltip" data-placement="left" title="" data-original-title="Storico"><img src="../../../plugins/images/storico_auto_black.svg" class="icon20" border="0" alt="" /></a>
                                <a href='RinnovaConf-<%# Eval("UserId")%>' data-toggle="tooltip" data-placement="left" title="" data-original-title="Rinnova Configurazione"><img src="../../../plugins/images/autorizza.svg" class="icon20" border="0" alt="" /></a>                             
                             </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicUsers" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectUsername" TypeName="BusinessLogic.AccountBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtUsers" Name="userName" PropertyName="Text" Type="String" />
                            <asp:ControlParameter Name="idstatususer" Type="Int32" ControlID="ddlstatus" PropertyName="SelectedValue" />
                            <asp:ControlParameter Name="idgruppouser" Type="Int32" ControlID="ddlgruppo" PropertyName="SelectedValue" />
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