<%@ Page Title="Configurazione" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModConf.aspx.cs" Inherits="DFleet.Admin.Modules.EPartner.ModConf" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box no-print">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazione</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/EPartner/RichiesteConf")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>		
        </div>
    </div>

    
    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">
                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                
                <div class="form-body">
                    <div class="row">   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Status Configurazione *</label>         
                                <asp:DropDownList ID="ddlStatusOrdini" runat="server" DataSourceID="odsstatusordini" DataTextField="statusordine" 
                                    DataValueField="idstatusordine" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="">Scegli Status Ordine</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstatusordini" runat="server" SelectMethod="SelectStatusConfigurazionePartner" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div> 
                        </div>
                    </div>
                </div>
                <div class="form-action">
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Aggiorna" CssClass="btn btn-success" />
                </div>


            </div>  

        </div>
    </div>


    <div class="white-box">
        <div class="row">
            <div class="col-sm-6">
                <h5>Dati Ordine</h5>
                <asp:Label ID="lblDatiOrdine" runat="server" Text="" />
            </div>            
            <div class="col-sm-6">
                <h5>Dati Richiedente</h5>
                <asp:Label ID="lblDatiDriver" runat="server" Text="" />
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">   
                <h5>Allegati</h5>
         
                
                <asp:GridView ID="gvAll" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsAll" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Allegato"> 
                            <ItemTemplate>
                                <%# Eval("allegato")%>
                            </ItemTemplate>                                
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Visualizza"> 
                            <ItemTemplate>
                                <a href="../../../DownloadFile?type=ordini&nomefile=<%# Eval("allegato")%>" target='_blank'><i class='icon-check' data-toggle='tooltip' data-placement="left" title='' data-original-title='Apri'></i></a>
                            </ItemTemplate>                                
                        </asp:TemplateField>   
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsAll" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllegatiConfigurazioniPartner" TypeName="BusinessLogic.ContrattiBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdidconf" Name="idconfigurazione" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
                
                <asp:HiddenField ID="hduidconf" runat="server" />
                <asp:HiddenField ID="hdidconf" runat="server" />

            </div>
        </div>


    </div>
</div>


</asp:Content>