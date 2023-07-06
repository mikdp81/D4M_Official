<%@ Page Title="Elenco Configurazioni" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="RichiesteOrdini.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.RichiesteOrdini" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Elenco Configurazioni</h3>
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
                                        
                        <asp:TemplateField HeaderText="Configurazione">
                            <ItemTemplate>
                                N. <%# Eval("numeroordine")%> <br />  <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="CarList">
                            <ItemTemplate>
                                <%# Eval("codcarlist")%>                     
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("marca")%><br /><%# Eval("modello")%><br /><%# ReturnData(Eval("dataconsegnaprevista").ToString()) %></div>                   
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Canone O.">
                            <ItemTemplate>
                                &euro; <%# Eval("deltacanone")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <%# Eval("statusordine")%>               
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='ViewConf-<%# Eval("Uid")%>' class='text-inverse p-r-10' data-toggle='tooltip' title='' data-placement="left" data-original-title='Visualizza Configurazione'><img src="../../../plugins/images/visualizza_configurazione.svg" class="icon20"/></a>
                                <%# ReturnAzioni(Eval("Uid").ToString(), Eval("idordine").ToString(), Eval("idstatusordine").ToString()) %>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectRichiesteOrdiniXDriver" TypeName="BusinessLogic.ContrattiBL">
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

        <div class="row">
            <div class="col-12">
                <asp:Label ID="lblTitoloOrdiniPool" runat="server" Text=""></asp:Label>
                
                <!-- Richieste Ordini Pool -->
                <asp:GridView ID="gvRicOrdiniPool" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicOrdiniPool" CssClass="display nowrap dataTable2" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>                        
                                        
                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="CarList">
                            <ItemTemplate>
                                <%# Eval("codcarlist")%>                     
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("marca")%><br /><%# Eval("modello")%></div>                   
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Canone O.">
                            <ItemTemplate>
                                &euro; <%# Eval("deltacanone")%>                     
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <%# Eval("statusordine")%>               
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='ViewConfPool-<%# Eval("Uid")%>' class='text-inverse p-r-10' data-toggle='tooltip' title='' data-placement="left" data-original-title='Visualizza Configurazione'><img src="../../../plugins/images/visualizza_configurazione.svg" class="icon20"/></a>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicOrdiniPool" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectRichiesteOrdiniPoolXDriver" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        </SelectParameters>
                </asp:ObjectDataSource>


                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage2" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                    <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                </asp:Panel>


            </div>
        </div>
    </div>
</div>


</asp:Content>