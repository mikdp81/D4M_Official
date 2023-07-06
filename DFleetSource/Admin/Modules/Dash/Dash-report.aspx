<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-report.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_report" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="row el-element-overlay m-b-20">               
    <div class="col-lg-offset-2 col-md-offset-2 col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box bg-black">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"><img src="<%=ResolveUrl("~/")%>plugins/images/logod4mobility_report.png">
                    <div class="el-overlay">

                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">&nbsp;</h3>
                </div>                               
            </div>
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_flotta.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-flotta"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Flotta</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_pool.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-pool"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Pool</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_ordini.png" >
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-ordini"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Ordini</h3> 
                </div>
            </div>
        </div>
    </div>                   
</div>

<div class="row el-element-overlay m-b-20">                   
    <div class="col-lg-offset-2 col-md-offset-2 col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_rental.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-rental"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Renter</h3>
                </div>
            </div> 
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_contabilita.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                           <li><a class="btn default btn-outline" href="Dash-contabilita"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Contabilità</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_driver.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-driver"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Driver</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
        <div class="white-box">
            <div class="el-card-item">
                <div class="el-card-avatar el-overlay-1"> <img src="<%=ResolveUrl("~/")%>plugins/images/dash_multe.png">
                    <div class="el-overlay">
                        <ul class="el-info">
                            <li><a class="btn default btn-outline" href="Dash-multe"><i class="icon-magnifier"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="el-card-content">
                    <h3 class="box-title">Multe</h3>
                </div>
            </div>
        </div>
    </div>                   
</div>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">


</asp:Content>