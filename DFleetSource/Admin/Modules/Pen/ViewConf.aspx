<%@ Page Title="Ordine" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewConf.aspx.cs" Inherits="DFleet.Admin.Modules.Pen.ViewConf" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ordine</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Pen/OrdiniInCorso")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
             <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> / <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit base<br>
            <h4> <asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h4></div> <br>
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
    <div class="white-box">
        <div class="row">
            <div class="col-12">  
 <asp:Label ID="lbldatiordine" runat="server" Text=""></asp:Label> <br />      
    </div>


             


        </div>

        </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">        
               

                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                <h5>Optional</h5>
                <div style="text-align:right;"><strong>OPTIONAL CANONE: </strong> <span style="font-weight:bold;color:red;">&euro;</span> <asp:Label ID="lblcanoneleasing" runat="server" CssClass="font-bold" Text=""></asp:Label></div>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal>


                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hdcount" runat="server" />
                <asp:HiddenField ID="hdcountcolor" runat="server" />
                <asp:HiddenField ID="hduid" runat="server" />

            </div> 
        </div>


    </div>
</div>




</asp:Content>