<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeaderAdmin.ascx.cs" Inherits="DFleet.Admin.UCHeaderAdmin" %>


<div class="navbar-header">
    <a class="navbar-toggle font-20 hidden-sm hidden-md hidden-lg " href="javascript:void(0)" data-toggle="collapse" data-target=".navbar-collapse">
        <i class="fa fa-bars"></i>
    </a>
    <div class="top-left-part">
        <a href="javascript:void(0)" class="sidebartoggler font-20 waves-effect waves-light"><i class="icon-arrow-left-circle"></i></a>
    </div>
    <ul class="nav navbar-top-links navbar-left hidden-xs">
        <li>
            <a class="logo" href="<%=ResolveUrl("~/Admin/Modules/Dash/Dashboard")%>"><asp:Literal ID="ltLogo" runat="server"></asp:Literal></a>
        </li>
    </ul>

    <ul class="nav navbar-top-links navbar-right pull-right">    
        <li class="m-t-10 m-r-10">
            <asp:DropDownList ID="ddlChangeTeam" runat="server" DataSourceID="odsteam" DataTextField="team" 
                DataValueField="idteam" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeTeam_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsteam" runat="server" SelectMethod="SelectTeamUser" TypeName="BusinessLogic.AccountBL" OldValuesParameterFormatString="original_{0}" >
                <SelectParameters>
                    <asp:ControlParameter ControlID="hduseridteam" DbType="Guid" Name="UserId" PropertyName="Value" />
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <asp:HiddenField ID="hduseridteam" runat="server" />            
        </li>
        <li class="m-t-10 m-r-10">
            <asp:DropDownList ID="ddlChangeTenant" runat="server" DataSourceID="odstenant" DataTextField="tenant" 
                DataValueField="uidtenant" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlChangeTenant_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odstenant" runat="server" SelectMethod="SelectTenant" TypeName="BusinessLogic.AccountBL" OldValuesParameterFormatString="original_{0}" >
            </asp:ObjectDataSource>           
        </li>        
        <li class="right-side-toggler">
            <a class="b-r-0 font-20 svg-icon-50 svg-icon-user" href="javascript:void(0)"></a>
        </li>   
    </ul>
    <ul class="nav navbar-top-links navbar-right pull-right">
        <li class="m-t-10 m-r-10">
            <asp:Label ID="lblentradriver" runat="server" Text=""></asp:Label>
        </li>
        <li class="dropdown">
            <a class="dropdown-toggle waves-effect waves-light font-20" data-toggle="dropdown" href="javascript:void(0);">
                <i class="icon-speech"></i>
                <span class="badge badge-xs badge-danger"><asp:Label ID="lblCountComunic" runat="server" Text=""></asp:Label></span>
            </a>
            <ul class="dropdown-menu mailbox animated bounceInDown">
                
                <!-- Lista Com -->
                <asp:GridView ID="gvCom" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsCom" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <li>
                                    <div class="message-center">
                                        <a href="javascript:void(0);">
                                            <div class="user-img">
                                                <img src="../../../plugins/images/FLEET.png" alt="user" class="img-circle">
                                                <span class="profile-status online pull-right"></span>
                                            </div>
                                            <div class="mail-contnet">
                                                <h5><%# Eval("cognome") %></h5>
                                                <span class="mail-desc"><%# Eval("oggetto") %></span>
                                                <span class="time"><%# Eval("datainvio") %></span>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCom" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="SelectComunicazioniAperteAdmin" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                        



                <!-- Lista Com Approvatori -->
                <asp:GridView ID="gvComAppr" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsComAppr" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <li>
                                    <div class="message-center">
                                        <a href="javascript:void(0);">
                                            <div class="user-img">
                                                <img src="../../../plugins/images/FLEET.png" alt="user" class="img-circle">
                                                <span class="profile-status online pull-right"></span>
                                            </div>
                                            <div class="mail-contnet">
                                                <h5><%# Eval("oggetto") %></h5>
                                                <span class="time"><%# Eval("datainvio") %></span>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsComAppr" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectComunicazioniAperte" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduseridteam" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                <li>
                    <a class="text-center" href="javascript:void(0);">
                        <strong><a href="<%=ResolveUrl("~/Admin/Modules/Ticket/ViewComunicazioni")%>">Vai a comunicazioni</a></strong>
                        <i class="fa fa-angle-right"></i>
                    </a>
                </li>
            </ul>
        </li>
        <li class="dropdown">
            <a class="dropdown-toggle waves-effect waves-light font-20" data-toggle="dropdown" href="javascript:void(0);">
                <i class="icon-calender"></i>
                <span class="badge badge-xs badge-danger"><asp:Label ID="lblCountTask" runat="server" Text=""></asp:Label></span>
            </a>
            <ul class="dropdown-menu dropdown-tasks animated slideInUp">
                <!-- Lista Task -->
                <asp:GridView ID="gvTask" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsTask" CssClass="display nowrap " 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="">   
                            <ItemTemplate>
                                <li>
                                    <a href="javascript:void(0);">
                                        <div>
                                            <p>
                                                <strong><%# Eval("testotask")%></strong>                                
                                            </p>                           
                                        </div>
                                    </a>
                                </li>
                                <li class="divider"></li>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsTask" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTaskAperti" TypeName="BusinessLogic.UtilitysBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduseridteam" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <li>
                    <a class="text-center" href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewCalendario")%>">
                        <strong>Vai al calendario</strong>
                        <i class="fa fa-angle-right"></i>
                    </a>
                </li>
            </ul>
        </li>
   
    </ul>
</div>

