<%@ Page Title="Richiesta delega a condurre " Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="RichiestaDelega.aspx.cs" Inherits="DFleet.Users.Modules.Dash.RichiestaDelega" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Richiesta delega a condurre</h3>
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


<div style="text-align:center"><b>DATI DIPENDENTE</b></div><br />
il/la Sig./ra <asp:TextBox ID="txtDenominazione" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, 
nato/a a <asp:TextBox ID="txtLuogoNascita" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>
il giorno <asp:TextBox ID="txtDataNascita" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom datePicker"></asp:TextBox>,  
<br /><br />residente a <asp:TextBox ID="txtCitta" runat="server" Columns="20" MaxLength="255" CssClass=" borderbottom"></asp:TextBox>
in Via <asp:TextBox ID="txtIndirizzo" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, n. <asp:TextBox ID="txtCivico" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, <br /><br />
nr. Patente <asp:TextBox ID="txtNrPatente" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>, 
rilasciata il giorno <asp:TextBox ID="txtDataRilascioPatente" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom datePicker"></asp:TextBox>, 
da <asp:TextBox ID="txtEntePatente" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>. 
e con scadenza <asp:TextBox ID="txtScadenzaPatente" runat="server" Columns="10" MaxLength="255" CssClass=" borderbottom datePicker"></asp:TextBox>
<br /><br />in qualit&agrave; di dipendente  <br /><br />

<br /><br />
                <div style="text-align:center"><b>DATI ALTRO DELEGATO</b></div><br />

il/la Sig./ra <asp:TextBox ID="txtDenominazioneDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>,
nato/a a <asp:TextBox ID="txtLuogoNascitaDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>
il giorno <asp:TextBox ID="txtDataNascitaDelegato" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred datePicker"></asp:TextBox>,
<br /><br />residente a <asp:TextBox ID="txtCittaDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred "></asp:TextBox> 
in Via <asp:TextBox ID="txtIndirizzoDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>, n. <asp:TextBox ID="txtCivicoDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>, <br /><br />
nr. Patente <asp:TextBox ID="txtNrPatenteDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox>, 
rilasciata il giorno <asp:TextBox ID="txtDataRilascioPatenteDelegato" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred datePicker"></asp:TextBox>, 
da <asp:TextBox ID="txtEntePatenteDelegato" runat="server" Columns="20" MaxLength="255" CssClass="borderbottomred"></asp:TextBox> 
e con scadenza <asp:TextBox ID="txtScadenzaPatenteDelegato" runat="server" Columns="10" MaxLength="255" CssClass="borderbottomred datePicker"></asp:TextBox> 
<br /><br />in qualità di
<asp:DropDownList ID="ddlTipoUtente" runat="server" CssClass="borderbottomred" AppendDataBoundItems="True">
<asp:ListItem Selected="True" Value=""></asp:ListItem>
<asp:ListItem Value="Coniuge">Coniuge</asp:ListItem>
<asp:ListItem Value="Convivente">Convivente</asp:ListItem>
<asp:ListItem Value="Familiare">Familiare</asp:ListItem>
</asp:DropDownList>. <br /><br /><br />

<b> condurre il veicolo <asp:TextBox ID="txtVeicolo" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox> 
targato <asp:TextBox ID="txtTarga" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox> </b>
fornitore  <asp:TextBox ID="txtFornitore" runat="server" Columns="20" MaxLength="255" CssClass="borderbottom"></asp:TextBox>   <br /><br />

Milano, <asp:TextBox ID="txtDataDocumento" runat="server" Columns="10" MaxLength="255" CssClass="borderbottom datePicker"></asp:TextBox><br /><br />
<br /><br />
<asp:HiddenField ID="hdcodsocieta" runat="server" />
<asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Richiedi documento" CssClass="btn btn-success" /> 

            </div>
        </div>
    </div>
</div>


</asp:Content>
