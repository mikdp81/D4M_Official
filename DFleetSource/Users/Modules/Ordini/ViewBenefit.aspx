<%@ Page Title="Benefit" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ViewBenefit.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ViewBenefit" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Pacchetto di mobilità scelto</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            
            <div class="col-md-4" runat="server" id="pacchetto4">  
                <h2>NON HAI EFFETTUATO ALCUNA SCELTA</h2>
            </div>
            <div class="col-md-3" runat="server" id="pacchetto3">  
                <h2><a href="ScegliBenefit">SCEGLI IL PACCHETTO DI MOBILIT&Agrave;</a></h2>
            </div>
            <div class="col-md-3" runat="server" id="pacchetto1">                 
                <div style="width:100%; border:1px solid #89BA17; padding:5px;">                    
                    <div class="text-center"><img src="../../../plugins/images/foglie_verdi.png" />

                    <h3>PACCHETTO DI MOBILIT&Agrave; SOSTENIBILE 1<br />
                    &euro; 150</h3></div>

                    <%--La soluzione si compone di: <br />

                    PACCHETTO MOBILIT&Agrave; <br />
                    Wallet pari da spendere per uso privato <br />
                    
                    <ul>
                        <li>Sharing Mobility</li>
                        <li>Noleggio auto</li>
                        <li>Trasporto pubblico</li>
                    </ul>


                    PACCHETTO KM=1.000

                    <ul>
                        <li>fino a 1.000 Km rimborso pari a 0,52/Km</li>
                        <li>Da 1.000 Km in su rimborso pari a 0,15/Km</li>
                    </ul>--%>
                </div>
            </div>
            <div class="col-md-3" runat="server" id="pacchetto2">                  
                <div style="width:100%; border:1px solid #89BA17; padding:5px;">             
                    <div class="text-center"><img src="../../../plugins/images/foglie_verdi.png" />
                    
                    <h3>PACCHETTO DI MOBILIT&Agrave; SOSTENIBILE 2<br />
                    &euro; 100</h3></div>

                    <%--La soluzione si compone di: <br />

                    PACCHETTO MOBILIT&Agrave; <br />
                    Wallet pari da spendere per uso privato <br />
                    
                    <ul>
                        <li>Sharing Mobility</li>
                        <li>Noleggio auto</li>
                        <li>Trasporto pubblico</li>
                    </ul>


                    PACCHETTO KM=5.000

                    <ul>
                        <li>fino a 5.000 Km rimborso pari a 0,52/Km</li>
                        <li>Da 5.000 Km in su rimborso pari a 0,15/Km</li>
                    </ul>--%>
                </div>
            </div>            
            <div class="col-md-3">                    
                Clicca qui per accedere alla piattaforma Mobility Company <a href="https://deloitte.mmanager.net/oauth/deloitte/website" target="_blank">https://deloitte.mmanager.net/oauth/deloitte/website</a>
            </div>
        </div>


    </div>
</div>


</asp:Content>