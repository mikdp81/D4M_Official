<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DashboardReact.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.DashboardReact" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

       <div id="root"></div>

    <!-- Includiamo le librerie React, ReactDOM, SockJS, e Stomp.js -->
    <script src="https://unpkg.com/react@16/umd/react.development.js" crossorigin></script>
    <script src="https://unpkg.com/react-dom@16/umd/react-dom.development.js" crossorigin></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sockjs-client/1.5.2/sockjs.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/stomp.js/2.3.3/stomp.min.js"></script>

    <!-- Includiamo Babel per la trasformazione del codice JSX -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/babel-standalone/6.24.0/babel.min.js"></script>

    <script type="text/babel">
      // Definizione del componente React
      function TicketWidget() {
        const [numTickets, setNumTickets] = React.useState(null); // Stato iniziale: valore nullo

        // Connette al server WebSocket e registra un ascoltatore per i messaggi in arrivo
        React.useEffect(() => {
          const socket = new SockJS("/Handler/SocketDash.ashx"); // Connessione al server WebSocket
          const stompClient = Stomp.over(socket); // Creazione del client STOMP
          stompClient.connect({}, function(frame) {
            stompClient.subscribe("/topic/tickets", function(message) {
              const data = JSON.parse(message.body);
              setNumTickets(data.numTickets);
            });
          });

          return () => {
            stompClient.disconnect(); // Disconnessione dal server WebSocket quando il componente viene smontato
          };
        }, []);

        // Ritorna la rappresentazione visuale del componente
        if (numTickets === null) {
          return  <div className="col-md-3">
              <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">
                  <span className="font-bold text-red">
                    <span id="ContentBody_lblticketaperti">0</span>
                  </span>
                  <p className="font-12">Ticket aperti</p>
                </div>
              </div>
            </div>;
        } else {
          return (
            <div className="col-md-3">
              <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">
                  <span className="font-bold text-red">
                    <span id="ContentBody_lblticketaperti">{numTickets}</span>{" "}
                  </span>
                  <p className="font-12">Ticket aperti</p>
                </div>
              </div>
            </div>
          );
        }
      }

      // Renderizza il componente React nel documento HTML
      ReactDOM.render(<TicketWidget />, document.getElementById("root"));
    </script>

</asp:Content>