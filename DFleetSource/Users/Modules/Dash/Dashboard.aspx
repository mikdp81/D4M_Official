<%@ Page Title="" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DFleet.Users.Modules.Dash.Dashboard" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
         
    <asp:Literal ID="ltavvisi" runat="server"></asp:Literal>
    
    <asp:Literal ID="ltplafond" runat="server"></asp:Literal>

    <asp:Panel ID="pnlCar" runat="server">
       
    <div class="row">
        <div class="col-md-2" style="padding-right:0;">
            <div style="background-color:#89BA17;height:35px;">
                <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">My Car</div>
            </div>
        </div>
        <div class="col-md-10" style="padding-left:0;">
            <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
        </div>
    </div>
    <div class="white-box-borderleftgreen">
        <div class="row">
            <div class="col-12" runat="server" id="panelCar">               
                
                <div class="col-lg-4"> 
                    <div class="col-12 color-green-underline">Rental</div>
                    <h4 class="font-bold"><span ><asp:Label ID="lblRental" runat="server" Text=""></asp:Label></span></h4><br /> 
                    <div class="color-green-underline">Modello</div>
                    <h4 class="font-bold"><span id="ContentBody_lblModello"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></span></h4><br />
                    <div class="color-green-underline">Targa</div><br />
                    <div style="background:url('../../../plugins/images/dash/Targa.svg') no-repeat; width:160px; height:35px; line-height:35px; text-align:center; font-size:23px; font-weight:bold;">
                        <span class="colorblack"><asp:Label ID="lblTarga" runat="server" Text=""></asp:Label></span>
                    </div> 
                </div>
                <div class="col-lg-3 spacemob1"></div>
                <div class="col-lg-3"> 
                    <div class="row text-center">                   
                        <span id="ContentBody_lblFoto" class="text-center"><asp:Label ID="lblimgauto" runat="server" Text=""></asp:Label></span>     
                        <div class="font-10 fontitalic">L'immagine &egrave; puramente indicativa</div>
                        <div class="font-10 fontitalic m-b-20">e potrebbe non rispecchiare appieno le caratteristiche dell'auto.</div>
                    </div>     
                </div>
                
                <div class="col-lg-2 spacemob2"> 
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-3">
                                    <div style="background-color:#89ba17; width:50px; height:50px; line-height:50px; border-radius:50%; text-align:center;" class="datiauto-mob">
                                        <img src="../../../plugins/images/dash/in_uso_dal.svg" alt="" width="40" border="0" /> 
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="text-verde font-bold font-16 text-center-mob">In uso dal</div>
                                    <div class="font-bold m-t-3 colorblack font-16 text-center-mob"><asp:Label ID="lbldataritiro" runat="server" Text=""></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 m-t-20">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div style="background-color:#89ba17; width:50px; height:50px; line-height:50px; border-radius:50%; text-align:center;" class="datiauto-mob">
                                                <img src="../../../plugins/images/dash/km_attuali.svg" alt="" width="40" border="0" /> 
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="text-verde font-bold font-16 text-center-mob">Km attuali</div>
                                            <div class="font-bold m-t-3 colorblack font-16 text-center-mob"><asp:Label ID="lblkmpercorsi" runat="server" Text=""></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 m-t-20">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div style="background-color:#89ba17; width:50px; height:50px; line-height:50px; border-radius:50%; text-align:center;" class="datiauto-mob">
                                                <img src="../../../plugins/images/dash/fuel.svg" alt="" width="40" border="0" /> 
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="text-verde font-bold font-16 text-center-mob">Fuel <asp:Label ID="lblannocorrente" runat="server" Text=""></asp:Label></div>
                                            <div class="font-bold m-t-3 colorblack font-16 text-center-mob"><asp:Label ID="lblfuel" runat="server" Text=""></asp:Label> &euro;</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 m-t-20">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div style="background-color:#89ba17; width:50px; height:50px; line-height:50px; border-radius:50%; text-align:center;" class="datiauto-mob">
                                                <img src="../../../plugins/images/dash/data_di_revisione.svg" alt="" width="40" border="0" /> 
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="text-verde font-bold font-16 text-center-mob">Data di revisione</div>
                                            <div class="font-bold m-t-3 colorblack font-16 text-center-mob"><asp:Label ID="lbldatarestituzione" runat="server" Text=""></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>   
                    </div>
                </div>
            </div>
        </div>

        <div class="row m-t-60">
            <div class="col-md-2"></div> 
            <div class="col-md-8">                      
                <div class="row line-steps">
                    <div class="col-md-3 step1 column-step start <%=ReturnSituazioneAuto("fase1")%> ">
                        <div class="step-number"><img src="../../../plugins/images/dash/ordina.svg" alt="" width="30" border="0" class="imgstep1" style="margin-top:2px;" /> </div>
                        <div class="step-title m-t-5 font-bold">Ordina</div>                                
                    </div>
                    <div class="col-md-3 step2 column-step <%=ReturnSituazioneAuto("fase2")%>">
                        <div class="step-number"><img src="../../../plugins/images/dash/ritira.svg" alt="" width="30" border="0" class="imgstep2" style="margin-top:2px;" /></div>
                        <div class="step-title m-t-5 font-bold">Ritira</div>                                 
                    </div>
                    <div class="col-md-3 step3 column-step <%=ReturnSituazioneAuto("fase3")%>">
                        <div class="step-number"><img src="../../../plugins/images/dash/guida.svg" alt="" width="30" border="0" class="imgstep3" style="margin-top:2px;" /></div>
                        <div class="step-title m-t-5 font-bold">Guida</div>                                  
                    </div>
                    <div class="col-md-3 step4 column-step finish <%=ReturnSituazioneAuto("fase4")%>">
                        <div class="step-number"><img src="../../../plugins/images/dash/restituisci.svg" alt="" width="30" border="0" class="imgstep4" style="margin-top:2px;" /></div>
                        <div class="step-title m-t-5 font-bold">Restituisci</div>                                  
                    </div>                               
                </div>
            </div>                 
        </div>
    </div>
    </asp:Panel>
        


    <!-- se la data di decorrenza deve ancora scadere - visualizza countdown -->
    <asp:Panel ID="pnlScadenzaDataDecorrenza" runat="server">
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#89BA17;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Avvisi</div>
                </div>
            </div>
            <div class="col-md-10" style="padding-left:0;">
                <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
            </div>
        </div>
        <div class='white-box-borderleftgreen font-16'>                 
            <p class="ribbon-content colorblack">Hai una configurazione in pending. Effettua la tua scelta entro: <asp:Label ID="lblScadenzaDataDecorrenza" runat="server" Text=""></asp:Label></p>
        </div>
    </asp:Panel>



    <!-- se la carpolicy contiene codcarpolicy e codcarbenefit diversi da nocar e nobenefit -->
    <asp:Panel ID="pnlTodoOrdinaOpzione2" runat="server">
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#89BA17;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">To do</div>
                </div>
            </div>
            <div class="col-md-10" style="padding-left:0;">
                <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
            </div>
        </div>
        <div class="white-box-borderleftgreen">
            <div class="row" >
                <div class="col-md-12">
                    <div class="row thin-steps">
                        <div class="col-md-6 column-step active" style="cursor:pointer;" onclick="location.href='../Ordini/ScegliBenefit'">
                            <div class="step-number">1</div>
                            <div class="step-title">Scegli tra auto aziendale e pacchetto mobilit&agrave; (clicca qui)</div>
                            <div class="step-info"></div>
                        </div>
                        <div class="col-md-6 column-step">
                            <div class="step-number">2</div>
                            <div class="step-title">Gestisci il tuo benefit</div>
                            <div class="step-info"></div>
                        </div>
                    </div>
                
                </div>
            </div>
        </div>    
    </asp:Panel>





    <!-- Se la carpolicy contiene solo la codcarpolicy -->
    <asp:Panel ID="pnlTodoOrdina" runat="server">
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#89BA17;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">To do</div>
                </div>
            </div>
            <div class="col-md-10" style="padding-left:0;">
                <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
            </div>
        </div>
        <div class="white-box-borderleftgreen">
        <div class="row" >
            <div class="col-md-12">

                <div class="row thin-steps" style="padding-left:5%;">
                    <div class="col-md-2 column-step <%=ReturnFase1()%> " <%=LinkFase1()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Firma_car_policy.svg" alt="" height="45" /></div>
                        <div class="step-title">Firma<br />Carpolicy</div>
                        <div class="step-info"></div>
                    </div>
                    <div class="col-md-2 column-step <%=ReturnFase2()%> " <%=LinkFase2()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Configura_auto.svg" alt="" height="45" /></div>
                        <div class="step-title">Configura<br />auto</div>
                        <div class="step-info"></div>
                    </div>
                    <div class="col-md-2 column-step <%=ReturnFase3()%> " <%=LinkFase3()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Attendi_offerta.svg" alt="" height="45" /></div>
                        <div class="step-title">Attendi <br /> offerta</div>
                        <div class="step-info"></div>
                    </div>
                    <div class="col-md-2 column-step <%=ReturnFase4()%> " <%=LinkFase4()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Conferma_offerta.svg" alt="" height="45" /></div>
                        <div class="step-title">Conferma <br /> offerta</div>
                        <div class="step-info"></div>
                    </div>
                    <div class="col-md-2 column-step <%=ReturnFase5()%> " <%=LinkFase5()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Attendi_evasione.svg" alt="" height="45" /></div>
                        <div class="step-title">Attendi<br /> evasione</div>
                        <div class="step-info"></div>
                    </div>
                    <div class="col-md-2 column-step <%=ReturnFase6()%> " <%=LinkFase6()%>>
                        <div class="step-number"><img src="../../../plugins/images/dash/Ritira_auto.svg" alt="" height="45" /></div>
                        <div class="step-title">Ritira<br />auto</div>
                        <div class="step-info"></div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>        
    </asp:Panel>





    <!-- se la carpolicy contiene solo la codcarbenefit -->
    <asp:Panel ID="pnlTodoOrdinaBenefit" runat="server">
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#89BA17;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">To do</div>
                </div>
            </div>
            <div class="col-md-10" style="padding-left:0;">
                <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
            </div>
        </div>
        <div class="white-box-borderleftgreen">
            <div class="row" >
                <div class="col-md-12">
                    <div class="row thin-steps">
                        <div class="col-md-6 column-step <%=ReturnFasePacchetto()%>" <%=LinkFasePacchetto()%>>
                            <div class="step-number">1</div>
                            <div class="step-title">Scegli pacchetto</div>
                            <div class="step-info"></div>
                        </div>
                        <div class="col-md-6 column-step <%=ReturnFaseWallet()%>">
                            <div class="step-number">2</div>
                            <div class="step-title">Attendi caricamento wallet</div>
                            <div class="step-info"></div>
                        </div>
                    </div>
                
                </div>
            </div>
        </div>    
    </asp:Panel>



    
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-md-4" style="padding-right:0;">
                                    <div style="background-color:#89BA17;height:35px;">
                                        <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Memo</div>
                                    </div>
                                </div>
                                <div class="col-md-8" style="padding-left:0;">
                                    <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 text-right">
                            <a href="InsTask"><img src="../../../plugins/images/dash/tastopiu.svg" alt="" class="tastopiu" height="35" /></a>  
                        </div>
                    </div>


                    <div class="white-box-borderleftgreen"> 
                        <div class="white-box-noborder">
                            <div class="task-widget2">
                                <div class="task-total">
                                    <p class="font-16 m-b-0 colorblack font-bold"><asp:Label ID="lblCountTask" runat="server" Text="" CssClass="text-verde"></asp:Label> Tasks da elaborare</p>
                                </div>
                                <div class="task-list">
                                    <ul class="list-group">
                                        
                                        <!-- Lista Task -->
                                        <asp:GridView ID="gvCom" runat="server"
                                                AutoGenerateColumns="False" DataSourceID="odsCom" CssClass="display nowrap " 
                                                GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                            <Columns>
                                                <asp:TemplateField HeaderText="">   
                                                    <ItemTemplate>
                                                        <li class="list-group-item c7_<%# Eval("idtask").ToString() %>">
                                                            <div class="checkbox checkbox-success">
                                                                <%# ReturnCheck(Eval("idtask").ToString(), Eval("esitotask").ToString(), Eval("Uid").ToString(), Eval("datatask").ToString()) %>
                                                                <label for="c7">
                                                                    <span class="font-16"><%# ReturnTesto(Eval("testotask").ToString(), Eval("linktask").ToString()) %></span>
                                                                </label>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>                    
                                                </asp:TemplateField>  
                                            </Columns>    
                                            <PagerStyle HorizontalAlign="Right" />    
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="odsCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTaskAperti" TypeName="BusinessLogic.UtilitysBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </ul>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-md-4" style="padding-right:0;">
                                    <div style="background-color:#89BA17;height:35px;">
                                        <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Help desk</div>
                                    </div>
                                </div>
                                <div class="col-md-8" style="padding-left:0;">
                                    <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 text-right">
                            <a href="InsCom"><img src="../../../plugins/images/dash/tastopiu.svg" alt="" class="tastopiu2" height="35" /></a>  
                        </div>
                    </div>
                    
                             
                    <div class="white-box-borderleftgreen">
                        <div class="white-box-noborder">
                            <div class="task-widget2">
                                <div class="task-total">
                            
                                    <asp:Panel ID="pnlMessage" runat="server">
                                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                    </asp:Panel>

                                </div>
                            </div>

                            <div class="steamline">

                                <!-- Lista Ultime Com -->
                                <asp:GridView ID="gvUltimeCom" runat="server"
                                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom" CssClass="display nowrap " 
                                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">   
                                            <ItemTemplate>
                                                <div class="sl-item">
                                                    <div class="sl-left">
                                                        <div>
                                                            <i class="icon-envelope-letter fa-fw font-20"></i>
                                                        </div>
                                                    </div>
                                                    <div class="sl-right">
                                                        <div> 
                                                            <%# Eval("datainvio") %> <%# Eval("cognome") %><br />
                                                            <a href="DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                                        </div>                                      
                                                    </div>
                                                </div>
                                            </ItemTemplate>                    
                                        </asp:TemplateField>  
                                    </Columns>    
                                    <PagerStyle HorizontalAlign="Right" />    
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsUltimeCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5Comunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                                
                                
                            </div>
                        </div>
                    </div>                   
                </div>
            </div>
           
    
<asp:HiddenField ID="hduiduser" runat="server" />
<asp:HiddenField ID="hdsceltabenefit" runat="server" />


</asp:Content>






<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">


<script type="text/javascript">  
    $(document).ready(function () {
        $(".checktask").click(function () {
            var id = $(this).attr("id");
            var uid = $(this).attr("data-id");
            var dataoggi = $(this).attr("data-day");

            var verificaupdate = $.ajax({
                async: false,
                url: "../../../Handler/UpdateTask.ashx?uid=" + uid,
                type: 'POST',
                dataType: 'html',
                timeout: 2000,
            }).responseText;

            if (verificaupdate == "OK") {
                if (dataoggi != "SI") {
                    $("." + id).hide(1000);
                }
            }
            else {
                alert("Errore! Riprova.")
            }
        });

        //tasti hover
        $(".tastopiu").hover(
            function () {
                $('.tastopiu').attr('src', '../../../plugins/images/dash/tastopiuhover.svg');
            }, function () {
                $('.tastopiu').attr('src', '../../../plugins/images/dash/tastopiu.svg');
            }
        );
        $(".tastopiu2").hover(
            function () {
                $('.tastopiu2').attr('src', '../../../plugins/images/dash/tastopiuhover.svg');
            }, function () {
                $('.tastopiu2').attr('src', '../../../plugins/images/dash/tastopiu.svg');
            }
        );

        //step line - active
        if (!$(".step1").hasClass('active')) {
            $('.imgstep1').attr('src', '../../../plugins/images/dash/ordina_black.svg');
        }
        if (!$(".step2").hasClass('active')) {
            $('.imgstep2').attr('src', '../../../plugins/images/dash/ritira_black.svg');
        }
        if (!$(".step3").hasClass('active')) {
            $('.imgstep3').attr('src', '../../../plugins/images/dash/guida_black.svg');
        }
        if (!$(".step4").hasClass('active')) {
            $('.imgstep4').attr('src', '../../../plugins/images/dash/restituisci_black.svg');
        }

    });  

</script>

</asp:Content>