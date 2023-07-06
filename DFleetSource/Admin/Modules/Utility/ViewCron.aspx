<%@ Page Title="Importazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewCron.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ViewImportazioni" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Cron</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:GridView ID="gvImpo" runat="server" AutoGenerateColumns="False" DataSourceID="odsImpo" CssClass="display nowrap dataTable" 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Tipo Importazione">
                            <ItemTemplate>
                                <%# Eval("tipofile")%>                
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                                <span class="text-break width200"><%# Eval("nomefile")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Importato il">
                            <ItemTemplate>
                               <%# Eval("dataimportazione")%>                    
                            </ItemTemplate>
                        </asp:TemplateField>   
                    
                        <asp:TemplateField HeaderText="Fine Importazione il">
                            <ItemTemplate>
                               <%# Eval("datafineimportazione")%>                    
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Esito">
                            <ItemTemplate>
                                <%# Eval("importato")%><br />
                                Importate N. righe <%# Eval("righeimportate")%> su <%# Eval("righetotali")%>
                            </ItemTemplate>
                        </asp:TemplateField>   
    
                        <asp:TemplateField HeaderText="Dettagli">
                            <ItemTemplate>                            
                                <a href="DetailImport-<%# Eval("idprog")%>" class="text-inverse p-r-10" data-toggle="tooltip" data-placement="left" title="" data-original-title="Apri"><img src="../../../plugins/images/apri.svg" class="icon20" border="0" alt="" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Importa">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdimportato"  Value='<%#Eval("importato") %>' runat="server"></asp:HiddenField>  
                                <asp:HiddenField ID="hdidprog"  Value='<%#Eval("idprog") %>' runat="server"></asp:HiddenField>   
                            
                                <input type="button" class="btn btn-success" runat="server" onserverclick="btnAggiorna_Click" id="btnAggiorna" value="Aggiorna" />
                                <asp:Button ID="btnImporta" runat="server" OnCommand="btnImporta_Click" CommandArgument='<%# Eval("idprog") %>' Text="Importa" CssClass="btn btn-success" />
                            </ItemTemplate>
                        </asp:TemplateField>                         
                    </Columns>    
                    <PagerStyle HorizontalAlign="right" /> 
                </asp:GridView>

                <asp:ObjectDataSource ID="odsImpo" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectImportazioniCron" TypeName="BusinessLogic.CronBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

            </div>
        </div>
    </div>

</div>

</asp:Content>