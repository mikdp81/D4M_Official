<%@ Page Title="Accetta preventivo" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="Accetta.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.Accetta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="white-box">
    <div class="row">
        <div class="col-md-7">
            <h3 class="box-title m-b-0">Accetta preventivo</h3>
        </div>
        <div class="col-md-5 text-right">
            <a href="<%=ResolveUrl("~/Users/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla lista ordini</a> 
        </div>				
    </div>
</div>

<div class="white-box">
    <div class="row">
        <div class="col-12">                
            <asp:Panel ID="pnlMessage" runat="server">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <asp:HiddenField ID="hduid" runat="server" />
            <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Accetta Preventivo" CssClass="btn btn-success" />
        </div>
        <div class="col-sm-6">                            
            <label class="control-label">Motivo Scarto</label>
            <asp:TextBox ID="txtMotivoScarto" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Motivo Scarto" TextMode="MultiLine"></asp:TextBox> <br />
               
            <asp:Button ID="btnScarta" runat="server" onclick="btnScarta_Click" Text="Rifiuta Preventivo" CssClass="btn btn-success" />
        </div>
    </div>
</div>

<div class="white-box">
    <div class="row">
        <div class="col-12">                
            <div class="col-md-6">                 
                MARCA<br />
                <h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
                <h3 class="font-bold"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h3>
                Alimentazione <br />
                <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> / <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit base (questo valore può subire variazioni)<br>
                  <h3>&euro; <asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h3>               
                  
                  Giorni consegna previsti<br>
                  <h3> <asp:Label ID="lblgiorniconsegna" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="col-md-6"> 
                    <div class="row">
                        <div class="col-md-3 text-center">
                            Consumo medio <br /> (l/100km)<br />
                            <h4 class="text-verde"><asp:Label ID="lblConsumo" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                             Urbano <br /> (l/100km)<br />
                           <h4 class="text-verde"><asp:Label ID="lblConsumourbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Extraurbano <br /> (l/100km)<br />
                           <h4 class="text-verde"> <asp:Label ID="lblConsumoextraurbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Emissioni <br /> (gr/km dich.)<br />
                            <h4 class="text-verde"><asp:Label ID="lblEmissioni" runat="server" Text=""></asp:Label></h4>
                          </div>
                      
                    </div>
                <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>
    
<div class="white-box">
    <div class="row">
        <div class="col-12">                  
            <asp:Label ID="lbldatiordine" runat="server" Text=""></asp:Label>  
        </div>
    </div>
</div>

<div class="white-box">
    <div class="row">
        <div class="col-12">  

            <h5>Colore</h5>
            <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
            <div class="text-center font-18 bg-verde text-white m-b-30">OPTIONAL CANONE (i.e.) <br />&euro; <asp:Label ID="lbloptionalcanone" runat="server" Text=""></asp:Label></div>
            
            <h5>Optional Aggiuntivi</h5>
            <asp:Literal ID="ltoptional" runat="server"></asp:Literal>
        </div> 
    </div>
</div>


</asp:Content>