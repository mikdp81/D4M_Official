<%@ Page Title="Autorizzazioni dipendente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Autorizzazioni.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.Autorizzazioni" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Check Car Policy</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab" aria-expanded="true"><span class="visible-xs"><i class="ti-home"></i></span><span class="hidden-xs"> Da Approvare</span></a></li>
                    <li role="presentation" class=""><a href="#home2" aria-controls="home2" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Approvati</span></a></li>
                </ul>


                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="home">
                        <div class="col-md-12">
                          
                            <div class="form-body">
                                <div class="form-group row marginbottmnull">
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                                        DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000">Scegli Driver</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsersXSocieta" TypeName="BusinessLogic.AccountBL" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="hdcodsocietaapprovatore" Name="codsocieta" PropertyName="Value" Type="String" />
                                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
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
                                                    <asp:DropDownList ID="ddlCodCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
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

                                    <div class="col-md-2">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull"> 
                                                    <asp:DropDownList ID="ddlNRecord" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                            data-toggle="tooltip" data-placement="top" data-original-title="N.Record">
                                                        <asp:ListItem Value="50">50</asp:ListItem>
                                                        <asp:ListItem Value="100">100</asp:ListItem>
                                                        <asp:ListItem Value="200" Selected="True">200</asp:ListItem>
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
                                                    <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra" CssClass="btn btn-info" />
                                                    <asp:Button ID="btnSvuotaFiltri" runat="server" onclick="btnSvuotaFiltri_Click" Text="Svuota Filtri" CssClass="btn btn-info" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>                                    
                                </div>    
                            </div>

                            <div class="col-md-12 m-b-10">
                                <div class="col-md-2"> 
                                    <input type='checkbox' name='selectall' class='checkall_label' onclick="toggleChecked(this.checked);"> Seleziona tutti
                                </div>
                                <div class="col-md-3"> 
                                    <asp:Button ID="btnConcludi" runat="server" Text="Approva tutti i selezionati" OnClick="btnConcludi_Click" CssClass="btn btn-info" />
                                </div>
                            </div>

                            <!-- Lista Da Approvare -->
                            <asp:GridView ID="gvRicDaAppr" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsRicDaAppr" CssClass="display nowrap dataTable" 
                                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">   
                                        <ItemTemplate>
                                            <input id="chkiddelega" class="chkiddelega" type="checkbox" value='<%# Eval("Uid")%>' runat="server" />
                                        </ItemTemplate>                    
                                    </asp:TemplateField>  
                    
                                    <asp:TemplateField HeaderText="Driver">
                                        <ItemTemplate>
                                            <%# Eval("denominazione")%><br />
                                            <%# Eval("matricola")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>                      
                                                                       
                                    <asp:TemplateField HeaderText="Grade Anagrafico">
                                        <ItemTemplate>
                                            <%# Eval("grade")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="CarPolicy da assegnare">
                                        <ItemTemplate>
                                            <%# Eval("codcarpolicy")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                                              

                                    <asp:TemplateField HeaderText="Approvazione singola"> 
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hduidaut" runat="server" Value='<%# Eval("Uid")%>'  />
                                            <a href='EditAutorizzazione-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="left" data-original-title="Approva"><img src="../../../plugins/images/auto_check.svg" class="icon20" border="0" alt="" /></a>
                                        </ItemTemplate>                                
                                    </asp:TemplateField>     
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicDaAppr" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectUserCarPolicyDaApprovare" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCodCarPolicy" Name="carpolicy" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUsers" DbType="Guid" Name="UserId" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="hdcodsocietaapprovatore" Name="codsocieta" PropertyName="Value" Type="String" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                        <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                            </asp:ObjectDataSource>

                            <asp:HiddenField ID="hdcodsocietaapprovatore" runat="server" />

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
                   


                            <div class="form-body">
                                <div class="form-group row marginbottmnull">
                                    <div class="col-md-3">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group marginbottmnull">
                                                    <asp:DropDownList ID="ddlCarPolicy2" runat="server" CssClass="form-control select2 ddlCarPolicy2" AppendDataBoundItems="True"
                                                         DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                                        <asp:ListItem Selected="True" Value="" Text="Car Policy"></asp:ListItem>
                                                    </asp:DropDownList>
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

                            <!-- Lista Approvati -->
                            <asp:GridView ID="gvRicAppr" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsRicAppr" CssClass="display nowrap dataTable2" 
                                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">   
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>                    
                                    </asp:TemplateField>  
                    
                                    <asp:TemplateField HeaderText="Driver">
                                        <ItemTemplate>
                                       <a href='EditAutorizzazione-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" title="" data-placement="right" data-original-title="Dettaglio Autorizzazione"> 
                                        <b>   <%# Eval("denominazione")%>  </b>   
                                         </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>                      
                                        
                                    <asp:TemplateField HeaderText="CarPolicy">
                                        <ItemTemplate>
                                            <%# Eval("codcarpolicy")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Preassegnazione">
                                        <ItemTemplate>
                                            <%# Eval("preassegnazione")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Approvatore">
                                        <ItemTemplate>
                                            <%# Eval("cognome")%> <br />
                                            il <%# ReturnData(Eval("dataapprovazione").ToString()) %>                   
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Decorrenza">
                                        <ItemTemplate>
                                            <%# ReturnData(Eval("datadecorrenza").ToString()) %>                   
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Invio Mail">
                                        <ItemTemplate>
                                            <%# ReturnData(Eval("datamail").ToString()) %>                    
                                        </ItemTemplate>
                                    </asp:TemplateField>

                          
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicAppr" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectUserCarPolicyApprovati" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCarPolicy2" Name="keysearch" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="hdcodsocietaapprovatore" Name="codsocieta" PropertyName="Value" Type="String" />
                                        <asp:ControlParameter ControlID="ddlFlgMail" Name="flgmail" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                        <asp:ControlParameter ControlID="ddlNRecord2" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="hdPagina2" Name="pagina" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                            </asp:ObjectDataSource>

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
