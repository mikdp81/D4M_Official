<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-driver.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_driver" %>
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

    <h3>Driver</h3>

    <div class="row">
        <div class="col-md-4 col-sm-6">
            <div class="white-box bg-verde color-box">
                <h1 class="text-white font-light m-b-0"><asp:Label ID="lbletamediadriver" runat="server" Text=""></asp:Label></h1>
                <span class="hr-line"></span>
                <p class="cb-text">Età media driver</p>
                <div class="chart">
                    <div style="display:inline;width:96px;height:96px;"><canvas width="96" height="96"></canvas><input class="knob" data-min="0" data-max="100" data-bgcolor="#f86b4a" data-fgcolor="#ffffff" data-displayinput="false" data-width="96" data-height="96" data-thickness=".1" value="25" readonly="readonly" style="display: none; width: 0px; visibility: hidden;"></div>
                </div>
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
                        SelectMethod="SelectDashDriverGrade" TypeName="BusinessLogic.UtilitysBL">
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



        <!-- SEDE -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#0076A8;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Sede</div>
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
                        SelectMethod="SelectDashDriverSede" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot6" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("sede")%></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

          


        <!-- ETA -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#007680;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Eta</div>
                </div>
            </div>
            <div class="col-md-10" style="padding-left:0;">
                <img src="../../../plugins/images/Fine_etichetta_verdone.svg" alt="" height="35" />
            </div>
        </div>
        <div class="white-box-borderleftverdone small-box-widget">  
                
            <div class="row">
                <div class="col-md-3">
                    <canvas id="stat_flotta_alimentazione" height="300"></canvas>
                </div>
                <div class="col-md-9">
                    <canvas id="stat_flotta_alimentazione_bar" height="87vh"></canvas>
                </div> 
            </div>
            <div class="row m-t-20">         
                <div class="col-md-4">
                    <div id="btn_flotta11" class="btn btn-verdone">Mostra/Nascondi Dati</div>
                </div>
            </div>

            <div class="row" id="container_flotta11" style="display:none;">
                <div class="col-md-4">
                    <asp:GridView ID="gvFlotta11" runat="server"
                            AutoGenerateColumns="False" DataSourceID="odsFlotta11" CssClass="display4 nowrap " 
                            GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="">   
                                <ItemTemplate>
                                    <span class="text-black"><%# Eval("annoconsegna") %></span>
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
                    <asp:ObjectDataSource ID="odsFlotta11" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDashDriverEta" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot11" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("eta")%></asp:Label>
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
            $("#btn_flotta5").click(function () {
                $("#container_flotta5").toggle();
            });
            $("#btn_flotta6").click(function () {
                $("#container_flotta6").toggle();
            });
            $("#btn_flotta11").click(function () {
                $("#container_flotta11").toggle();
            });
        });
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
        labels: [<%=ReturnValoriAuto("sede", "SI")%>],
        datasets: [{
            label: 'Sede driver',
            data: [<%=ReturnValoriAuto("sede", "")%>],
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
    const data11 = {
        labels: [<%=ReturnValoriAuto("eta", "SI")%>],
        datasets: [{
            label: 'Eta',
            data: [<%=ReturnValoriAuto("eta", "")%>],
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
            ],
            hoverOffset: 4
        }]
    };

    const config11 = {
        type: 'doughnut',
        data: data11,
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

    const config11bar = {
        type: 'bar',
        data: data11,
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

    const myChart11 = new Chart(document.getElementById('stat_flotta_alimentazione'), config11);
    const myChart11bar = new Chart(document.getElementById('stat_flotta_alimentazione_bar'), config11bar);
</script>


</asp:Content>