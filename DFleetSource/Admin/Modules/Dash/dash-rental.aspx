<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-rental.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_rental" %>
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


        <h3>Renter</h3>
    
        <div class="row colorbox-group-widget ">
            <div class="col-md-3 col-sm-6 info-color-box">
                <div class="white-box">
                    <div class="media bg-primary">
                        <div class="media-body">
                            <h3 class="info-count"><asp:Label ID="lbldafirmare" runat="server" Text=""></asp:Label> <span class="pull-right"><i class="mdi mdi-checkbox-marked-circle-outline"></i></span></h3>
                            <p class="info-text font-12">ORDINI DA FIRMARE</p>
                        </div>
                    </div>
                </div>
              
            </div>
            <div class="col-md-3 col-sm-6 info-color-box">
                <div class="white-box">
                    <div class="media bg-success">
                        <div class="media-body">
                            <h3 class="info-count"><asp:Label ID="lbltempirisp" runat="server" Text=""></asp:Label> ore <span class="pull-right"><i class="mdi mdi-comment-text-outline"></i></span></h3>
                            <p class="info-text font-12">TEMPO MEDIO QUOTAZIONE</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- STATUS ORDINE -->
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#89BA17;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Status ordine</div>
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
                        SelectMethod="SelectDashRenterStatusOrdini" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot1" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("statusordini")%></asp:Label>
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
        });
    </script>

<script>

    const data1 = {
        labels: [<%=ReturnValoriAuto("statusordini", "SI")%>],
        datasets: [{
            label: 'Status Contratto',
            data: [<%=ReturnValoriAuto("statusordini", "")%>],
            backgroundColor: [
                "#537B27", 
                "#6C9934",
                "#87bd32",
                "#537B27", 
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

   
       
</asp:Content>