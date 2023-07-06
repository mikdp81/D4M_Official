<%@ Page Title="" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.Dashboard" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                Auto in uso dal <asp:Label ID="lbldataritiro" runat="server" Text="" CssClass="font-bold"></asp:Label> - Targa <asp:Label ID="lblTarga" runat="server" Text="" CssClass="font-bold"></asp:Label> - 
                Modello <asp:Label ID="lblModello" runat="server" Text="" CssClass="font-bold"></asp:Label> - Renter <asp:Label ID="lblRental" runat="server" Text="" CssClass="font-bold"></asp:Label> 
            </div>
        </div>
    </div>


    <div>
        <div class="row">
            <div class="col-md-6">
                <div runat="server" class="schedasx" onclick="location.href='Configura'" id="schedasx">
                    <div class="text-center pt-305 mb-4 em-8 titlepartner">
                        <h2 class="font-bold colorverded">SCELTA NUOVA AUTO</h2>
                    </div>

                    <div class="pt-30 text-center m-l-5 m-r-5 font-18">
                        Richiedi al nostro consulente di affiancarti <br /> nella configurazione della tua nuova auto. <br />
                        Allega il preventivo se gi&agrave; in tuo possesso.
                    </div>
                    
                     <div class="manosx"><img src="../../../plugins/images/mano_sx.png" alt="" border="0" id="manosx" class="imgmanosx" style="display:none;" /></div>
                </div>
            </div>       

            <div class="col-md-6">
                <div class="schedadx" onclick="location.href='InsCom'" id="schedadx">
                    <div class="text-center pt-305 mb-4 em-8 titlepartner">
                        <h2 class="font-bold colorverdeg">TICKETING</h2>
                    </div>

                    <div class="pt-30 text-center m-l-5 m-r-5 font-18">
                        Apri un ticket alla nostra assistenza <br /> sar&agrave; evaso nel pi&ugrave; breve tempo  possibile.
                    </div>

                    <div class="manodx"><img src="../../../plugins/images/mano_dx.png" alt="" border="0" id="manodx" class="imgmanodx" style="display:none;" /></div>
                </div>
            </div>
            
            <div class="col-md-12 text-center m-t-30">   
                <a href="InsDelega" class="buttonpartner3"><img src="../../../plugins/images/button_delegassistente.png" alt="" border="0" /></a>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function () {  

        $("#ContentBody_schedasx").hover(
            function () {
                $("#manosx").show();
            }, function () {
                $("#manosx").hide();
        });

        $("#schedadx").hover(
            function () {
                $("#manodx").show();
            }, function () {
                $("#manodx").hide();
            });
    });  
</script>

</asp:Content>