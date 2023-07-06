<%@ Page Title="Storico Utente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Storico.aspx.cs" Inherits="DFleet.Admin.Modules.Users.Storico" %>
<%@ Import Namespace="System.Globalization" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="row white-box">
        <div class="col-md-7">
            <h3 class="box-title m-b-0">Storico Utente</h3>
        </div>
        <div class="col-md-5 text-right">
            <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewUsers")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
        </div>
    </div>

    <div class="row">
        <div class="col-12">

            <asp:Panel ID="pnlMessage" runat="server">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>


            <div class="vtabs">
                <ul class="nav tabs-vertical">
                    <li class="tab active">
                        <a data-toggle="tab" href="#auto" aria-expanded="true" ><span class="hidden-xs active svg-icon-30L svg-icon-profilo p-l-30 ">Auto</span> </a>
                    </li>
                    <li class="tab">
                        <a data-toggle="tab" href="#ordini" aria-expanded="false"> <span class="hidden-xs  svg-icon-30L svg-icon-lavoro p-l-30">Ordini</span> </a>
                    </li>
                    <li class="tab">
                        <a aria-expanded="false" data-toggle="tab" href="#fuelcard">  <span class="hidden-xs  svg-icon-30L svg-icon-dots p-l-30">Fuel Card</span> </a>
                    </li>
                </ul>

                <div class="white-box  m-l-20">
                    <div class="tab-content">
                        <div id="auto" class="tab-pane active">                                 

                            
                            <asp:GridView ID="gvRicRunning" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsRicRunning" CssClass="display nowrap dataTable" 
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
                                        
                                    <asp:TemplateField HeaderText="CarPolicy">
                                        <ItemTemplate>
                                           <%# Eval("codcarpolicy")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                    
                                    <asp:TemplateField HeaderText="Modello">
                                        <ItemTemplate>
                                            <%# Eval("modello")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>                   
                                            
                                    <asp:TemplateField HeaderText="Optional Canone">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("deltacanone")) %>                
                                        </ItemTemplate>
                                    </asp:TemplateField>                  
                                        
                                    <asp:TemplateField HeaderText="Fringe">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("fringebenefit")) %>                
                                        </ItemTemplate>
                                    </asp:TemplateField>       

                                    <asp:TemplateField HeaderText="Km Percorsi">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("kmpercorsi")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                        
                                    <asp:TemplateField HeaderText="Data Contratto">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datacontratto")) %>                   
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                        
                                    <asp:TemplateField HeaderText="Data Scadenza">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datafinecontratto")) %>                  
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Assegnato dal">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("assegnatodal")) %>                      
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                        
                                    <asp:TemplateField HeaderText="Assegnato al">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("assegnatoal")) %>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>                        
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicRunning" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAutoUser" TypeName="BusinessLogic.ContrattiBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                </SelectParameters>
                            </asp:ObjectDataSource>  


                        </div> 

                        <div id="ordini" class="tab-pane">                                      
                  

                            <asp:GridView ID="gvRicOrdini" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsRicOrdini" CssClass="display nowrap dataTable2" 
                                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">   
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
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
                                            <div class="text-break width300"><%# Eval("modello")%></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                        
                                    <asp:TemplateField HeaderText="Optional Canone">
                                        <ItemTemplate>
                                            <div class="text-right"><%# Eval("deltacanone")%></div>                     
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Data e Num. Ordine">
                                        <ItemTemplate>
                                            N. <%# Eval("numeroordine")%> del  <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("dataordine")) %>                  
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Stato">
                                        <ItemTemplate>
                                            <%# Eval("statusordine")%>               
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRicOrdini" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectOrdiniUser" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                    </SelectParameters>
                            </asp:ObjectDataSource>

                        </div>                       
                                   
                                   
                        <div id="fuelcard" class="tab-pane">                            

                            <asp:GridView ID="gvFuelCard" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsFuelCard" CssClass="display nowrap dataTable3" 
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
                        
                                    <asp:TemplateField HeaderText="Numero">
                                        <ItemTemplate>
                                            <%# Eval("numerodocumento")%>                     
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Scadenza">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datains")) %>                    
                                        </ItemTemplate>
                                    </asp:TemplateField> 
  
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsFuelCard" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectFuelCardUser" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                    </SelectParameters>
                            </asp:ObjectDataSource> 

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<asp:HiddenField ID="hdiduser" runat="server" /> 

</asp:Content>