<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="dash-ordini.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.dash_ordini" %>
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



    <h3>Ordini</h3>

            <div class="row colorbox-group-widget ">
                    <div class="col-md-3 col-sm-6 info-color-box">
                        <div class="white-box  bg-black  ecom-stat-widget">
                            <div class="media">
                                <div class="media-body">
                                    <h3 class="info-count"><asp:Label ID="lblconfigurazione" runat="server" Text=""></asp:Label> <span class="pull-right"><i class="mdi mdi-checkbox-marked-circle-outline"></i></span></h3>
                                    <p class="info-text font-12">CONFIGURAZIONI</p>
                                </div>
                            </div>
                        </div>              
                    </div>
                    <div class="col-md-3 col-sm-6 info-color-box">
                        <div class="white-box  bg-black  ecom-stat-widget">
                            <div class="media">
                                <div class="media-body">
                                    <h3 class="info-count"><asp:Label ID="lblofferte" runat="server" Text=""></asp:Label> <span class="pull-right"><i class="mdi mdi-comment-text-outline"></i></span></h3>
                                    <p class="info-text font-12">OFFERTE DA RICEVERE</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 info-color-box">
                        <div class="white-box  bg-black  ecom-stat-widget">
                            <div class="media">
                                <div class="media-body">
                                    <h3 class="info-count"><asp:Label ID="lblinapprovazione" runat="server" Text=""></asp:Label>  <span class="pull-right"><i class="mdi mdi-coin"></i></span></h3>
                                    <p class="info-text font-12">ORDINI IN APPROVAZIONE</p>
                                </div>
                            </div>
                        </div>                            
                    </div>
                    <div class="col-md-3 col-sm-6 info-color-box">
                        <div class="white-box  bg-black  ecom-stat-widget">
                            <div class="media">
                                <div class="media-body">
                                    <h3 class="info-count"><asp:Label ID="lblinconferma" runat="server" Text=""></asp:Label> <span class="pull-right"><i class="mdi mdi-coin"></i></span></h3>
                                    <p class="info-text font-12">ORDINI IN CONFERMA</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

    
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div class="white-box stat-widget">
                            <div class="row">
                                <canvas id="ordini_anno" height="80vh"></canvas>
                              </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-4 col-sm-6">
                        <div class="white-box bg-verde color-box">
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="text-center cb-text">Optional Canone</p>
                                </div>
                                <div class="col-md-4 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblnumerodeltacanone" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">numero</span></h6><br />
                                </div>
                                <div class="col-md-4 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmediadeltacanone" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">media</span></h6><br />
                                </div>
                                <div class="col-md-4 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmaxdeltacanone" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">max</span></h6><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="white-box bg-verde color-box">
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="text-center cb-text">Fringe Benefit</p>
                                </div>
                                <div class="col-md-6 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmediafringebenefit" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">media</span></h6><br />
                                </div>
                                <div class="col-md-6 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmaxfringebenefit" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">max</span></h6><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="white-box bg-verde color-box">
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="text-center cb-text">Emissioni (CO2)</p>
                                </div>
                                <div class="col-md-6 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmediaemissioni" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">media</span></h6><br />
                                </div>
                                <div class="col-md-6 text-center">
                                    <h1 class="text-white font-light m-b-0"><asp:Label ID="lblmaxemissioni" runat="server" Text=""></asp:Label></h1>
                                    <span class="hr-line"></span>
                                    <h6 class="text-white font-semibold"><span class="font-light">max</span></h6><br />
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
                        SelectMethod="SelectDashOrdiniStatusOrdine" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot1" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("statusordine")%></asp:Label>
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
                        SelectMethod="SelectDashOrdiniSocieta" TypeName="BusinessLogic.UtilitysBL">
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
                        SelectMethod="SelectDashOrdiniGrade" TypeName="BusinessLogic.UtilitysBL">
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



        <!-- SEDE DRIVER -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#0076A8;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Sede driver</div>
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
                        SelectMethod="SelectDashOrdiniSedeDriver" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot6" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("sededriver")%></asp:Label>
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
                        SelectMethod="SelectDashOrdiniFornitore" TypeName="BusinessLogic.UtilitysBL">
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



        <!-- FORNITORI CANONE -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#ED8B00;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Fornitore (canone)</div>
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
                                    <span class="text-black"><%#String.Format("{0:N2}", Eval("canone")) %></span>
                                </ItemTemplate>                    
                            </asp:TemplateField> 
                        </Columns>    
                        <PagerStyle HorizontalAlign="Right" />    
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsFlotta8" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDashOrdiniFornitoreCanone" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot8" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("fornitorecanone")%></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    

        <!-- MARCA -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#007680;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Marca</div>
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
                        SelectMethod="SelectDashOrdiniMarca" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot9" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("marca")%></asp:Label>
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
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Annualit&agrave;</div>
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
                    <asp:ObjectDataSource ID="odsFlotta10" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDashOrdiniAnnualita" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot10" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("annualita")%></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    

        <!-- ALIMENTAZIONE -->    
        <div class="row">
            <div class="col-md-2" style="padding-right:0;">
                <div style="background-color:#007680;height:35px;">
                    <div style="padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700">Alimentazione</div>
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
                    <asp:ObjectDataSource ID="odsFlotta11" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDashOrdiniAlimentazione" TypeName="BusinessLogic.UtilitysBL">
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
                                    <asp:Label ID="lblTot11" runat="server" Text="" CssClass="text-black"><%=ReturnTotale("alimentazione")%></asp:Label>
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
            $("#btn_flotta8").click(function () {
                $("#container_flotta8").toggle();
            });
            $("#btn_flotta9").click(function () {
                $("#container_flotta9").toggle();
            });
            $("#btn_flotta10").click(function () {
                $("#container_flotta10").toggle();
            });
            $("#btn_flotta11").click(function () {
                $("#container_flotta11").toggle();
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
                label: 'Auto in circolazione ',
                data: [<%=ReturnAutoCircolazione()%>],
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



        const myChart = new Chart(document.getElementById('ordini_anno'), config);
    </script>


<script>

    const data1 = {
        labels: [<%=ReturnValoriAuto("statusordine", "SI")%>],
        datasets: [{
            label: 'Status Ordine',
            data: [<%=ReturnValoriAuto("statusordine", "")%>],
            backgroundColor: [
                "#537B27",
                "#6C9934",
                "#87bd32",
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
        labels: [<%=ReturnValoriAuto("sededriver", "SI")%>],
        datasets: [{
            label: 'Sede driver',
            data: [<%=ReturnValoriAuto("sededriver", "")%>],
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
        labels: [<%=ReturnValoriAuto("fornitorecanone", "SI")%>],
        datasets: [{
            label: 'Fornitore (totale canone annuale)',
            data: [<%=ReturnValoriAuto("fornitorecanone", "")%>],
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
        labels: [<%=ReturnValoriAuto("marca", "SI")%>],
        datasets: [{
            label: 'Marca',
            data: [<%=ReturnValoriAuto("marca", "")%>],
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
        labels: [<%=ReturnValoriAuto("annualita", "SI")%>],
        datasets: [{
            label: 'Annualita',
            data: [<%=ReturnValoriAuto("annualita", "")%>],
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
    
    


<script>
    const data11 = {
        labels: [<%=ReturnValoriAuto("alimentazione", "SI")%>],
        datasets: [{
            label: 'Alimentazione',
            data: [<%=ReturnValoriAuto("alimentazione", "")%>],
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