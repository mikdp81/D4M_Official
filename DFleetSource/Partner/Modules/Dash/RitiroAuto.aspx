<%@ Page Title="Ritiro Auto" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="RitiroAuto.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.RitiroAuto" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ritiro Auto</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <!-- Ritiro Auto -->
                <asp:GridView ID="gvRicOrdini" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicOrdini" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>                        
                                          
                        <asp:TemplateField HeaderText="Targa">
                            <ItemTemplate>
                                <%# Eval("targa")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("modello")%></div>                    
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Societ&agrave;">
                            <ItemTemplate>
                                <%# Eval("societa")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>                                               

                        <asp:TemplateField HeaderText="Data e Ora Consegna">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataconsegna")) %>                                
                                <%# Eval("oraconsegna")%>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Luogo Consegna">
                            <ItemTemplate>
                                <%# Eval("luogoconsegna")%>               
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='RichiestaAuto-<%# Eval("idassegnazione")%>' class='text-inverse p-r-10' data-toggle='tooltip'>Allega Documenti</a>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectOrdiniContrattualizzati" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        </SelectParameters>
                </asp:ObjectDataSource>

                
                <asp:HiddenField ID="hdiduser" runat="server" />

                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


            </div>
        </div>
    </div>




</div>


</asp:Content>