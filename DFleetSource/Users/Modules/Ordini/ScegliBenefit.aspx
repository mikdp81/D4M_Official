<%@ Page Title="Scegli Benefit" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ScegliBenefit.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ScegliBenefit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box margin-bottom-100">
        <div class="row">
            <div class="col-md-12">
                <h3 class="box-title m-b-0">Fai la tua scelta di mobilità</h3>
            </div>		
        </div>
    </div>





        <div class="row">
            <div class="col-12">               
        
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
              
            </div>
        </div>
   
        <div class="row" style="display:flex;justify-content:center;">

            <div class="col-md-3" runat="server" id="block1"> 
                <div class="white-box-scelta">
                    <div class="border-radius-50">
                        <img src="../../../plugins/images/auto_verde.png" class="icone" />
                    </div> 
                    <div class="text-center bg-titolo-scelta mt-15 mb-4 em-8" >
                        <h2 class="text-white vertical-middle font-bold">AUTO AZIENDALE</h2>
                    </div>

                    <%--<br />In cosa consiste?
                    <div class="mb-4 em-50">
                        <ul class="padding-18">
                            <li> Ho un auto il cui valore &egrave; di <b class="font-verde-scuro">&euro; 5.000 circa</b> e il <b class="font-verde-scuro">carburante pagato o rimborsato</b> </li>
                            <li> Posso spostarmi dal cliente quando desidero </li>
                            <li> Ho un mezzo di trasporto anche per quanto riguarda la mia vita personale </li>
                            <li> Mi sento <b>vincolato all'azienda per un periodo di circa 2 anni</b> per evitare di pagare delle penalità in caso receda anticipatamente </li>
                            <li> Mi piace che  il parco auto sia allineato con la filosofia <b class="font-verde-scuro">WordlClimate</b></li>
                        </ul>
                    </div>
                
                
                
                    Perchè scegliere questa opzione?
                    <div class="bg-verde-chiaro text-white p-5 mb-4 em-20">
                        <ul class="padding-18">
                            <li>&Egrave; la scelta che ti consigliamo perch&egrave; l'azienda ti assicura un parco auto in linea con gli standard  di sicurezza e di WordClimate.</li>
                            <li>&Egrave; indispensabile se i viaggi sono frequenti (es oltre i 5.000 km/annui) o le localit&agrave; logisticamente faticose da raggiungere con i mezzi.</li>
                        </ul>
                    </div>--%>
                    <div class="text-center">
                    Seleziona      <input type="radio" name="sceltabenefit" value="auto" style="width:50px;height:20px;" />
                    </div>
                </div>
            </div>







            <div class="col-md-3">  
                <div class="white-box-scelta">
                    <div class="border-radius-50">
                        <img src="../../../plugins/images/foglie_verdi.png" class="icone" />
                    </div> 

                    <div class="text-center bg-titolo-scelta mt-15 mb-4 em-8" >
                         <h2 class="text-white vertical-middle font-bold">PACCHETTO DI MOBILIT&Agrave; SOSTENIBILE 1<br /><span class="font-20 font-normal">&euro; 150 al mese</span></h2>
                    </div>

                    <div class="mt-15 text-center">
                         <span class="text-dark">Per maggiori informazioni  <a href="https://resources.deloitte.com/sites/it/peo/Pages/device4mobility.aspx" target="_blank">clicca qui</a></span><br /><br />
                    </div>

                    <%--<br />In cosa consiste?
                    <div class="mb-4 em-50">

                       <ul class="padding-18">

                            <li> Ho un valore  di <b class="font-verde-scuro">€  1.850,00</b> per poter accedere ad un <b class="font-verde-scuro">pacchetto di mobilità alternativo</b>  e  la possibilità di un <b class="font-verde-scuro">rimborso kilometrico fino a  1000 Km</b> che mi supporta nel caso debba usare la mia auto aziendale.</li>
                            <li> Sono soddisfatto perché, non desiderando l'auto aziendale, <b class="font-verde-scuro">ho qualcosa in più</b> rispetto ad oggi</li>
                            <li> &Egrave; una scelta green <b class="font-verde-scuro">in linea con la filosofia WorldClimate</b></li>

                        </ul>
                    
                   
                    </div> 
                
                
                   Perchè scegliere questa opzione?
                  <div class="bg-verde-chiaro text-white  p-5 mb-4 em-20">
                        <ul class="padding-18">
                            <li>&Egrave; la scelta che ti consigliamo se percorri fino a 1.000 km/annui e se ti sposti con i mezzi per inquinare meno.</li>
                        </ul>
                    </div>--%>
                    <div class="text-center">
                      Seleziona    <input type="radio" name="sceltabenefit" value="mobilita1" style="width:50px;height:20px;" />
                    </div>
                </div>
            </div>






            <div class="col-md-3">                 
                  <div class="white-box-scelta">
                    <div class="border-radius-50">
                        <img src="../../../plugins/images/foglie_verdi.png"  class="icone" />
                    </div> 

                 
                    <div class="text-center bg-titolo-scelta mt-15 mb-4 em-8" >
                        <h2 class="text-white vertical-middle font-bold">PACCHETTO DI MOBILIT&Agrave; SOSTENIBILE 2<br /><span class="font-20 font-normal">&euro; 100 al mese</span></h2>
                    </div>

                    <div class="mt-15 text-center">
                         <span class="text-dark">Per maggiori informazioni  <a href="https://resources.deloitte.com/sites/it/peo/Pages/device4mobility.aspx" target="_blank">clicca qui</a></span><br /><br />
                    </div>
                    <%-- <br />In cosa consiste?
                    <div class="mb-4 em-50">


                       <ul class="padding-18">
                            <li> Ho un valore  di <b class="font-verde-scuro">€  1.150,00</b>  per poter accedere ad un <b class="font-verde-scuro">pacchetto di mobilità alternativo</b>  e  la possibilità di un <b class="font-verde-scuro">rimborso kilometrico  fino a 5000 Km</b> che mi supporta nel caso debba usare la mia auto aziendale, cosa che al momento accade per me spesso perché lavoro in clienti abbastanza scomodi logisticamente</li>
                            <li>Sono soddisfatto perché, non desiderando l'auto aziendale, <b class="font-verde-scuro">ho qualcosa in più</b> rispetto ad oggi</li>
                            <li>&Egrave; una scelta green <b class="font-verde-scuro">in linea con la filosofia WorldClimate</b></li>

                        </ul>

              
                    </div>

                        Perchè scegliere questa opzione?
                      <div class="bg-verde-chiaro text-white p-5 mb-4 em-20">
                        <ul class="padding-18">
                            <li>&Egrave; la scelta che ti consigliamo se percorri fino a 5.000 km/annui su clienti non sempre facilmente raggiungibili con i mezzi pubblici.</li>
                        </ul>
                    </div>--%>
                    <div class="text-center">
                      Seleziona    <input type="radio" name="sceltabenefit" value="mobilita2" style="width:50px;height:20px;" />
                    </div>
                  </div>
            </div>





            <div class="col-md-3">                 

                <div class="white-box-scelta">
                
                    <div class="border-radius-50">
                        <img src="../../../plugins/images/x_verde.png" class="icone" />
                    </div> 

                    <div class="text-center bg-titolo-scelta mt-15 mb-4 em-8" >
                        <h2 class="text-white vertical-middle font-bold">NESSUNA SCELTA</h2>                 
                    </div>

                    <div class="mt-15 text-center">
                        <br /><br />
                    </div>

                    <%-- <br />In cosa consiste?<br />
                    <div class="mb-4 em-50">

      
                  <b class="font-verde-scuro"><br />Non desiderio vincolarmi con la richiesta del benefit auto</b> perché ne possiedo una privata e mi capita di dover raggiungere i miei clienti in zone <b class="font-verde-scuro">logisticamente complicate</b> 
                    
                 
                    </div>
                        Perchè scegliere questa opzione?
                      <div class="bg-verde-chiaro text-white p-5 mb-4 em-20" >
                        <ul class="padding-18">
                            <li>&Egrave; la scelta che ti consigliamo come ultima opzione, solo se disponi di una macchina privata ma non devi percorrere annualmente un elevato numero di km. </li>
                        </ul>
                    </div>--%>
                    <div class="text-center">
                        Seleziona <input type="radio" name="sceltabenefit" value="rinuncia" style="width:50px;height:20px;" />
                    </div>

                </div>

        </div>
    </div>

    <div class="text-center"><asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="PROSEGUI" CssClass="btn btn-primary font-18 " /> </div><br /><br /><br /><br /><br />

</div>


</asp:Content>