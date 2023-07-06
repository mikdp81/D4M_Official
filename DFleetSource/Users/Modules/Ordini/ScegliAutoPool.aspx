<%@ Page Title="Auto Pool" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ScegliAutoPool.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ScegliAutoPool" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Auto Pool</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Ordini/ConfiguraAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna indietro</a> 
            </div>			
        </div>
    </div>

    
    <div style="text-align:center;"><asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Richiedi Auto" CssClass="btn btn-primary font-22" /><br /><br /></div>


    <div class="white-box">
        <div class="row">
            <div class="col-12">                
        
              <div class="col-md-6"> 
                
                MARCA<br />
                <h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
               <h3 class="font-bold"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h3>
                Alimentazione <br />
             <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit base (questo valore può subire variazioni)<br>
                  <h3> &euro; <asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h3> 

                  Optional Canone (addebito mensile iva esclusa) <br />
                  <h3>&euro; <asp:Label ID="lbloptionalcanone" runat="server" Text=""></asp:Label></h3>

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
            <div class="col-12">                
                <div class="clear"></div>

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                <h5>Optional</h5>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal><br /><br />
                
                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hdidcontratto" runat="server" />
            </div> 
        </div>


    </div>
</div>


</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".codoptional").click(function () {
            var count = $(this).attr("data-id");
            var importo = new Number($("#importo_" + count).val().replace(",", "."));
            var totaleattuale = new Number($("#totale").html().replace(",", "."));
            var totalecalcolato = 0;

            if ($("#codoptional_" + count).is(':checked')) {
                totalecalcolato = totaleattuale + importo;
            }
            else {
                totalecalcolato = totaleattuale - importo;
            }

            $("#totale").html(totalecalcolato);
        });   
    });  
</script>

</asp:Content>