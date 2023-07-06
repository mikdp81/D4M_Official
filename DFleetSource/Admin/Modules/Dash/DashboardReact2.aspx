<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DashboardReact2.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.DashboardReact2" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<!-- Includiamo le librerie React, ReactDOM, SockJS, e Stomp.js -->
<script src="https://unpkg.com/react@16/umd/react.development.js" crossorigin></script>
<script src="https://unpkg.com/react-dom@16/umd/react-dom.development.js" crossorigin></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/sockjs-client/1.5.2/sockjs.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/stomp.js/2.3.3/stomp.min.js"></script>

<!-- Includiamo Babel per la trasformazione del codice JSX -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/babel-standalone/6.24.0/babel.min.js"></script>
<script src="https://unpkg.com/axios/dist/axios.min.js"></script>




<% if (Approvatore() == 2) {  // DASHBOARD HR %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2 ">
            <div class="white-box bg-black height200">
                <img src="/plugins/images/logod4mobility.png" style="max-width:100%">                        
            </div>
        </div>
    
        <div class="col-md-8">
            <div class="row" >
                <div class="row" >
                    <div class="col-md-4">
                        <div class="white-box-dash  bg-black  ecom-stat-widget">
                            <div class="row">                              
                                <span class="font-bold text-red">
                                    <asp:Label ID="Label1" runat="server" Text="0"></asp:Label> </span>
                                <p class="font-12"> </p>                                                    
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                               
                                <span class="font-bold "><asp:Label ID="Label2" runat="server" Text="0"></asp:Label> </span>
                                <p class="font-12"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                           
                                <span class="text-white font-light"><asp:Label ID="Label3" runat="server" Text="0"></asp:Label> </span>
                                <p class="font-12"> </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="white-box-dash bg-black ecom-stat-widget">
                            <div class="row">                             
                                <span class="font-bold text-verde"><asp:Label ID="Label4" runat="server" Text="0"></asp:Label> </span>
                                <p class="font-12"></p> 
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>


        <div class="col-md-1"></div>
           
    </div>          
</div>

<% } %>




<% if (Approvatore() == 1) {  // DASHBOARD APPROVATORE %>
    

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2">
            <div class="white-box bg-black height200">
                <img src="/plugins/images/logod4mobility.png" style="max-width:100%">                        
            </div>
        </div>    
        <div class="col-md-8">
            <div class="row">
                <div id="rootPEP"></div>
            </div>
        </div>
        <div class="col-md-1"></div>
    </div>          
</div>


<script type="text/babel">
function DashboardPEP() {
  const [data, setData] = React.useState({ Carpolicydaautorizzare: 0, Carpolicyinviaremail: 0, Configurazionidaautorizzarepp: 0, Autorunning: 0, Autopool: 0, Ordini: 0 });

  const fetchData = async () => {
    const result = await axios('/Handler/DashReactPEP.ashx');
    setData({ Carpolicydaautorizzare: result.data.Carpolicydaautorizzare, Carpolicyinviaremail: result.data.Carpolicyinviaremail, Configurazionidaautorizzarepp: result.data.Configurazionidaautorizzarepp,
    Autorunning: result.data.Autorunning, Autopool: result.data.Autopool, Ordini: result.data.Ordini });
  };


  React.useEffect(() => {
    fetchData();
    const intervalId = setInterval(() => {
      fetchData();
    }, 5000);
    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className="row" >
        <div className="col-md-4">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">
                    <span className="font-bold text-red"><span id="ContentBody_lblcarpolicydaautorizzare">{data.Carpolicydaautorizzare}</span></span>
                    <p className="font-12">CarPolicy da autorizzare</p>
                </div>
            </div>
        </div>
        <div className="col-md-4">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold"><span id="ContentBody_lblcarpolicyinviaremail">{data.Carpolicyinviaremail}</span></span>
                    <p className="font-12">CarPolicy da inviare mail</p>
                </div>
            </div>
        </div>
        <div className="col-md-4">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="text-white font-light"><span id="ContentBody_lblconfigurazionidaautorizzarepp">{data.Configurazionidaautorizzarepp}</span> </span>
                    <p className="font-12">Configurazioni da autorizzare</p>
                </div>
            </div>
        </div>
        <div className="col-md-4">
            <div className="white-box-dash  bg-black  ecom-stat-widget">
                <div className="row">                              
                    <span className="font-bold text-verde"><span id="ContentBody_lblautorunning">{data.Autorunning}</span> </span>
                    <p className="font-12">Auto in running</p>                                                    
                </div>
            </div>
        </div>
        <div className="col-md-4">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-verde"><span id="ContentBody_lblautopool">{data.Autopool}</span> </span>
                    <p className="font-12">Auto in pool</p>
                </div>
            </div>
        </div>
        <div className="col-md-4">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="font-bold text-verde"><span id="ContentBody_lblordini">{data.Ordini}</span> </span>
                    <p className="font-12">Ordini in corso</p> 
                </div>
            </div>
        </div>
    </div>
  );
}

ReactDOM.render(<DashboardPEP />, document.getElementById("rootPEP"));
</script>


<% } %>



<% if (Approvatore() == 0) {  // DASHBOARD ADMIN %>


<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2">
            <div class="white-box bg-black height310">
                <img src="/plugins/images/logod4mobility.png" style="max-width:100%">                        
            </div>
        </div>    
        <div class="col-md-8">
            <div class="row">
                <div id="root"></div>
            </div>
        </div>
        <div class="col-md-1"></div>
    </div>          
</div>

<script type="text/babel">
function Dashboard() {
  const [data, setData] = React.useState({ Ticketaperti: 0, Ticketlavorazione: 0, Ticketchiusi: 0, Ticketcancellati: 0, Carpolicydaautorizzare: 0, Configurazionidaautorizzare: 0, 
    Confermedafirmare: 0, Ztldafirmare: 0, Inoffertarenter: 0, Offertedainviareadriver: 0, Offertevalutazioneadriver: 0, Ordinievasione: 0, Documentipolicydacontrollare: 0, 
    Autoritiro: 0, Autoconsegna: 0, Fringebenefitdacalcolare: 0 });

  const fetchData = async () => {
    const result = await axios('/Handler/DashReact.ashx');
    setData({ Ticketaperti: result.data.Ticketaperti, Ticketlavorazione: result.data.Ticketlavorazione, Ticketchiusi: result.data.Ticketchiusi, Ticketcancellati: result.data.Ticketcancellati,
    Carpolicydaautorizzare: result.data.Carpolicydaautorizzare, Configurazionidaautorizzare: result.data.Configurazionidaautorizzare, Confermedafirmare: result.data.Confermedafirmare, 
    Ztldafirmare: result.data.Ztldafirmare, Inoffertarenter: result.data.Inoffertarenter, Offertedainviareadriver: result.data.Offertedainviareadriver, 
    Offertevalutazioneadriver: result.data.Offertevalutazioneadriver, Ordinievasione: result.data.Ordinievasione, Documentipolicydacontrollare: result.data.Documentipolicydacontrollare, 
    Autoritiro: result.data.Autoritiro, Autoconsegna: result.data.Autoconsegna, Fringebenefitdacalcolare: result.data.Fringebenefitdacalcolare });
  };


  React.useEffect(() => {
    fetchData();
    const intervalId = setInterval(() => {
      fetchData();
    }, 5000);
    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className="row" >
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">
                    <span className="font-bold text-red"><span id="ContentBody_lblticketaperti">{data.Ticketaperti}</span></span>
                    <p className="font-12">Ticket aperti</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-verde"><span id="ContentBody_lblticketlavorazione">{data.Ticketlavorazione}</span></span>
                    <p className="font-12">Ticket in lavorazione</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="text-white font-light"><span id="ContentBody_lblticketchiusi">{data.Ticketchiusi}</span> </span>
                    <p className="font-12">Ticket chiusi</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="text-white font-light"><span id="ContentBody_lblticketcancellati">{data.Ticketcancellati}</span> </span>
                    <p className="font-12">Ticket cancellati</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash  bg-black  ecom-stat-widget">
                <div className="row">                              
                    <span className="font-bold text-verde">
                        <span id="ContentBody_lblcarpolicypep">{data.Carpolicydaautorizzare}</span> </span>
                    <p className="font-12">Carpolicy P&amp;P</p>                                                    
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-verde"><span id="ContentBody_lblconfigurazionidaautorizzare">{data.Configurazionidaautorizzare}</span> </span>
                    <p className="font-12">Configurazioni P&amp;P</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-verde"><span id="ContentBody_lblconfermedafirmare">{data.Confermedafirmare}</span> </span>
                    <p className="font-12">Ordini da firmare</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="font-bold text-verde"><span id="ContentBody_lbldeleghedafirmare">{data.Ztldafirmare}</span> </span>
                    <p className="font-12">Deleghe/ZTL da firmare</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash  bg-black  ecom-stat-widget">
                <div className="row">                              
                    <span className="font-bold text-verde"><span id="ContentBody_lblinoffertarenter">{data.Inoffertarenter}</span> </span>
                    <p className="font-12">In offerta renter</p>                                                    
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-red"><span id="ContentBody_lbloffertedainviareadriver">{data.Offertedainviareadriver}</span> </span>
                    <p className="font-12">Offerte da inviare a driver</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="text-verde font-bold"><span id="ContentBody_lbloffertevalutazione">{data.Offertevalutazioneadriver}</span> </span>
                    <p className="font-12">Offerte in valutazione driver</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="text-white font-light"><span id="ContentBody_lblordinievasione">{data.Ordinievasione}</span> </span>
                    <p className="font-12">Ordini in evasione</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash  bg-black  ecom-stat-widget">
                <div className="row">                              
                    <span className="font-bold text-red">
                        <span id="ContentBody_lblcarpolicydacontrollare">{data.Documentipolicydacontrollare}</span> </span>
                    <p className="font-12">CarPolicy da controllare</p>                                                    
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-red"><span id="ContentBody_lblautoritiro">{data.Autoritiro}</span> </span>
                    <p className="font-12">Auto in ritiro</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblautoconsegna">{data.Autoconsegna}</span> </span>
                    <p className="font-12">Auto in consegna</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblfringebenefitdacalcolare">{data.Fringebenefitdacalcolare}</span> </span>
                    <p className="font-12">Fringe benefit da calcolare</p>
                </div>
            </div>
        </div>
    </div>
  );
}

ReactDOM.render(<Dashboard />, document.getElementById("root"));
</script>


<% } %>



<% if (Approvatore() == 3) {  // DASHBOARD PARTNER %>

<div class="row">
    <div class="col-md-12">
        <div class="col-md-1"></div>
        <div class="col-md-2">
            <div class="white-box bg-black height310">
                <img src="/plugins/images/logod4mobility.png" style="max-width:100%">                        
            </div>
        </div>    
        <div class="col-md-8">
            <div class="row">
                <div id="rootPartner"></div>
            </div>
        </div>
        <div class="col-md-1"></div>
    </div>          
</div>

<script type="text/babel">
function DashboardPartner() {
  const [data, setData] = React.useState({ Ticketaperti: 0, Ticketlavorazione: 0, Ticketchiusi: 0, Ticketcancellati: 0, Confermedafirmare: 0, Ordinievasione: 0, Ztldafirmare: 0, 
    Fringebenefitdacalcolare: 0, Autoritiro: 0, Autoconsegna: 0, Configurazionicorso: 0, Configurazionievase: 0, Penaligestire: 0, Penaliapprovate: 0, Penalicontestazione: 0});

  const fetchData = async () => {
    const result = await axios('/Handler/DashReactPartner.ashx');
    setData({ Ticketaperti: result.data.Ticketaperti, Ticketlavorazione: result.data.Ticketlavorazione, Ticketchiusi: result.data.Ticketchiusi, Ticketcancellati: result.data.Ticketcancellati,
     Confermedafirmare: result.data.Confermedafirmare, Ordinievasione: result.data.Ordinievasione, Ztldafirmare: result.data.Ztldafirmare, Fringebenefitdacalcolare: result.data.Fringebenefitdacalcolare,
     Autoritiro: result.data.Autoritiro, Autoconsegna: result.data.Autoconsegna, Configurazionicorso: result.data.Configurazionicorso, Configurazionievase: result.data.Configurazionievase, 
     Penaligestire: result.data.Penaligestire, Penaliapprovate: result.data.Penaliapprovate, Penalicontestazione: result.data.Penalicontestazione});
  };


  React.useEffect(() => {
    fetchData();
    const intervalId = setInterval(() => {
      fetchData();
    }, 5000);
    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className="row" >
        <div className="col-md-3">
            <div className="white-box-dash  bg-black  ecom-stat-widget">
                <div className="row">                              
                    <span className="font-bold text-red"><span id="ContentBody_lblticketapertiPart">{data.Ticketaperti}</span> </span>
                    <p className="font-12">Ticket aperti</p>                                                    
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-verde"><span id="ContentBody_lblticketlavorazionePart">{data.Ticketlavorazione}</span> </span>
                    <p className="font-12">Ticket in lavorazione</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="text-white font-light"><span id="ContentBody_lblticketchiusiPart">{data.Ticketchiusi}</span> </span>
                    <p className="font-12">Ticket chiusi</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="text-white font-light"><span id="ContentBody_lblticketcancellatiPart">{data.Ticketcancellati}</span> </span>
                    <p className="font-12">Ticket cancellati</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-verde"><span id="ContentBody_lblconfermedafirmarePart">{data.Confermedafirmare}</span> </span>
                    <p className="font-12">Ordini da firmare</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="text-white font-light"><span id="ContentBody_lblordinievasionePart">{data.Ordinievasione}</span> </span>
                    <p className="font-12">Ordini in evasione</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                             
                    <span className="font-bold text-verde"><span id="ContentBody_lbldeleghedafirmarePart">{data.Ztldafirmare}</span> </span>
                    <p className="font-12">Deleghe/ZTL da firmare</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblfringebenefitdacalcolarePart">{data.Fringebenefitdacalcolare}</span> </span>
                    <p className="font-12">Fringe benefit da calcolare</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-red"><span id="ContentBody_lblautoritiroPart">{data.Autoritiro}</span> </span>
                    <p className="font-12">Auto in ritiro</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblautoconsegnaPart">{data.Autoconsegna}</span> </span>
                    <p className="font-12">Auto in consegna</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblconfigurazionicorsoPart">{data.Configurazionicorso}</span> </span>
                    <p className="font-12">Configurazioni in corso</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblconfigurazionievasePart">{data.Configurazionievase}</span> </span>
                    <p className="font-12">Configurazioni evase</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                               
                    <span className="font-bold text-red"><span id="ContentBody_lblpenaligestirePart">{data.Penaligestire}</span> </span>
                    <p className="font-12">Penali da gestire</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblpenaliapprovatePart">{data.Penaliapprovate}</span> </span>
                    <p className="font-12">Penali approvate</p>
                </div>
            </div>
        </div>
        <div className="col-md-3">
            <div className="white-box-dash bg-black ecom-stat-widget">
                <div className="row">                           
                    <span className="font-bold text-red"><span id="ContentBody_lblpenalicontestazionePart">{data.Penalicontestazione}</span> </span>
                    <p className="font-12">Penali contestazione</p>
                </div>
            </div>
        </div>
    </div>
  );
}

ReactDOM.render(<DashboardPartner />, document.getElementById("rootPartner"));
</script>



<% } %>







<div class="row">
    <div class="col-md-1"></div>
    
    <div class="col-md-4">                        
        <img src="../../../plugins/images/memo.svg" alt="Memo" style="height:30px" />

        <div class="white-box-noborder">
            <div class="task-widget2">
                <div class="task-image">
                    <div class="task-add-btn">
                        <a href="../Utility/InsTask" class="btn btn-success">+</a>
                    </div>
                </div>
                <div class="task-total">
                    <p class="font-16 m-b-0"><strong><asp:Label ID="lblCountTask" runat="server" Text=""></asp:Label></strong> Tasks da elaborare</p>
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
    <div class="col-md-6">                        
        <img src="../../../plugins/images/help_desk.svg" alt="Ultime Comunicazioni" style="height:30px" />

        <div class="white-box activity-widget">
            <div class="steamline">
                                        
                
                <% if (Approvatore() == 3) {  // COMUNICAZIONI PARTNER %>

                <!-- Lista Ultime Com -->
                <asp:GridView ID="gvUltimeCom3" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom3" CssClass="display nowrap " 
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
                                            <%# Eval("datainvio") %> <br /><strong><%# Eval("cognome") %></strong><br />
                                            <a href="../EPartner/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5ComunicazioniPartner" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                <% } %>



                <% if (Approvatore() == 1) {  // COMUNICAZIONI APPROVATORE %>

                <!-- Lista Ultime Com -->
                <asp:GridView ID="gvUltimeCom2" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsUltimeCom2" CssClass="display nowrap " 
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
                                            <%# Eval("datainvio") %> <br /><strong><%# Eval("cognome") %></strong><br />
                                            <a href="../Ticket/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectTop5Comunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                <% } %>



                
                <% if (Approvatore() == 0) {  // COMUNICAZIONI ADMIN %>

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
                                            <%# Eval("datainvio") %><br /> <strong><%# Eval("cognome") %></strong><br />
                                            <a href="../Ticket/DetailCom-<%# Eval("UIDcomunicazione") %>" class="text-link font-semibold"><%# Eval("oggetto") %></a><br />
                                            <%# Eval("statuscomunicazione").ToString().ToUpper() %>
                                        </div>                                    
                                    </div>
                                </div>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUltimeCom" runat="server" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="SelectTop5ComunicazioniAdmin" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                
                <% } %>


            </div>
        </div>
                   
    </div>

</div>


<asp:HiddenField ID="hduiduser" runat="server" />



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
    });  

</script>

</asp:Content>