<%@ Page Title="Richiesta ZTL " Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="RichiestaZTL.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.RichiestaZTL" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Richiesta ZTL</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">

            <div class="col-md-12">
                Compila il seguente modulo 

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


<div style="text-align:center"><b>DICHIARA</b></div><br />
che il dipendente Sig./la Sig.ra <asp:TextBox ID="txtDenominazione" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, 
nato/a a <asp:TextBox ID="txtLuogoNascita" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>
il giorno <asp:TextBox ID="txtDataNascita" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom datePicker"></asp:TextBox>,  
<br /><br />residente a <asp:TextBox ID="txtCitta" runat="server" Columns="20" MaxLength="255" CssClass=" borderbottom"></asp:TextBox>
in <asp:TextBox ID="txtIndirizzo" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, n. <asp:TextBox ID="txtCivico" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom"></asp:TextBox>,
&egrave; l'utilizzatore del suddetto veicolo in uso esclusivo a partire dal <asp:TextBox ID="txtDataInizioContratto" runat="server" Columns="10" MaxLength="255" CssClass=" borderbottom datePicker"></asp:TextBox>
<br /><br />sino alla data in cui terminer&agrave; la locazione.  <br /><br />

<br /><br />
<div style="text-align:center"><b>DATI CONTRATTO</b></div><br />
N. contratto <asp:TextBox ID="txtNumContratto" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>, <br /><br />
data inizio <asp:TextBox ID="txtDataInizioContratto2" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred datePicker"></asp:TextBox>, <br /><br />
data scadenza <asp:TextBox ID="txtDataFineContratto" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred datePicker"></asp:TextBox> 

<br /><br /><br />

<b> veicolo <asp:TextBox ID="txtVeicolo" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox> 
targato <asp:TextBox ID="txtTarga" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox> </b>
fornitore  <asp:TextBox ID="txtFornitore" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>   <br /><br />

Luogo, <asp:TextBox ID="txtLuogoDocumento" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox> ,
Data <asp:TextBox ID="txtDataDocumento" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom datePicker"></asp:TextBox><br /><br />
<br /><br />
<asp:HiddenField ID="hdcodsocieta" runat="server" />
<asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Richiedi documento" CssClass="btn btn-success" /> 

            </div>
        </div>
    </div>
</div>


</asp:Content>
