<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeaderPartner.ascx.cs" Inherits="DFleet.Partner.UserControl.UcHeaderPartner" %>


<div class="navbar-header">
     <a class="navbar-toggle font-20 hidden-sm hidden-md hidden-lg ">
        <img src='<%=ResolveUrl("~/plugins/images/Logo_d4m_premium.png")%>' class="logopartner" alt="home" />
    </a>
    <div class="top-left-part">
        <a href="javascript:void(0)" class="sidebartoggler font-20 waves-effect waves-light"><i class="icon-arrow-left-circle"></i></a>
    </div>
    <ul class="nav navbar-top-links navbar-left hidden-xs">
        <li>
            <a class="logo" href="<%=ResolveUrl("~/Partner/Modules/Dash/Dashboard")%>">
         
                <img src='<%=ResolveUrl("~/plugins/images/Logo_d4m_premium.png")%>' class="logopartner" alt="home" />
          
        </a>
        </li>
       
    </ul>
    <ul class="nav navbar-top-links navbar-right pull-right">
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
                <asp:ObjectDataSource ID="odsCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectComunicazioniAperte" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduseridteam" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                        
                <li>
                    <a class="text-center" href="javascript:void(0);">
                        <strong><a href="<%=ResolveUrl("~/Partner/Modules/Dash/ViewComunicazioni")%>">Apri Help Desk</a></strong>
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
                                    <%# ReturnTestoTask(Eval("testotask").ToString(), Eval("linktask").ToString())%>                                    
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

            </ul>
        </li>
        <li class="right-side-toggle">
           <a class="right-side-toggler b-r-0 font-20 svg-icon-50" style="background: url(../../../plugins/images/ico_user_b.svg);" href="javascript:void(0)"></a>
        </li>
    </ul>
</div>

<asp:HiddenField ID="hduseridteam" runat="server" />   