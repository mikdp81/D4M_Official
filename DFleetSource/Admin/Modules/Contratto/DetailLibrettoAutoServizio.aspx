<%@ Page Title="Libretto di bordo" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DetailLibrettoAutoServizio.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.DetailLibrettoAutoServizio" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Libretto di bordo</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewLibrettoAutoServizio")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>		
        </div>
    </div>
    
    <div class="white-box">
        <div class="row">
            <div class="col-12"> 
                AUTO<br />
                <h4>
                    <asp:Label ID="lblTarga" runat="server" Text=""></asp:Label> - 
                    <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label> -
                    <asp:Label ID="lblModello" runat="server" Text=""></asp:Label>
                </h4>

            </div>       
        </div>
        <div class="row">
            <div class="col-12 m-t-30"> 
                
                <asp:GridView ID="gvRicContratti" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicContratti" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>                                                  
                                        
                        <asp:TemplateField HeaderText="Driver">
                            <ItemTemplate>
                                <%# Eval("cognome")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                
                        <asp:TemplateField HeaderText="Scopo viaggio">
                            <ItemTemplate>
                                <%# ReturnScopoViaggio(Eval("scopoviaggio").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Periodo">
                            <ItemTemplate>
                                Dal <%# String.Format(CultureInfo.CurrentCulture, "{0:dd/MM/yyyy HH:mm}",Eval("assegnatodal")) %> <br />
                                al <span class="m-r-10"></span> <%# String.Format(CultureInfo.CurrentCulture, "{0:dd/MM/yyyy HH:mm}",Eval("assegnatoal")) %>
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Km Iniziali/Finali">
                            <ItemTemplate>
                                <%# ReturnKm(Eval("kminiziali").ToString(), Eval("kmrestituzione").ToString())%> 
                            </ItemTemplate>
                        </asp:TemplateField>   

                        <asp:TemplateField HeaderText="Spese">
                            <ItemTemplate>
                                <%# ReturnSpese(Eval("spese").ToString(), Eval("importospese").ToString())%> 
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Note">
                            <ItemTemplate>
                                <%# Eval("noterestituzione")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicContratti" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectDetailLibrettoAutoServizio" TypeName="BusinessLogic.ContrattiBL">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="targa" QueryStringField="targa" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>  

            </div>       
        </div>
    </div>
</div>

</asp:Content>