<%@ Page Title="Configurazione" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ViewConf.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ViewConf" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazione</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>		
        </div>
    </div>

    
        <div style="text-align:center;">      
            <!-- Visualizzazione Errori -->
            <asp:Panel ID="pnlMaxConf" runat="server" CssClass="text-center border-0 font-18 m-b-5 alert alert-warning bg-warning text-white border-0">
                <asp:Label ID="lblMaxConf" runat="server" Text=""></asp:Label>
            </asp:Panel>

            <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="RICHIEDI QUOTAZIONE" CssClass="btn btn-primary font-22" /><br /><br />
        </div>


        <div class="white-box">
            <div class="row">
                <div class="col-md-12">
                    <asp:Panel ID="pnlMessage" runat="server">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
            </div>



            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lbldatiordine" runat="server" Text=""></asp:Label>   
                </div>
            </div>
        </div>

        <div class="white-box">         

            <div class="row">
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



    <div class="white-box">
        <div class="row">
            <div class="col-md-12">        
                 

                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                
                <div class="text-center font-18 bg-verde text-white m-b-30">OPTIONAL CANONE (addebito mensile iva esclusa) <br />&euro; <asp:Label ID="lbloptionalcanone" runat="server" Text=""></asp:Label></div>

                <h5>Optional Aggiuntivi</h5>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal>


                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hdcount" runat="server" />
                <asp:HiddenField ID="hdcountcolor" runat="server" />
                <asp:HiddenField ID="hduid" runat="server" />

                <br /><br /><br /><br />
            </div> 
        </div>


    </div>
</div>


</asp:Content>