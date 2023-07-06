<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Telematica.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.Telematica" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <style type="text/css">
        iframe {
          position: absolute;
          top: 80px;
          left: 80px;
          width: 90%;
          height: 85%;
        }
        .footer {display:none;}
    </style>

    <iframe title="D4M" 
        src="https://app.powerbi.com/reportEmbed?reportId=c88e65ca-2b74-4863-9f90-99179b13b5df&autoAuth=true&ctid=36da45f1-dd2c-4d1f-af13-5abe46b99921"
        frameborder="0" 
        allowFullScreen="true"></iframe>


</asp:Content>