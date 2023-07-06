<%@ Page Title="" Language="C#" MasterPageFile="~/Rental/MasterpageRental.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DFleet.Rental.Modules.Dash.Dashboard" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="row">
    <div class="col-md-12">      
        <div class="row" >
            <div class="col-md-3">
                <div class="white-box-dash bg-black ecom-stat-widget">
                    <div class="row">
                        <span class="text-white font-light"><asp:Label ID="lblstatus10" runat="server" Text=""></asp:Label> </span>
                        <p class="font-12">Pending presa in carico</p>                                                    
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="white-box-dash bg-black ecom-stat-widget">
                    <div class="row">                               
                        <span class="text-white font-light"><asp:Label ID="lblstatus20" runat="server" Text=""></asp:Label> </span>
                        <p class="font-12">In attesa di offerta</p>           
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="white-box-dash bg-black ecom-stat-widget">
                    <div class="row">                           
                        <span class="text-white font-light"><asp:Label ID="lblstatus50" runat="server" Text=""></asp:Label> </span>
                        <p class="font-12">In attesa di evasione</p>                           
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="white-box-dash bg-black ecom-stat-widget">
                    <div class="row">                             
                        <span class="text-white font-light"><asp:Label ID="lblstatus55" runat="server" Text=""></asp:Label> </span>
                        <p class="font-12">Evaso</p>        
                    </div>
                </div>
            </div>             
        </div>
    </div>
</div>
   
<div class="row">    
    <div class="col-md-6">
        <img src="../../../plugins/images/help_desk.svg" alt="Ultime Comunicazioni" style="height:30px" />
                        
        <div class="white-box-noborder">
            <div class="task-widget2">
                <div class="task-image">
                    <div class="task-add-btn">
                        <a href="InsCom" class="btn btn-success">+</a>
                    </div>
                </div>
            </div>

            <div class="steamline">

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
                                            <%# Eval("datainvio") %> <%# Eval("cognome") %><br />
                                            <a href="DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                      
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5Comunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                                
                <asp:Panel ID="pnlMessage" runat="server" CssClass="font-18" >
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

            </div>
        </div>                   
    </div>
</div>


<asp:HiddenField ID="hduiduser" runat="server" />
<asp:HiddenField ID="hdcodfornitore" runat="server" />

</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">



</asp:Content>