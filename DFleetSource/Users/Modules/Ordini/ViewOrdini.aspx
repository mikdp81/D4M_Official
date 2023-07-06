<%@ Page Title="Ordini Autorizzati" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ViewOrdini.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ViewOrdini" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ordini Autorizzati</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtSearch" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Auto/Codjatoauto"></asp:TextBox> 
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
                    
                        <asp:TemplateField HeaderText="Societ&agrave;">
                            <ItemTemplate>
                                <%# Eval("societa")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Driver">
                            <ItemTemplate>
                                <%# Eval("denominazione")%>
                                (<%# Eval("matricola")%>)
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate>
                                <%# Eval("grade")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>                      
                                        
                        <asp:TemplateField HeaderText="CarList">
                            <ItemTemplate>
                                <%# Eval("codcarlist")%>                     
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <%# Eval("modello")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Optional Canone">
                            <ItemTemplate>
                                <%# Eval("deltacanone")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Numero Ordine">
                            <ItemTemplate>
                                <%# Eval("numeroordine")%>               
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <%# Eval("statusordine")%>           
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='EditConferma-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Conferma"><i class="ti-marker-alt"></i></a>
                                <a href='EditScarta-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" title="" data-original-title="Scarta"><i class="ti-marker-alt"></i></a>
                            </ItemTemplate>                                
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectRichiesteOrdiniDriver" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSearch" Name="keysearch" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="ddlUsers" Name="UserId" PropertyName="SelectedValue" DbType="Guid" />
                            <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                </asp:ObjectDataSource>

                <asp:HiddenField ID="hduiduser" runat="server" />

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