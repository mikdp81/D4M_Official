<%@ Page Title="CarList Attuale" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewCarList.aspx.cs" Inherits="DFleet.Admin.Modules.Pen.ViewCarList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">CarList Attuale</h3>
            </div>				
        </div>
    </div>


   <div class="row m-b-20">
     <div class="col-md-12 text-right"> 
         <a class="btn btn-filter svg-icon-30 svg-icon-filter" ID="btnFiltra" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Filtra"></a>
         <a class="btn btn-filter svg-icon-30 svg-icon-excel" ID="btnEsportaExcel" runat="server" onserverclick="btnEsporta_Click"></a>
    </div>
   </div>


    <div class="white-box" id="filtri" style="display:none;">
        <div class="row">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                     <asp:DropDownList ID="ddlCodice" runat="server" DataSourceID="odscodcarlist" DataTextField="carlist" 
                                    DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Car List"></asp:ListItem>
                                    </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscodcarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL" >
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                                              
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra" CssClass="btn btn-info" />
                                        <asp:Button ID="btnSvuotaFiltri" runat="server" onclick="btnSvuotaFiltri_Click" Text="Svuota Filtri" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div> 
        </div>
    </div>
        
    <div class="white-box">

        <div class="row">
            <div class="col-12">

                <asp:GridView ID="gvRicCarList" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicCarList" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>               
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="CarList">
                            <ItemTemplate>
                               <%# Eval("codcarlist")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="CarPolicy">
                            <ItemTemplate>
                               <%# Eval("codcarpolicy")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Marca">
                            <ItemTemplate>
                                <%# Eval("marca")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Modello">
                            <ItemTemplate>
                                <div class="text-break width300"><%# Eval("modello")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>                     
                    
                        <asp:TemplateField HeaderText="Validit&agrave;">
                            <ItemTemplate>
                               Dal <%# ReturnData(Eval("validodal").ToString()) %> <br />
                                Al <%# ReturnData(Eval("validoal").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='../Car/DetailAuto-<%# Eval("Uid")%>' target="_blank" class="text-inverse" title="" data-placement="left" data-toggle="tooltip" data-original-title="Visualizza Scheda"><img src="../../../plugins/images/visualizza_ordine.svg" class="icon20" border="0" alt="" /></a>
                            </ItemTemplate>  
                            <ItemStyle Width="15%" />                              
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicCarList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectViewCarList" TypeName="BusinessLogic.CarsBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                        <asp:ControlParameter ControlID="ddlCodice" Name="codcarlist" PropertyName="SelectedValue" Type="String" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                    </SelectParameters>
                </asp:ObjectDataSource>  

                <div class="dataTables_wrapper">
                    <div class="dataTables_info">
                        <asp:Label ID="lblNumRecord" runat="server" Text=""></asp:Label>       
                    </div>   
                </div>

                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server" CssClass="alert alert-warning bg-warning text-white border-0">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</div>

    
<asp:HiddenField ID="hdcodsocieta" runat="server" />

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js">  
  
</script>

</asp:Content>