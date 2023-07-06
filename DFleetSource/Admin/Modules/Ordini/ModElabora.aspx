<%@ Page Title="Elabora Offerta" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModElabora.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ModElabora" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Elabora Offerta</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                            <td class="width30p nopadding">Fringe benefit base</td>
                            <td class="width70p nopadding"><h4><asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h4></td>
                        </tr>
                    </table>
                </div>                            
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-6">
                <embed src="<%=ReturnLinkPdf() %>" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
            </div>
            <div class="col-md-6">                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                
                <div class="row">
                    <div class="col-md-4">
                        <h5>Canone leasing: &euro; <asp:Label ID="lblcanoneleasing" runat="server" CssClass="font-bold importocanoneleasing" Text=""></asp:Label></h5>
                    </div>                    
                    <div class="col-md-4">
                        <h5>Canone Optional: &euro; <asp:Label ID="lblOptionalCanone" runat="server" CssClass="font-bold" Text=""></asp:Label></h5>
                    </div>                 
                    <div class="col-md-4">
                        <h5>Canone Totale: &euro; <asp:Label ID="lblCanoneTotale" runat="server" CssClass="font-bold" Text=""></asp:Label></h5>
                    </div>
                </div>

                
                <h5>Importo Totale Offerta <asp:TextBox ID="txtImportoTotaleOfferta" runat="server" Columns="20" MaxLength="20" CssClass="importototofferta"></asp:TextBox></h5>

                <h5>Nuovo Optional Canone <asp:TextBox ID="txtCanoneOfferta" runat="server" Columns="20" MaxLength="20" CssClass="importocanoneofferta"></asp:TextBox></h5>
                <br />
                                
                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br />
                
                <h5>Optional</h5>
                <div class="row">
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlOptional" runat="server" DataSourceID="odsoptional" DataTextField="optional" 
                            DataValueField="codoptional" CssClass="form-control select2" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="" Text="Scegli optional"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsoptional" runat="server" SelectMethod="SelectAllOptionalAuto" TypeName="BusinessLogic.CarsBL" OldValuesParameterFormatString="original_{0}" >
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdcodjatoauto" Name="codjatoauto" PropertyName="Value" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>  
                    </div>
                    <div class="col-md-3">
                        <a id="btnadd" class="btn btn-success">Aggiungi</a>
                    </div>
                </div>

                <br /><div class="listoptional"><asp:Literal ID="ltoptional" runat="server"></asp:Literal></div>
                <br /><div id="canoneofferta" class="font-bold" runat="server"></div>
                                
                
                <br /> 
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Numero Ordine Fornitore</label>
                            <asp:TextBox ID="txtNumOrdineFornitore" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine Fornitore"></asp:TextBox> 
                        </div>
                    </div>  
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Alimentazione</label>
                            <asp:TextBox ID="txtAlimentazione" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Alimentazione"></asp:TextBox> 
                        </div>
                    </div>  
                </div>

                <h5>Note</h5>
                <asp:TextBox ID="txtNote" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control" placeholder="Note"></asp:TextBox><br /><br />

                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdfilerental" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hduid" runat="server" />
                <asp:HiddenField ID="hdcount" runat="server" />
                <asp:HiddenField ID="hdmesicontratto" runat="server" />

                <br /><br /><br /><br />
                <asp:Button ID="btnConferma" runat="server" onclick="btnConferma_Click" Text="Conferma offerta e invia al driver" CssClass="btn btn-success" /> 

            </div> 
        </div>


    </div>
</div>


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function () {  

        $(".importototofferta").bind('input propertychange', function () {
            var totale = 0;

            var canoneleasing = new Number($(".importocanoneleasing").text().replace(",", "."));
            totale = new Number($(this).val().replace(",", ".")) - canoneleasing;

            $(".importocanoneofferta").val(totale.toFixed(2).replace(".", ","));
        });


        $(".importooptann").bind('input propertychange', function () {
            var totale = 0;
            var dataid = $(this).attr("data-id");
            var mesicontratto = new Number($("#ContentBody_hdmesicontratto").val());

            totale = new Number($(this).val().replace(",", ".")) / mesicontratto;

            $("#importo_" + dataid).val(totale.toFixed(2).replace(".", ","));
        });

        $(document).on('click', '.deleteopt', function () {

            if (window.confirm('Sei sicuro di voler cancellare questo optional?')) {
                var idordine = $(this).attr("data-id");
                var optional = $(this).attr("data-optional");
                var count = $(this).attr("data-count");
                var countopt = $("#ContentBody_hdcount").val();

                var verificadelete = $.ajax({
                    async: false,
                    url: "../../../Handler/DeleteOptional.ashx?optional=" + optional + "&idordine=" + idordine,
                    type: 'POST',
                    dataType: 'html',
                    timeout: 2000,
                }).responseText;

                if (verificadelete == "OK") {
                    $("#blockopt_" + count).remove();
                    $("#blockopt_" + count).hide();
                    $("#ContentBody_hdcount").val(new Number(countopt) - 1)
                }
                else {
                    alert("Cancellazione fallita.")
                }

            }
        });

        $(document).on('click', '#btnadd', function () {
            var codoptional = $("#ContentBody_ddlOptional").val();
            var codjatoauto = $("#ContentBody_hdcodjatoauto").val();
            var idordine = $("#ContentBody_hdidordine").val();
            var count = $("#ContentBody_hdcount").val();
            var mesi = $("#ContentBody_hdmesicontratto").val();

            if (codoptional == "") {
                alert("Scegliere un optional per poter proseguire.")
            }
            else {

                var verificainsert = $.ajax({
                    async: false,
                    url: "../../../Handler/InsertOptional.ashx?codoptional=" + codoptional + "&codjatoauto=" + codjatoauto + "&idordine=" + idordine + "&count=" + count + "&mesi=" + mesi,
                    type: 'GET',
                    dataType: 'html',
                    timeout: 2000,
                }).responseText;

                if (verificainsert == "KO") {
                    alert("Inserimento fallito.")
                }
                else {
                    $(".listoptional").append(verificainsert);
                    $("#ContentBody_hdcount").val(new Number(count) + 1)
                }

            }

        });
    });  
</script>

</asp:Content>