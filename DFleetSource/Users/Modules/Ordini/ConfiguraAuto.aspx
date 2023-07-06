<%@ Page Title="Configura Auto" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ConfiguraAuto.aspx.cs" Inherits="DFleet.Users.Modules.Ordini.ConfiguraAuto" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazione Auto</h3>
            </div>
            <div class="col-md-5 text-right" id="buttonrinuncia" runat="server">
                <a href="<%=ResolveUrl("~/Users/Modules/Ordini/Rinuncia")%>" onclick="return confirm('Sei sicuro di voler rinunciare alla configurazione?');" class="btn btn-info waves-effect waves-light m-t-10">Rinuncia a configurazione</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMaxConf" runat="server" CssClass="text-center border-0 font-18 m-b-5">
                    <asp:Label ID="lblMaxConf" runat="server" Text=""></asp:Label>
                </asp:Panel>


                <asp:Panel ID="pnlStep1" runat="server">

                    <!-- Lista Car List POOL -->
                    <h5 class="text-center text-verde">Ti suggeriamo una lista di Auto già configurate subito disponibili (pool)<br /> 
                        oppure clicca su "Salta" per procedere a configurare una nuova auto</h5><br />
                   
                    <div style="clear:both;text-align:center"><asp:Button ID="btnIgnora" runat="server" Text="Salta" OnClick="btnIgnora_Click" CssClass="btn btn-success" /><br /><br /></div>

                    <asp:DataList ID="dlRicCarListPool" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" DataSourceID="odsRicCarListPool">
                        <ItemTemplate>
                            <a href='ScegliAutoPool-<%# Eval("Uid")%>' >  
                              <div class="col-md-4 col-sm-6 col-xs-12">

                                <div class="white-box hoverV">
                              
                                    <div class="product-img ">
                                    <div class="ribbon  ribbon-default"><%# Eval("alimentazione")%></div>   
                                        <%# ReturnFotoAuto(Eval("fotoauto").ToString()) %>
                                    </div>
                                    <div class="product-text">
                                        <small class="text-muted db"><%# Eval("marca")%> </small>
                                        <h3 class="box-title m-b-0"><%# Eval("modello")%></h3>
                                        <h4>OPTIONAL CANONE: &euro;  <%# String.Format(CultureInfo.CurrentCulture, "{0:F2}",Eval("deltacanone")) %> </h4>
                                    </div>
                                </div>
                            </div></a>
                        </ItemTemplate>
                    </asp:DataList>

                    <asp:ObjectDataSource ID="odsRicCarListPool" runat="server" OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="SelectCarPolicyPool" TypeName="BusinessLogic.ContrattiBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdcodgrade" Name="gradepool" PropertyName="Value" Type="String" />
                            </SelectParameters>
                    </asp:ObjectDataSource>
                
                    <asp:HiddenField ID="hdcodsocieta" runat="server" />
                    <asp:HiddenField ID="hdcodgrade" runat="server" />

                    <!-- Visualizzazione Errori -->
                    <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </asp:Panel>


                </asp:Panel>




                <asp:Panel ID="pnlStep2" runat="server">

                    <!-- Lista Car List Step2 -->
                    <h5>Scegli la tua nuova auto tra quelle disponibili </h5><br />
                    
                    <asp:DataList ID="dlRicCarListStep2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" DataSourceID="odsRicCarListStep2">
                        <ItemTemplate>
                          <a href='ScegliAuto-<%# Eval("Uid")%>' >  
                              <div class="col-md-4 col-sm-6 col-xs-12">

                                <div class="white-box hoverV">
                              
                                    <div class="product-img ">
                                    <div class="ribbon  ribbon-default"><%# Eval("alimentazione")%></div>   
                                        <%# ReturnFotoAuto(Eval("fotoauto").ToString()) %>
                                    </div>
                                    <div class="product-text">
                                        <small class="text-muted db"><%# Eval("marca")%> </small>
                                        <h3 class="box-title bh50 m-b-0"><%# Eval("modello")%></h3>
                                       
                                    </div>
                                </div>
                            </div></a>
                        </ItemTemplate>
                    </asp:DataList>

                    <asp:ObjectDataSource ID="odsRicCarListStep2" runat="server" OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="SelectCarPolicyStep2" TypeName="BusinessLogic.ContrattiBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdidutente" Name="idutente" PropertyName="Value" Type="Int32" />
                            </SelectParameters>
                    </asp:ObjectDataSource>
                
                    <asp:HiddenField ID="hdidutente" runat="server" />
                    <asp:HiddenField ID="hdcodcarlist" runat="server" />

                    <!-- Visualizzazione Errori -->
                    <asp:Panel ID="pnlMessage2" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                        <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    
                </asp:Panel>


            </div> 
        </div>


    </div>
</div>


</asp:Content>