<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.Dashboard1" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<%--<a href="DashboardReact2">React</a>--%>

<% if (Approvatore() == 2) {  // DASHBOARD HR %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2 ">
            <div class="white-box bg-black height200">
                <asp:Literal ID="ltLogo" runat="server"></asp:Literal>                        
            </div>
        </div>
    
        <div class="col-md-8">
            <div class="row" >
                <div class="row" >
                    <div class="col-md-4">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12"> </p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold "><asp:Label ID="Label2" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-white font-light"><asp:Label ID="Label3" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12"> </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="font-bold text-verde"><asp:Label ID="Label4" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12"></p> 
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>


        <div class="col-md-1"></div>
           
    </div>          
</div>

<% } %>





<% if (Approvatore() == 1) {  // DASHBOARD APPROVATORE %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2 ">
            <div class="white-box bg-black height200">
                <asp:Literal ID="ltLogo2" runat="server"></asp:Literal>                          
            </div>
        </div>
    
        <div class="col-md-8">
            <div class="row" >
                <div class="row" >
                    <div class="col-md-4">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="lblcarpolicydaautorizzare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">CarPolicy da autorizzare </p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold "><asp:Label ID="lblcarpolicyinviaremail" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">CarPolicy da inviare mail</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-white font-light"><asp:Label ID="lblconfigurazionidaautorizzarepp" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Configurazioni da autorizzare </p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-verde"><asp:Label ID="lblautorunning" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in running</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-verde"><asp:Label ID="lblautopool" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in pool</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="font-bold text-verde"><asp:Label ID="lblordini" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ordini in corso</p> 
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>


        <div class="col-md-1"></div>
           
    </div>          
</div>

<% } %>




<% if (Approvatore() == 0) {  // DASHBOARD ADMIN %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2 ">
            <div class="white-box bg-black height310">
                <asp:Literal ID="ltLogo3" runat="server"></asp:Literal>                       
            </div>
        </div>
                  
        <div class="col-md-8">
            <div class="row" >
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="lblticketaperti" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket aperti</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-verde"><asp:Label ID="lblticketlavorazione" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket in lavorazione</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-white font-light"><asp:Label ID="lblticketchiusi" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket chiusi</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="text-white font-light"><asp:Label ID="lblticketcancellati" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket cancellati</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-verde">
                                    <asp:Label ID="lblcarpolicypep" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Carpolicy P&amp;P</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-verde"><asp:Label ID="lblconfigurazionidaautorizzare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Configurazioni P&amp;P</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-verde"><asp:Label ID="lblconfermedafirmare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ordini da firmare</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="font-bold text-verde"><asp:Label ID="lbldeleghedafirmare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Deleghe/ZTL da firmare</p>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-verde">
                                    <asp:Label ID="lblinoffertarenter" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">In offerta renter</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-red"><asp:Label ID="lbloffertedainviareadriver" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Offerte da inviare a driver</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-verde font-bold"><asp:Label ID="lbloffertevalutazione" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Offerte in valutazione driver</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="text-white font-light"><asp:Label ID="lblordinievasione" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ordini in evasione</p>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="lblcarpolicydacontrollare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">CarPolicy da controllare</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-red"><asp:Label ID="lblautoritiro" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in ritiro</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblautoconsegna" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in consegna</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblfringebenefitdacalcolare" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Fringe benefit da calcolare</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div class="col-md-1"></div>
           
    </div>          
</div>


<% } %>


 






<% if (Approvatore() == 3) {  // DASHBOARD PARTNER %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2 ">
            <div class="white-box bg-black height310">
                <asp:Literal ID="ltLogo4" runat="server"></asp:Literal>                          
            </div>
        </div>
                  
        <div class="col-md-8">
            <div class="row" >
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="lblticketapertiPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket aperti</p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-verde"><asp:Label ID="lblticketlavorazionePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket in lavorazione</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-white font-light"><asp:Label ID="lblticketchiusiPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket chiusi</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="text-white font-light"><asp:Label ID="lblticketcancellatiPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ticket cancellati</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-verde"><asp:Label ID="lblconfermedafirmarePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ordini da firmare</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="text-white font-light"><asp:Label ID="lblordinievasionePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Ordini in evasione</p>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="font-bold text-verde"><asp:Label ID="lbldeleghedafirmarePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Deleghe/ZTL da firmare</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblfringebenefitdacalcolarePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Fringe benefit da calcolare</p>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-red"><asp:Label ID="lblautoritiroPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in ritiro</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblautoconsegnaPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Auto in consegna</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblconfigurazionicorsoPart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Configurazioni in corso</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblconfigurazionievasePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Configurazioni evase</p>
                            </div>
                        </div>
                    </div>
                </div>

                
                <div class="row" >
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold text-red"><asp:Label ID="lblpenaligestirePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Penali da gestire</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblpenaliapprovatePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Penali approvate</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="font-bold text-red"><asp:Label ID="lblpenalicontestazionePart" runat="server" Text=""></asp:Label> </span>
                                <p class="font-12">Penali contestazione</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-1"></div>
           
    </div>          
</div>


<% } %>












<div class="row">
    <div class="col-md-1"></div>
    
    <div class="col-md-4">                        
        <img src="../../../plugins/images/memo.svg" alt="Memo" style="height:30px" />

        <div class="white-box-noborder">
            <div class="task-widget2">
                <div class="task-image">
                    <div class="task-add-btn">
                        <a href="../Utility/InsTask" class="btn btn-success">+</a>
                    </div>
                </div>
                <div class="task-total">
                    <p class="font-16 m-b-0"><strong><asp:Label ID="lblCountTask" runat="server" Text=""></asp:Label></strong> Tasks da elaborare</p>
                </div>
                <div class="task-list">
                    <ul class="list-group">

                        <!-- Lista Task -->
                        <asp:GridView ID="gvCom" runat="server"
                                AutoGenerateColumns="False" DataSourceID="odsCom" CssClass="display nowrap " 
                                GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField HeaderText="">   
                                    <ItemTemplate>
                                        <li class="list-group-item c7_<%# Eval("idtask").ToString() %>">
                                            <div class="checkbox checkbox-success">
                                                <%# ReturnCheck(Eval("idtask").ToString(), Eval("esitotask").ToString(), Eval("Uid").ToString(), Eval("datatask").ToString()) %>
                                                <label for="c7">
                                                    <span class="font-16"><%# ReturnTesto(Eval("testotask").ToString(), Eval("linktask").ToString()) %></span>
                                                </label>
                                            </div>
                                        </li>
                                    </ItemTemplate>                    
                                </asp:TemplateField>  
                            </Columns>    
                            <PagerStyle HorizontalAlign="Right" />    
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTaskAperti" TypeName="BusinessLogic.UtilitysBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 

                    </ul>
                </div>
                                
            </div>
        </div>
    </div>
    <div class="col-md-6">                        
        <img src="../../../plugins/images/help_desk.svg" alt="Ultime Comunicazioni" style="height:30px" />

        <div class="white-box activity-widget">
            <div class="steamline">
                                        
                
                <% if (Approvatore() == 3) {  // COMUNICAZIONI PARTNER %>

                <!-- Lista Ultime Com -->
                <asp:GridView ID="gvUltimeCom3" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom3" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <div class="sl-item">
                                    <div class="sl-left">
                                        <div>
                                            <i class="icon-envelope-letter fa-fw font-20"></i>
                                        </div>
                                    </div>
                                    <div class="sl-right">
                                        <div> 
                                            <%# Eval("datainvio") %> <br /><strong><%# Eval("cognome") %></strong><br />
                                            <a href="../EPartner/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5ComunicazioniPartner" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>                
                </asp:ObjectDataSource> 

                <% } %>



                <% if (Approvatore() == 1) {  // COMUNICAZIONI APPROVATORE %>

                <!-- Lista Ultime Com -->
                <asp:GridView ID="gvUltimeCom2" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom2" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <div class="sl-item">
                                    <div class="sl-left">
                                        <div>
                                            <i class="icon-envelope-letter fa-fw font-20"></i>
                                        </div>
                                    </div>
                                    <div class="sl-right">
                                        <div> 
                                            <%# Eval("datainvio") %> <br /><strong><%# Eval("cognome") %></strong><br />
                                            <a href="../Ticket/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5Comunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                <% } %>



                
                <% if (Approvatore() == 0) {  // COMUNICAZIONI ADMIN %>

                <!-- Lista Ultime Com -->
                <asp:GridView ID="gvUltimeCom" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <div class="sl-item">
                                    <div class="sl-left">
                                        <div>
                                            <i class="icon-envelope-letter fa-fw font-20"></i>
                                        </div>
                                    </div>
                                    <div class="sl-right">
                                        <div> 
                                            <%# Eval("datainvio") %><br /> <strong><%# Eval("cognome") %></strong><br />
                                            <a href="../Ticket/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom" runat="server" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="SelectTop5ComunicazioniAdmin" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                
                <% } %>


            </div>
        </div>
                   
    </div>

</div>


<asp:HiddenField ID="hduiduser" runat="server" />


</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">


<script type="text/javascript">  
    $(document).ready(function () {
        $(".checktask").click(function () {
            var id = $(this).attr("id");
            var uid = $(this).attr("data-id");
            var dataoggi = $(this).attr("data-day");

            var verificaupdate = $.ajax({
                async: false,
                url: "../../../Handler/UpdateTask.ashx?uid=" + uid,
                type: 'POST',
                dataType: 'html',
                timeout: 2000,
            }).responseText;

            if (verificaupdate == "OK") {
                if (dataoggi != "SI") {
                    $("." + id).hide(1000);
                }
            }
            else {
                alert("Errore! Riprova.")
            }
        });
    });  

</script>

</asp:Content>