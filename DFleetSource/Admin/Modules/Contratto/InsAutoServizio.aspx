<%@ Page Title="Prenotazione Auto di servizio" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsAutoServizio.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsAutoServizio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Prenotazione Auto di servizio</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewAutoServizio")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <asp:Panel ID="pnlMessage" runat="server">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </asp:Panel>


    <!-- STEP 1 - SCELTA TARGA -->
    <asp:Panel ID="pnlStep1" runat="server">

        <div class="white-box">
            <div class="row">
                <div class="col-12">

                    <div class="form-body">
                        <div class="col-md-12">
                            <h3>Cerca Auto</h3>
                        </div>
                        <div class="col-md-3">
                            <label class="control-label font-bold">Targa *</label>
                            <asp:DropDownList ID="ddlTarga" runat="server" DataSourceID="odstarga" DataTextField="modello" 
                                DataValueField="targa" CssClass="form-control select2" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="" Text="Targa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odstarga" runat="server" SelectMethod="SelectTargheAutoServ" TypeName="BusinessLogic.MulteBL" >
                                <SelectParameters>
                                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <div class="col-md-3 m-l-5">
                            <label class="control-label font-bold">Driver *</label>
                            <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser" placeholder="Inserisci Driver"></asp:TextBox>
                        </div>
                        <div class="col-md-3 m-l-5">
                            <asp:HiddenField ID="hduiduser" runat="server" />
                            <br /><asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Prosegui" CssClass="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="white-box">
            <div class="row">
                <div class="col-12">
                    <div class="form-body">
                        <div class="col-md-12">
                            <h3>Cerca per data</h3>
                        </div>
                        <div class="col-md-3">
                            <label class="control-label font-bold">Data DAL *</label>
                            <asp:TextBox ID="txtDatadalsearch" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Dal"></asp:TextBox> 
                        </div>
                        <div class="col-md-3 m-l-5">
                            <label class="control-label font-bold">Data AL *</label>
                            <asp:TextBox ID="txtDataalsearch" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Al"></asp:TextBox>
                        </div>
                        <div class="col-md-3 m-l-5">
                            <br /><asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Prosegui" CssClass="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
                
                
    <!-- STEP 2 - CALENDARIO PRENOTAZIONI DELLA TARGA SELEZIONATA -->
    <asp:Panel ID="pnlStep2" runat="server">
        <div class="white-box">
            <div class="row">
                <div class="col-12">
                    Clicca sul calendario per definire la tua prenotazione<br />
                    <h4>Auto:  <asp:Label ID="lblTarga" runat="server" Text=""></asp:Label> - Driver: <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label></h4><br />
                    <div id="calendar"></div>
                </div>
            </div>
        </div>
    </asp:Panel>


                
    <!-- STEP 2B - AUTO DISPONIBILI NELLA FASCIA ORARIA SELEZIONATA -->
    <asp:Panel ID="pnlStep2b" runat="server">
        <div class="white-box">
            <div class="row">
                <div class="col-12">
                    <asp:Literal ID="ltAutodispo" runat="server"></asp:Literal>
                </div>
                <div class="col-12 m-t-5">                      
                    <asp:TextBox ID="txtNoteIns" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Aggiungere note..." TextMode="MultiLine"></asp:TextBox> 
                </div>
                <div class="col-12 m-t-5">                    
                    <asp:HiddenField ID="hdtarga" runat="server" />
                    <asp:Button ID="btnIns2" runat="server" onclick="btnIns2_Click" Text="Prenota" CssClass="btn btn-info" />
                </div>
            </div>
        </div>
    </asp:Panel>

</div>


<div class="modal fade in" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel1">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="exampleModalLabel1">Prenota</h4> 
            </div>
            <div class="modal-body">   
                <div class="row">                    
                    <div class="col-md-6">
                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Dal"></asp:TextBox>                        
                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Al"></asp:TextBox> 
                    </div>            
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlOradal" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="00:00">00:00</asp:ListItem>
                            <asp:ListItem Value="01:00">01:00</asp:ListItem>
                            <asp:ListItem Value="02:00">02:00</asp:ListItem>
                            <asp:ListItem Value="03:00">03:00</asp:ListItem>
                            <asp:ListItem Value="04:00">04:00</asp:ListItem>
                            <asp:ListItem Value="05:00">05:00</asp:ListItem>
                            <asp:ListItem Value="06:00">06:00</asp:ListItem>
                            <asp:ListItem Value="07:00">07:00</asp:ListItem>
                            <asp:ListItem Value="08:00">08:00</asp:ListItem>
                            <asp:ListItem Value="09:00">09:00</asp:ListItem>
                            <asp:ListItem Value="10:00">10:00</asp:ListItem>
                            <asp:ListItem Value="11:00">11:00</asp:ListItem>
                            <asp:ListItem Value="12:00">12:00</asp:ListItem>
                            <asp:ListItem Value="13:00">13:00</asp:ListItem>
                            <asp:ListItem Value="14:00">14:00</asp:ListItem>
                            <asp:ListItem Value="15:00">15:00</asp:ListItem>
                            <asp:ListItem Value="16:00">16:00</asp:ListItem>
                            <asp:ListItem Value="17:00">17:00</asp:ListItem>
                            <asp:ListItem Value="18:00">18:00</asp:ListItem>
                            <asp:ListItem Value="19:00">19:00</asp:ListItem>
                            <asp:ListItem Value="20:00">20:00</asp:ListItem>
                            <asp:ListItem Value="21:00">21:00</asp:ListItem>
                            <asp:ListItem Value="22:00">22:00</asp:ListItem>
                            <asp:ListItem Value="23:00">23:00</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlOraal" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="00:00">00:00</asp:ListItem>
                            <asp:ListItem Value="01:00">01:00</asp:ListItem>
                            <asp:ListItem Value="02:00">02:00</asp:ListItem>
                            <asp:ListItem Value="03:00">03:00</asp:ListItem>
                            <asp:ListItem Value="04:00">04:00</asp:ListItem>
                            <asp:ListItem Value="05:00">05:00</asp:ListItem>
                            <asp:ListItem Value="06:00">06:00</asp:ListItem>
                            <asp:ListItem Value="07:00">07:00</asp:ListItem>
                            <asp:ListItem Value="08:00">08:00</asp:ListItem>
                            <asp:ListItem Value="09:00">09:00</asp:ListItem>
                            <asp:ListItem Value="10:00">10:00</asp:ListItem>
                            <asp:ListItem Value="11:00">11:00</asp:ListItem>
                            <asp:ListItem Value="12:00">12:00</asp:ListItem>
                            <asp:ListItem Value="13:00">13:00</asp:ListItem>
                            <asp:ListItem Value="14:00">14:00</asp:ListItem>
                            <asp:ListItem Value="15:00">15:00</asp:ListItem>
                            <asp:ListItem Value="16:00">16:00</asp:ListItem>
                            <asp:ListItem Value="17:00">17:00</asp:ListItem>
                            <asp:ListItem Value="18:00">18:00</asp:ListItem>
                            <asp:ListItem Value="19:00">19:00</asp:ListItem>
                            <asp:ListItem Value="20:00">20:00</asp:ListItem>
                            <asp:ListItem Value="21:00">21:00</asp:ListItem>
                            <asp:ListItem Value="22:00">22:00</asp:ListItem>
                            <asp:ListItem Value="23:00">23:00</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div> 
                <div class="row m-t-5">                    
                    <div class="col-md-12">   
                        <input type="checkbox" runat="server" name="intera" id="intera" value="SI" /> Intera giornata <br />
                        <input type="checkbox" runat="server" name="metaam" id="metaam" value="SI" /> Mattina <br />
                        <input type="checkbox" runat="server" name="metapm" id="metapm" value="SI" /> Pomeriggio <br />
                    </div>
                </div>
                <div class="row m-t-5">                    
                    <div class="col-md-12">                     
                        <asp:TextBox ID="txtNote" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Aggiungere note..." TextMode="MultiLine"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnIns" runat="server" onclick="btnIns_Click" Text="Prenota" CssClass="btn btn-info" />
            </div>
        </div>
    </div>
</div>


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script src='<%=ResolveUrl("~/plugins/components/calendar/dist/fullcalendar.min.js")%>'></script>
<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js"></script>

<script type="text/javascript">  
    $(document).ready(function () {
        $(".autotarga").autocomplete({
            source: "../../../Handler/ListTargheAutoServ.ashx"
        });
        $(".autouser").autocomplete({
            source: "../../../Handler/ListDriver.ashx",
            select: function (event, ui) {
                $("#ContentBody_txtUsers").val(ui.item.label);
                $("#ContentBody_hduiduser").val(ui.item.value);
                return false;
            }
        });
        $(".close").click(function () {
            $("#exampleModal").hide();
        });
        $("#ContentBody_intera").change(function () {
            if (this.checked)
            {
                $("#ContentBody_ddlOradal").prop("disabled", true);
                $("#ContentBody_ddlOraal").prop("disabled", true);
            }
            else
            {
                $("#ContentBody_ddlOradal").prop("disabled", false);
                $("#ContentBody_ddlOraal").prop("disabled", false);
            }
        });
        $("#ContentBody_metaam").change(function () {
            if (this.checked)
            {
                $("#ContentBody_ddlOradal").prop("disabled", true);
                $("#ContentBody_ddlOraal").prop("disabled", true);
            }
            else {
                $("#ContentBody_ddlOradal").prop("disabled", false);
                $("#ContentBody_ddlOraal").prop("disabled", false);
            }
        });
        $("#ContentBody_metapm").change(function () {
            if (this.checked)
            {
                $("#ContentBody_ddlOradal").prop("disabled", true);
                $("#ContentBody_ddlOraal").prop("disabled", true);
            }
            else {
                $("#ContentBody_ddlOradal").prop("disabled", false);
                $("#ContentBody_ddlOraal").prop("disabled", false);
            }
        });

        $(".oradal").change(function () {
            var dataId = $(this).data('id');
            $("#ContentBody_hdtarga").val("");
            $("#ContentBody_hdtarga").val(dataId);
            var currentSelect = $(this);
            $('.oradal').not(currentSelect).val('');
        });
        $(".oraal").change(function () {
            var dataId = $(this).data('id');
            $("#ContentBody_hdtarga").val("");
            $("#ContentBody_hdtarga").val(dataId);
            var currentSelect = $(this);
            $('.oraal').not(currentSelect).val('');
        });
    });  
</script>

    
<script type="text/javascript">  
    $(document).ready(function () {

        var drag = function () {
            $('.calendar-event').each(function () {

                // store data so the calendar knows to render an event upon drop
                $(this).data('event', {
                    title: $.trim($(this).text()), // use the element's text as the event title
                    stick: true // maintain when user navigates (see docs on the renderEvent method)
                });

                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 1111999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });
            });
        };

        var removeEvent = function () {
            $('.remove-calendar-event').click(function () {
                $(this).closest('.calendar-event').fadeOut();
                return false;
            });
        };

        $(".add-event").keypress(function (e) {
            if ((e.which == 13) && (!$(this).val().length == 0)) {
                $('<div class="calendar-event">' + $(this).val() + '<a href="javascript:void(0);" class="remove-calendar-event"><i class="ti-close"></i></a></div>').insertBefore(".add-event");
                $(this).val('');
            } else if (e.which == 13) {
                alert('Please enter event name');
            }
            drag();
            removeEvent();
        });


        drag();
        removeEvent();

        var date = new Date();
        var day = date.getDate();
        var month = date.getMonth();
        var year = date.getFullYear();

        $('#calendar').fullCalendar({
            monthNames: ['Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno', 'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'],
            monthNamesShort: ['Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Giu', 'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dic'],
            dayNames: ['Domenica', 'Lunedì', 'Martedì', 'Mercoledì', 'Giovedì', 'Venerdì', 'Sabato'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab'],
            defaultView: "agendaWeek",
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            dayClick: function (date, jsEvent, view) {
                $("#exampleModal").show();
                var datafin = "";
                var dateStr = moment(date).format("DD/MM/YYYY");
                var oreStr = moment(date).format("HH");
                var orealStr = moment(date).add(1, 'hour').format("HH");
                if (oreStr == "23") {
                    datafin = moment(date).add(1, 'day').format("DD/MM/YYYY");
                }
                else {
                    datafin = dateStr;
                }
                $("#ContentBody_txtDatadal").val(dateStr);
                $("#ContentBody_txtDataal").val(datafin);
                $("#ContentBody_ddlOradal").val(oreStr + ":00");
                $("#ContentBody_ddlOraal").val(orealStr + ":00");
            },
            editable: false,
            droppable: false, // this allows things to be dropped onto the calendar
            eventLimit: true, // allow "more" link when too many events
            events: [
                <%=ReturnEvent() %>
            ]
        });

    }); 
</script>

</asp:Content>