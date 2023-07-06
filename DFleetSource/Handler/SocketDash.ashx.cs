// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="SocketDash.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.WebSockets;
using BusinessLogic;
using BusinessObject;
using DFleet.Classes;
using Newtonsoft.Json;


namespace DFleet.Handler
{
    /// <summary>
    /// Summary description for SocketDash
    /// </summary>
    public class SocketDash : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private static List<AspNetWebSocket> _sockets = new List<AspNetWebSocket>();
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                // Set up WebSocket connection
                context.AcceptWebSocketRequest(HandleWebSocket);
            }
        }

        public async Task HandleWebSocket(AspNetWebSocketContext webSocketContext)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            var webSocket = webSocketContext.WebSocket;

            // Subscribe the socket to the "tickets" channel
            await SendSubscriptionMessage(webSocket);

            // Continuously read incoming messages
            while (webSocket.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var messageBytes = new byte[result.Count];
                    Array.Copy(buffer.Array, messageBytes, result.Count);
                    var message = Encoding.UTF8.GetString(messageBytes);

                    var numTickets = "";

                    IUtilitys data = servizioUtility.ViewDashAdmin(Uidtenant);
                    if (data != null)
                    {
                        numTickets = data.Ticketaperti.ToString();
                    }

                    // Visualizza il valore di numTickets come JSON
                    var json = JsonConvert.SerializeObject(numTickets, Formatting.Indented);
                    HttpContext.Current.Response.ContentType = "application/json";
                    HttpContext.Current.Response.Write(json);


                    // Echo message back to client
                    var responseBytes = Encoding.UTF8.GetBytes("Echo: " + message);
                    var responseBuffer = new ArraySegment<byte>(responseBytes);
                    await webSocket.SendAsync(responseBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                }

            }
        }


        public async Task SendSubscriptionMessage(WebSocket socket)
        {
            var message = new
            {
                type = "subscribe",
                channel = "/topic/tickets"
            };

            var jsonMessage = JsonConvert.SerializeObject(message);
            var buffer = Encoding.UTF8.GetBytes(jsonMessage);

            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Codsocieta;
            }

            return retVal;
        }
    }
}
