<%@ Page Title="Storico Auto" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="StoricoAuto.aspx.cs" Inherits="DFleet.Users.Modules.Dash.StoricoAuto" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Storico Auto</h3>
            </div>				
        </div>
    </div>


    <div class="white-box">        
        <div class="row">
            <div class="col-12">

                <asp:GridView ID="gvStorico" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsStorico" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Targa">
                            <ItemTemplate>
                                <%# Eval("targa")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Modello">
                            <ItemTemplate>
                                <%# Eval("modello")%>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Fornitore">
                            <ItemTemplate>
                                <%# Eval("fornitore")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    
                        <asp:TemplateField HeaderText="Dal - Al">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("assegnatodal")) %> -      
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("assegnatoal")) %>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Km percorsi">
                            <ItemTemplate>
                                <%# Eval("kmpercorsi")%>
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Tot. Consumi">
                            <ItemTemplate>
                                <%# Eval("importototale")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Azioni"> 
                            <ItemTemplate>
                                <a href='DetailAuto-<%# Eval("Uid")%>' class="text-inverse p-r-10" data-toggle="tooltip" data-placement="left" title="" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                                <a href='UploadFuel-<%# Eval("idassegnazione")%>' class="text-inverse p-r-10" data-toggle="tooltip" data-placement="left" title="" data-original-title="Carica File"><i class="icon-cloud-upload fa-fw text-black" style="font-size:20px;"></i></a>                           
                            </ItemTemplate>                                
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsStorico" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectStoricoAutoUser" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        </SelectParameters>
                </asp:ObjectDataSource>  

                <asp:HiddenField ID="hdiduser" runat="server" />             

            </div>
        </div>
    </div>
</div>

</asp:Content>
