<%@ Page Title="Documenti" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="TelePass.aspx.cs" Inherits="DFleet.Users.Modules.Dash.TelePass" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
      
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Tele Pass</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                Tele Pass assegnata <br /><br />
                <asp:Literal ID="ltdati" runat="server"></asp:Literal>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                Consumi Tele Pass <br /><br />

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtSearch" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Stazione"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlFuelCard" runat="server" DataSourceID="odsfuelcard" DataTextField="numerofuelcard" 
                                            DataValueField="numerofuelcard" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="" Text="FuelCard"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsfuelcard" runat="server" SelectMethod="SelectFuelCardDriver" TypeName="BusinessLogic.FileTracciatiBL" >
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hdiduser" DbType="Guid" Name="UserId" PropertyName="Value" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>                               
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data Rifornimento Dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data Rifornimento Al"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>    
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull"> 
                                        <asp:DropDownList ID="ddlNRecord" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                data-toggle="tooltip" data-placement="top" data-original-title="N.Record">
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="100">100</asp:ListItem>
                                            <asp:ListItem Value="200">200</asp:ListItem>
                                            <asp:ListItem Value="500">500</asp:ListItem>
                                            <asp:ListItem Value="1000">1000</asp:ListItem>
                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                            <asp:ListItem Value="5000">5000</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdPagina" runat="server" Value="" />
                                    </div>
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-2">
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
        
        <div class="row">
            <div class="col-12">

                <!-- Lista Consumi -->
                <asp:GridView ID="gvConsumi" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsConsumi" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Compagnia">
                            <ItemTemplate>
                                <%# Eval("compagnia")%> 
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FuelCard">
                            <ItemTemplate>
                                <%# Eval("numerofuelcard")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                                        
                        <asp:TemplateField HeaderText="Stazione">
                            <ItemTemplate>
                                <%# Eval("ragionesociale")%> - <%# Eval("indirizzo")%> - <%# Eval("localita")%> 
                            </ItemTemplate>
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Targa">
                            <ItemTemplate>
                                <%# Eval("targa")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Quantit&agrave;">
                            <ItemTemplate>
                                <%# Eval("quantita")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prezzo">
                            <ItemTemplate>
                                <%# Eval("prezzo")%>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Importo">
                            <ItemTemplate>
                                <%# Eval("importo")%>
                            </ItemTemplate>
                        </asp:TemplateField>   

                        <asp:TemplateField HeaderText="Data Rifornimento">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datatransazione")) %>              
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Tipo Rifornimento">
                            <ItemTemplate>
                                <%# Eval("tiporifornimento")%>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsConsumi" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectConsumiTelePass" TypeName="BusinessLogic.FileTracciatiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                            <asp:ControlParameter ControlID="txtDatadal" Name="datadal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtDataal" Name="dataal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtSearch" Name="search" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="ddlFuelCard" Name="numerodispositivo" PropertyName="SelectedValue" Type="String" />
                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                            <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                </asp:ObjectDataSource>  

                <asp:HiddenField ID="hdiduser" runat="server" />

                <div class="dataTables_wrapper">
                    <div class="dataTables_info">
                        <asp:Label ID="lblNumRecord" runat="server" Text=""></asp:Label>       
                    </div>            

                    <div class="dataTables_paginate paging_simple_numbers">
                        <asp:LinkButton ID="pagingprec" runat="server" OnClick="pagingprec_Click" CssClass="paginate_button"><</asp:LinkButton>
                        <asp:TextBox ID="txtnumpag" runat="server" Text="1" style="width:50px;text-align:center;" OnTextChanged="txtnumpag_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                        <asp:LinkButton ID="pagingnext" runat="server" OnClick="pagingnext_Click" CssClass="paginate_button">></asp:LinkButton>
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


</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".mostrapin").click(function () {
            var count = $(this).attr("data-id");
            $(".pin_" + count).show();
            $(".mostrapin").hide();
        });          
    });  
</script>

</asp:Content>