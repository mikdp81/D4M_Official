<%@ Page Title="Ordine" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewConf.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ViewConf" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box no-print">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ordine</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
                <a href="<%=UrlCreaPdf()%>" class="btn btn-info waves-effect waves-light m-t-10">Rigenera PDF Configurazione</a> 
            </div>		
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-6">
                <h5>Dati Ordine</h5>
                <asp:Label ID="lblDatiOrdine" runat="server" Text="" />
            </div>            
            <div class="col-sm-6">
                <h5>Dati Richiedente</h5>
                <asp:Label ID="lblDatiDriver" runat="server" Text="" />
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
                    <div class='table-responsive'>
                        <table class='table'>
                            <tr>
                                <td class="width30p nopadding">COD. JATO</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblCodjatoauto" runat="server" Text=""></asp:Label></h4> </td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Marca</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> </td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Modello</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Alimentazione</td>
                                <td class="width70p nopadding"><h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> / <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Cilindrata</td>
                                <td class="width70p nopadding"><h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Fringe benefit base</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                            <tr>
                                <td class="width30p nopadding">Optional canone</td>
                                <td class="width70p nopadding"><h4><asp:Label ID="lblcanoneleasing" runat="server" Text=""></asp:Label></h4></td>
                            </tr>
                        </table>
                    </div>                            
                </div>
                <div class="col-md-6"> 
                    <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12"> 
                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                <h5>Optional</h5>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal>


                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hdcount" runat="server" />
                <asp:HiddenField ID="hdcountcolor" runat="server" />
                <asp:HiddenField ID="hduid" runat="server" />

                <br /><br />
                <asp:Button ID="btnAutorizza" runat="server" onclick="btnAutorizza_Click" Text="Autorizza" CssClass="btn btn-success no-print" /> 
                <asp:Button ID="btnNonAutorizza" runat="server" onclick="btnNonAutorizza_Click" Text="Non Autorizza" CssClass="btn btn-success no-print" /> 

            </div> 
        </div>

    </div>
</div>


</asp:Content>