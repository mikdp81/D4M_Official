<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-contabilita.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_contabilita" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<style>
.display tr:nth-child(even) {
    background-color: #DBEBC1;
}
.display tr:nth-child(odd) {
    background-color: #ffffff;
}
.display td {
    padding-left:5px;
    padding-right:5px;
}

.display2 tr:nth-child(even) {
    background-color: #cce8f4;
}
.display2 tr:nth-child(odd) {
    background-color: #ffffff;
}
.display2 td {
    padding-left:5px;
    padding-right:5px;
}

.display3 tr:nth-child(even) {
    background-color: #ED8B00;
}
.display3 tr:nth-child(odd) {
    background-color: #ffffff;
}
.display3 td {
    padding-left:5px;
    padding-right:5px;
}

.display4 tr:nth-child(even) {
    background-color: #72F3FF;
}
.display4 tr:nth-child(odd) {
    background-color: #ffffff;
}
.display4 td {
    padding-left:5px;
    padding-right:5px;
}

</style>

<h3>Contabilit&agrave;</h3>



<div class="row">
    <div class="col-md-4">
        <div class="white-box  bg-black  ecom-stat-widget">
            <div class="row">
                <div class="col-xs-12">
                    <span class="text-white font-light"><asp:Label ID="lblfatture" runat="server" Text=""></asp:Label></span>
                    <p class="font-12">Totale Fatture</p>
                </div>                     
            </div>
        </div>
    </div>
</div>

<div class="row">
    <div class="col-md-8 col-sm-12">
        <div class="white-box stat-widget">
            <div class="row">
                <canvas id="fatture_mese" height="80vh"></canvas>
                </div>
        </div>
    </div>
</div>



<!-- SOCIETA -->
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#0076A8;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Societ&agrave;</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_blu.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftblu small-box-widget">   
              
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_societa" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_societa_bar" height="87vh"></canvas>
        </div> 
    </div>

    <div class="row m-t-20">             
        <div class="col-md-4">
            <div id="btn_flotta4" class="btn btn-blu">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta4" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta4" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta4" CssClass="display2 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N0}", Eval("tot")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta4" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaSocieta" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display2 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot4" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("societa")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

    

<!-- SOCIETA IMPORTO -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#0076A8;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Societ&agrave; (importo)</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_blu.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftblu small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_grade" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_grade_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta5" class="btn btn-blu">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta5" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta5" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta5" CssClass="display2 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N2}", Eval("importototale")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta5" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaSocietaImporto" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <table class="display2 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot5" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("societaimporto")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table> 
        </div>
    </div>
</div>





<!-- FORNITORI -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#ED8B00;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Fornitore</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_arancio.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftarancio small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_fornitore" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_fornitore_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta7" class="btn btn-arancio">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta7" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta7" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta7" CssClass="display3 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N0}", Eval("tot")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta7" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaFornitore" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display3 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot7" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("fornitore")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>



<!-- FORNITORI IMPORTO -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#ED8B00;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Fornitore (importo)</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_arancio.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftarancio small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_fornitorecanone" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_fornitorecanone_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta8" class="btn btn-arancio">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta8" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta8" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta8" CssClass="display3 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N2}", Eval("importototale")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta8" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaFornitoreImporto" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display3 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot8" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("fornitoreimporto")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

    

<!-- TEMPLATE -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#007680;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Template</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_verdone.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftverdone small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_marca" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_marca_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta9" class="btn btn-verdone">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta9" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta9" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta9" CssClass="display4 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N0}", Eval("tot")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta9" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaTemplate" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display4 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot9" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("template")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

    

<!-- ANNUALITA -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#007680;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Template (importo)</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_verdone.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftverdone small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_annualita" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_annualita_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta10" class="btn btn-verdone">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta10" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta10" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta10" CssClass="display4 nowrap " 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">   
                        <ItemTemplate>
                            <span class="text-black"><%# Eval("etichetta") %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Right">   
                        <ItemTemplate>
                            <span class="text-black"><%#String.Format("{0:N2}", Eval("importototale")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta10" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashContabilitaTemplateImporto" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display4 nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot10" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("templateimporto")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
    

</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">


    <script src="<%=ResolveUrl("~/")%>js/chart.js"></script>
    <script src="<%=ResolveUrl("~/")%>js/chartjs-plugin-datalabels.min.js"></script>

    <script>
        $(document).ready(function () {
            $("#btn_flotta4").click(function () {
                $("#container_flotta4").toggle();
            });
            $("#btn_flotta5").click(function () {
                $("#container_flotta5").toggle();
            });
            $("#btn_flotta7").click(function () {
                $("#container_flotta7").toggle();
            });
            $("#btn_flotta8").click(function () {
                $("#container_flotta8").toggle();
            });
            $("#btn_flotta9").click(function () {
                $("#container_flotta9").toggle();
            });
            $("#btn_flotta10").click(function () {
                $("#container_flotta10").toggle();
            });
        });

        const data = {
            labels: [
                '<%=DateTime.Now.AddMonths(-5).ToString("MMMM", new CultureInfo("it-IT"))%>',
                '<%=DateTime.Now.AddMonths(-4).ToString("MMMM", new CultureInfo("it-IT"))%>',
                '<%=DateTime.Now.AddMonths(-3).ToString("MMMM", new CultureInfo("it-IT"))%>',
                '<%=DateTime.Now.AddMonths(-2).ToString("MMMM", new CultureInfo("it-IT"))%>',
                '<%=DateTime.Now.AddMonths(-1).ToString("MMMM", new CultureInfo("it-IT"))%>',
                '<%=DateTime.Now.ToString("MMMM", new CultureInfo("it-IT"))%>'
            ],
            datasets: [{
                label: 'Fatture ',
                data: [<%=ReturnNumeroFatture()%>],
                backgroundColor: [
                    'rgb(135, 189, 50)'
                ],
                hoverOffset: 4
            }]
        };

        const config = {
            type: 'line',
            data: data,
            options: {
                responsive: true,
                plugins: {
                    datalabels: {
                        color: '#000',
                        anchor: 'end',
                        align: 'top',
                        offset: 4
                    }
                }
            }
        };



        const myChart = new Chart(document.getElementById('fatture_mese'), config);
    </script>


    
<script>
    const data4 = {
        labels: [<%=ReturnValoriAuto("societa", "SI")%>],
        datasets: [{
            label: 'Societa',
            data: [<%=ReturnValoriAuto("societa", "")%>],
            backgroundColor: [
                "#004B6B",
                "#005E87",
                "#00A5EC",
                "#08B2FB",
                "#004969",
                "#006089",
                "#76D6FF",
                "#045E85",
                "#034562",
                "#022432",
                "#031D29",
                "#01131A",
                "#04202C",
                "#01A7EF",
                "#21B2F1",
                "#99D9F5",
                "#07202B",
                "#122E3A",
                "#2B3F47",
                "#2C4651",
            ],
            hoverOffset: 4
        }]
    };

    const config4 = {
        type: 'doughnut',
        data: data4,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config4bar = {
        type: 'bar',
        data: data4,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart4 = new Chart(document.getElementById('stat_flotta_societa'), config4);
    const myChart4bar = new Chart(document.getElementById('stat_flotta_societa_bar'), config4bar);
</script>

 
<script>
    const data5 = {
        labels: [<%=ReturnValoriAuto("societaimporto", "SI")%>],
        datasets: [{
            label: 'Societa (importo)',
            data: [<%=ReturnValoriAuto("societaimporto", "")%>],
            backgroundColor: [
                "#004B6B",
                "#005E87",
                "#00A5EC",
                "#08B2FB",
                "#004969",
                "#006089",
                "#76D6FF",
                "#045E85",
                "#034562",
                "#022432",
                "#031D29",
                "#01131A",
                "#04202C",
                "#01A7EF",
                "#21B2F1",
                "#99D9F5",
                "#07202B",
                "#122E3A",
                "#2B3F47",
                "#2C4651",
            ],
            hoverOffset: 4
        }]
    };

    const config5 = {
        type: 'doughnut',
        data: data5,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config5bar = {
        type: 'bar',
        data: data5,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart5 = new Chart(document.getElementById('stat_flotta_grade'), config5);
    const myChart5bar = new Chart(document.getElementById('stat_flotta_grade_bar'), config5bar);
</script>


<script>
    const data7 = {
        labels: [<%=ReturnValoriAuto("fornitore", "SI")%>],
        datasets: [{
            label: 'Fornitore',
            data: [<%=ReturnValoriAuto("fornitore", "")%>],
            backgroundColor: [
                "#2A1800",
                "#462A03",
                "#734300",
                "#A86400",
                "#412702",
                "#4F2E00",
                "#673C00",
                "#D37C00",
                "#3E2400",
                "#693E00",
                "#BA710B",
                "#EB8A02",
                "#E3A348",
                "#D4881C",
                "#915500",
                "#6B3F00",
                "#FF9500",
                "#FFA019",
                "#FFD59A",
                "#D4881C",
            ],
            hoverOffset: 4
        }]
    };

    const config7 = {
        type: 'doughnut',
        data: data7,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config7bar = {
        type: 'bar',
        data: data7,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart7 = new Chart(document.getElementById('stat_flotta_fornitore'), config7);
    const myChart7bar = new Chart(document.getElementById('stat_flotta_fornitore_bar'), config7bar);
</script>



<script>
    const data8 = {
        labels: [<%=ReturnValoriAuto("fornitoreimporto", "SI")%>],
        datasets: [{
            label: 'Fornitore (importo)',
            data: [<%=ReturnValoriAuto("fornitoreimporto", "")%>],
            backgroundColor: [
                "#2A1800",
                "#462A03",
                "#734300",
                "#A86400",
                "#412702",
                "#4F2E00",
                "#673C00",
                "#D37C00",
                "#3E2400",
                "#693E00",
                "#BA710B",
                "#EB8A02",
                "#E3A348",
                "#D4881C",
                "#915500",
                "#6B3F00",
                "#FF9500",
                "#FFA019",
                "#FFD59A",
                "#D4881C",
            ],
            hoverOffset: 4
        }]
    };

    const config8 = {
        type: 'doughnut',
        data: data8,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config8bar = {
        type: 'bar',
        data: data8,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart8 = new Chart(document.getElementById('stat_flotta_fornitorecanone'), config8);
    const myChart8bar = new Chart(document.getElementById('stat_flotta_fornitorecanone_bar'), config8bar);
</script>

    


<script>
    const data9 = {
        labels: [<%=ReturnValoriAuto("template", "SI")%>],
        datasets: [{
            label: 'Template',
            data: [<%=ReturnValoriAuto("template", "")%>],
            backgroundColor: [
                "#00464C",
                "#005E67",
                "#00909D",
                "#00D0E3",
                "#001719",
                "#02282B",
                "#004046",
                "#015D66",
                "#017580",
                "#01565E",
                "#002C30",
                "#012427",
                "#2D828A",
                "#137881",
                "#015158",
                "#003B41",
                "#72F3FF",
                "#007984",
                "#005D66",
                "#48ABB4",
                "#00464C",
                "#005E67",
                "#00909D",
                "#00D0E3",
                "#001719",
                "#02282B",
                "#004046",
                "#015D66",
            ],
            hoverOffset: 4
        }]
    };

    const config9 = {
        type: 'doughnut',
        data: data9,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config9bar = {
        type: 'bar',
        data: data9,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart9 = new Chart(document.getElementById('stat_flotta_marca'), config9);
    const myChart9bar = new Chart(document.getElementById('stat_flotta_marca_bar'), config9bar);
</script>

    


<script>
    const data10 = {
        labels: [<%=ReturnValoriAuto("templateimporto", "SI")%>],
        datasets: [{
            label: 'Template (importo)',
            data: [<%=ReturnValoriAuto("templateimporto", "")%>],
            backgroundColor: [
                "#00464C",
                "#005E67",
                "#00909D",
                "#00D0E3",
                "#001719",
                "#02282B",
                "#004046",
                "#015D66",
                "#017580",
                "#01565E",
                "#002C30",
                "#012427",
                "#2D828A",
                "#137881",
                "#015158",
                "#003B41",
                "#72F3FF",
                "#007984",
                "#005D66",
                "#48ABB4",
                "#00464C",
                "#005E67",
                "#00909D",
                "#00D0E3",
                "#001719",
                "#02282B",
                "#004046",
                "#015D66",
            ],
            hoverOffset: 4
        }]
    };

    const config10 = {
        type: 'doughnut',
        data: data10,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => {
                            sum += data;
                        });
                        let percentage = (value * 100 / sum).toFixed(0);
                        return percentage >= 3 ? percentage + "%" : "";
                    },
                    color: '#fff'
                }
            }
        },
    };

    const config10bar = {
        type: 'bar',
        data: data10,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                },
                datalabels: {
                    formatter: function (value, context) {
                        return value.toLocaleString();
                    },
                    color: '#000',
                    anchor: 'end',
                    align: 'top',
                    offset: 4
                }
            }
        },
    };

    const myChart10 = new Chart(document.getElementById('stat_flotta_annualita'), config10);
    const myChart10bar = new Chart(document.getElementById('stat_flotta_annualita_bar'), config10bar);
</script>
    
</asp:Content>