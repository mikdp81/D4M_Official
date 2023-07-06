<%@ Page Title="Benefit" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="ViewBenefit.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.ViewBenefit" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Benefit</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-3" runat="server" id="pacchetto1">                 
                <div style="width:100%; border:1px solid #89BA17; padding:5px;">                    
                    <div class="text-center"><img src="../../../plugins/images/foglie_verdi.png" />

                    <h3>PACCHETTO MOBILIT&Agrave;<br />
                    versione 1</h3></div>

                    La soluzione si compone di: <br />

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
                    </ul>
                </div>
            </div>
            <div class="col-md-3" runat="server" id="pacchetto2">                  
                <div style="width:100%; border:1px solid #89BA17; padding:5px;">             
                    <div class="text-center"><img src="../../../plugins/images/foglie_verdi.png" />
                    
                    <h3>PACCHETTO MOBILIT&Agrave;<br />
                    versione 2</h3></div>

                    La soluzione si compone di: <br />

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
                    </ul>
                </div>
            </div>
        </div>


    </div>
</div>


</asp:Content>