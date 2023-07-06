<%@ Page Title="Modifica configurazione" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="EditConf.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.EditConf" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica configurazione</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>


        <div class="white-box">
        <div class="row">
            <div class="col-12">                
        
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


              <div class="col-md-6"> 
                
                MARCA<br />
                <h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
               <h3 class="font-bold"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h3>
                Alimentazione <br />
             <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit base (questo valore può subire variazioni)<br>
                  <h3> &euro; <asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h3> 
                  
                  Giorni consegna previsti<br>
                 <h3> <asp:Label ID="lblgiorniconsegna" runat="server" Text=""></asp:Label> </h3><br>
                </div>
                <div class="col-md-6"> 

                   
                    
                    
                    <div class="row">
                        <div class="col-md-3 text-center">
                            Consumo medio<br /> (l/100km)<br />
                            <h4 class="text-verde"><asp:Label ID="lblConsumo" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                             Urbano<br /> (l/100km)<br />
                           <h4 class="text-verde"><asp:Label ID="lblConsumourbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Extraurbano<br /> (l/100km)<br />
                           <h4 class="text-verde"> <asp:Label ID="lblConsumoextraurbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Emissioni<br /> (gr/km dich.)<br />
                            <h4 class="text-verde"><asp:Label ID="lblEmissioni" runat="server" Text=""></asp:Label></h4>
                          </div>
                      
                    </div>

                    <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
                 
                
                
                </div>


             
</div>

        </div>

        </div>




    <h3>Selezionare un colore</h3>
    <div class="white-box-nobg">
        <div class="row">
            <div class="col-12">                                      
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">             
                <div class="text-center font-18 bg-verde text-white m-b-30">OPTIONAL CANONE (addebito mensile iva esclusa) <br />&euro; <asp:Label ID="lbloptionalcanone" runat="server" Text=""></asp:Label></div>
                                
                
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#aggiuntivi" aria-controls="aggiuntivi" role="tab" data-toggle="tab" aria-expanded="true"><span class="visible-xs">Optional aggiuntivi</span><span class="hidden-xs"> Optional aggiuntivi</span></a></li>
                    <li role="presentation" class=""><a href="#serie" aria-controls="serie" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs">Optional di serie</span> <span class="hidden-xs">Optional di serie</span></a></li>
                </ul>

                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="aggiuntivi">
                        <asp:Literal ID="ltoptional" runat="server"></asp:Literal>
                    </div>
                                        
                    <div role="tabpanel" class="tab-pane" id="serie">
                        Clicca per visualizzare gli optional della categoria
                        <asp:Literal ID="ltoptionalserie" runat="server"></asp:Literal>
                    </div>
                </div>
            </div> 
        </div>
    </div>

    <div class="text-center"><asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="MODIFICA CONFIGURAZIONE" CssClass="btn btn-primary font-18 " /> </div><br /><br /><br /><br /><br />


    <asp:HiddenField ID="hdcodjatoauto" runat="server" />
    <asp:HiddenField ID="hdidordine" runat="server" />
    <asp:HiddenField ID="hdcount" runat="server" />
    <asp:HiddenField ID="hdcountcolor" runat="server" />
    <asp:HiddenField ID="hduid" runat="server" />


</div>




</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".codoptional").click(function () {
            var count = $(this).attr("data-id");
            var importo = new Number($("#importo_" + count).val().replace(",", "."));
            var totaleattuale = new Number($("#ContentBody_lbloptionalcanone").html().replace(",", "."));
            var totalecalcolato = 0;

            if ($("#codoptional_" + count).is(':checked')) {
                totalecalcolato = totaleattuale + importo;
            }
            else {
                totalecalcolato = totaleattuale - importo;
            }

            $("#ContentBody_lbloptionalcanone").html(totalecalcolato.toFixed(2));
        });   


        $("div[data-toggle]").on("click", function (e) {
            e.preventDefault();  // prevent navigating
            var selector = $(this).data("toggle");  // get corresponding selector from data-toggle
            //$("div").hide();
            $(selector).toggle("slow");
        });

    });  
</script>

</asp:Content>