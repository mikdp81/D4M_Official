<%@ Page Title="Calendario Attivita" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewCalendario.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ViewCalendario" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Calendario Attivit&agrave;</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <div id="calendar"></div>
            </div> 
        </div>
    </div>
</div>

    
<asp:HiddenField ID="hduiduser" runat="server" />


</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">
    
<script src='<%=ResolveUrl("~/plugins/components/calendar/dist/fullcalendar.min.js")%>'></script>
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

            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar
            eventLimit: true, // allow "more" link when too many events
            events: [
                <%=ReturnEvent() %>
            ]
        });

    }); 
</script>

</asp:Content>