<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-multe.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_multe" %>
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


<h3>Multe</h3>


<div class="row">
    <div class="col-md-4 col-sm-6">
        <div class="white-box bg-verde color-box">
            <h1 class="text-white font-light m-b-0"><asp:Label ID="lbltotmulte" runat="server" Text=""></asp:Label></h1>
            <span class="hr-line"></span>
            <p class="cb-text">Totale multe </p>
            <div class="chart">
                <div style="display:inline;width:96px;height:96px;"><canvas width="96" height="96"></canvas><input class="knob" data-min="0" data-max="100" data-bgcolor="#f86b4a" data-fgcolor="#ffffff" data-displayinput="false" data-width="96" data-height="96" data-thickness=".1" value="25" readonly="readonly" style="display: none; width: 0px; visibility: hidden;"></div>
            </div>
        </div>
    </div>
</div>


<div class="row">
    <div class="col-md-8 col-sm-12">
        <div class="white-box stat-widget">
            <div class="row">
                <canvas id="multe_mese" height="80vh"></canvas>
            </div>
        </div>
    </div>
</div>



<!-- STATUS CONTRATTO -->
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#89BA17;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Status</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_verde.svg" alt="" height="35" />
    </div>
</div>

<div class="white-box-borderleftgreen small-box-widget">
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_statuscontratto" height="265"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_statuscontratto_bar" height="87vh"></canvas>
        </div>            
    </div>
            
    <div class="row m-t-20">
        <div class="col-md-4">
            <div id="btn_flotta1" class="btn btn-success">Mostra/Nascondi Dati</div>
        </div>
    </div>    
    <div class="row" id="container_flotta1" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta1" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta1" CssClass="display nowrap " 
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
            <asp:ObjectDataSource ID="odsFlotta1" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashMulteStatus" TypeName="BusinessLogic.UtilitysBL">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                </SelectParameters>
            </asp:ObjectDataSource> 
            <table class="display nowrap" cellspacing="0" align="Center" style="width:100%;border-collapse:collapse;">
		        <tbody>
                    <tr>
			            <td>
                            <span class="text-black">Totale</span>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTot1" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("status")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
                    
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
                SelectMethod="SelectDashMulteSocieta" TypeName="BusinessLogic.UtilitysBL">
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

    
<!-- GRADE -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#0076A8;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Grade</div>
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
                            <span class="text-black"><%#String.Format("{0:N0}", Eval("tot")) %></span>
                        </ItemTemplate>                    
                    </asp:TemplateField> 
                </Columns>    
                <PagerStyle HorizontalAlign="Right" />    
            </asp:GridView>
            <asp:ObjectDataSource ID="odsFlotta5" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashMulteGrade" TypeName="BusinessLogic.UtilitysBL">
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
                            <asp:Label ID="lblTot5" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("grade")%></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table> 
        </div>
    </div>
</div>



<!-- CITTA -->    
<div class="row">
    <div class="col-md-2" style="padding-right:0;">
        <div style="background-color:#0076A8;height:35px;">
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Citt&agrave;</div>
        </div>
    </div>
    <div class="col-md-10" style="padding-left:0;">
        <img src="../../../plugins/images/Fine_etichetta_blu.svg" alt="" height="35" />
    </div>
</div>
<div class="white-box-borderleftblu small-box-widget">  
                
    <div class="row">
        <div class="col-md-3">
            <canvas id="stat_flotta_sededriver" height="300"></canvas>
        </div>
        <div class="col-md-9">
            <canvas id="stat_flotta_sededriver_bar" height="87vh"></canvas>
        </div> 
    </div>
    <div class="row m-t-20">         
        <div class="col-md-4">
            <div id="btn_flotta6" class="btn btn-blu">Mostra/Nascondi Dati</div>
        </div>
    </div>

    <div class="row" id="container_flotta6" style="display:none;">
        <div class="col-md-4">
            <asp:GridView ID="gvFlotta6" runat="server"
                    AutoGenerateColumns="False" DataSourceID="odsFlotta6" CssClass="display2 nowrap " 
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
            <asp:ObjectDataSource ID="odsFlotta6" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="SelectDashMulteCitta" TypeName="BusinessLogic.UtilitysBL">
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
                            <asp:Label ID="lblTot6" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("citta")%></asp:Label>
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
            <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Tipo</div>
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
                SelectMethod="SelectDashMulteTipo" TypeName="BusinessLogic.UtilitysBL">
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
                            <asp:Label ID="lblTot7" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("tipomulta")%></asp:Label>
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
            $("#btn_flotta1").click(function () {
                $("#container_flotta1").toggle();
            });
            $("#btn_flotta4").click(function () {
                $("#container_flotta4").toggle();
            });
            $("#btn_flotta5").click(function () {
                $("#container_flotta5").toggle();
            });
            $("#btn_flotta6").click(function () {
                $("#container_flotta6").toggle();
            });
            $("#btn_flotta7").click(function () {
                $("#container_flotta7").toggle();
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
                label: 'Multe ',
                data: [<%=ReturnMulteMese()%>],
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



        const myChart = new Chart(document.getElementById('multe_mese'), config);
    </script>

<script>

    const data1 = {
        labels: [<%=ReturnValoriAuto("status", "SI")%>],
        datasets: [{
            label: 'Status',
            data: [<%=ReturnValoriAuto("status", "")%>],
            backgroundColor: [
                "#537B27",
                "#6C9934",
                "#87bd32",
                "#537B27",
                "#6C9934",
                "#87bd32",
            ],
            hoverOffset: 4
        }]
    };

    const config1 = {
        type: 'doughnut',
        data: data1,
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

    const config1bar = {
        type: 'bar',
        data: data1,
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

    const myChart1 = new Chart(document.getElementById('stat_flotta_statuscontratto'), config1);
    const myChart1bar = new Chart(document.getElementById('stat_flotta_statuscontratto_bar'), config1bar);
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
        labels: [<%=ReturnValoriAuto("grade", "SI")%>],
        datasets: [{
            label: 'Grade',
            data: [<%=ReturnValoriAuto("grade", "")%>],
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
    const data6 = {
        labels: [<%=ReturnValoriAuto("citta", "SI")%>],
        datasets: [{
            label: 'Citta multa',
            data: [<%=ReturnValoriAuto("citta", "")%>],
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
                "#004B6B",
                "#005E87",
            ],
            hoverOffset: 4
        }]
    };

    const config6 = {
        type: 'doughnut',
        data: data6,
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

    const config6bar = {
        type: 'bar',
        data: data6,
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

    const myChart6 = new Chart(document.getElementById('stat_flotta_sededriver'), config6);
    const myChart6bar = new Chart(document.getElementById('stat_flotta_sededriver_bar'), config6bar);
</script>



<script>
    const data7 = {
        labels: [<%=ReturnValoriAuto("tipomulta", "SI")%>],
        datasets: [{
            label: 'Tipo multa',
            data: [<%=ReturnValoriAuto("tipomulta", "")%>],
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



</asp:Content>