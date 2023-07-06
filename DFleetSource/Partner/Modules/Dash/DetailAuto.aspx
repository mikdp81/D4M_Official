<%@ Page Title="Configurazione" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="DetailAuto.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.DetailAuto" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazione</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Partner/Modules/Dash/StoricoAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
             <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label>  <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit <br>
                   <h4><asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h4> <br>
                </div>
                <div class="col-md-6"> 

                   
                    
                    
                    <div class="row">
                        <div class="col-md-3 text-center">
                            Consumo medio (l/100km)<br />
                            <h4 class="text-verde"><asp:Label ID="lblConsumo" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                             urbano (l/100km)<br />
                           <h4 class="text-verde"><asp:Label ID="lblConsumourbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            extraurbano (l/100km)<br />
                           <h4 class="text-verde"> <asp:Label ID="lblConsumoextraurbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Emissioni (gr/km dich.)<br />
                            <h4 class="text-verde"><asp:Label ID="lblEmissioni" runat="server" Text=""></asp:Label></h4>
                          </div>
                      
                    </div>

                    <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
                 
                
                
                </div>


             
</div>

        </div>

            <br />
            
        <div class="row">
            <div class="col-md-3 text-center">
                Km attuali vettura<br />
                <h4 class="text-verde"><asp:Label ID="lblkmattuali" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                    Km totali contratto<br />
                <h4 class="text-verde"><asp:Label ID="lblkmtotali" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                Scadenza contratto<br />
                <h4 class="text-verde"> <asp:Label ID="lblscadenza" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                Luogo di ritiro<br />
                <h4 class="text-verde"><asp:Label ID="lblluogoritiro" runat="server" Text=""></asp:Label></h4>
                </div>
        </div>



        </div>


    <div class="white-box">
        <div class="row">
            <asp:Label ID="lbldocumenti" runat="server" Text="" />
            <asp:Label ID="lblConsumi" runat="server" Text="" />

            <asp:HiddenField ID="hdcodjatoauto" runat="server" />
            <asp:HiddenField ID="hdidordine" runat="server" />
            <asp:HiddenField ID="hdcount" runat="server" />
            <asp:HiddenField ID="hdcountcolor" runat="server" />
            <asp:HiddenField ID="hduid" runat="server" />

        </div>


    </div>
</div>


</asp:Content>