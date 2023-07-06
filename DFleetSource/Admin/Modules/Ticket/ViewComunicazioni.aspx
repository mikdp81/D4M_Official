<%@ Page Title="Help Desk" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ViewComunicazioni.aspx.cs" Inherits="DFleet.Admin.Modules.Ticket.ViewComunicazioni" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Help Desk</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ticket/insCom")%>" class="btn btn-info waves-effect waves-light m-t-10">Nuovo</a> 
            </div>				
        </div>
    </div>
       <div class="row m-b-20">
     <div class="col-md-12 text-right"> 
         <a class="btn btn-filter svg-icon-30 svg-icon-filter" ID="btnFiltra" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Filtra"></a>
         <a class="btn btn-filter svg-icon-30 svg-icon-sort" ID="btnOrdina" href="javascript:void(0)" data-toggle="tooltip" title="" data-original-title="Criteri di ordinamento e numero records"> </a>
    </div>
   </div>

    <div class="white-box" id="ordinamento" style="display:none;">
        <div class="row ">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
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

                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:Button ID="btnOrdinamento" runat="server" onclick="btnOrdina_Click" Text="Ordina" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>                        
                    </div>  
                </div>
            </div> 
        </div>
    </div>

    <div class="white-box" id="filtri" style="display:none;">
        <div class="row">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlOggetto" runat="server" DataSourceID="odsoggetto" DataTextField="oggetto" 
                                            DataValueField="idoggetto" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Oggetto"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsoggetto" runat="server" SelectMethod="SelectOggetto" TypeName="BusinessLogic.ComunicazioniBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlStatusComunicazioni" runat="server" DataSourceID="odsstatuscom" DataTextField="statuscomunicazione" 
                                            DataValueField="idstatuscomunicazione" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1" Text="Status"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsstatuscom" runat="server" SelectMethod="SelectStatusComunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>    
                        <div class="col-md-4" id="blockuser" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtUsers" runat="server" Columns="30" MaxLength="255" CssClass="form-control autouser" placeholder="Inserisci Driver"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDatadal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data invio dal"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:TextBox ID="txtDataal" runat="server" Columns="30" MaxLength="255" CssClass="form-control datePicker" placeholder="Data invio al"></asp:TextBox> 
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
            <div class="col-12 ">

                <asp:GridView ID="gvCom" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsCom" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="N. Ticket">   
                            <ItemTemplate>
                                <%# Eval("Idcomunicazione")%>
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Nominativo">   
                            <ItemTemplate>
                                Mitt.: <%# Eval("Cognome")%><br />
                                <%# Eval("societa")%> - <%# Eval("grade")%><br />
                                Dest.: <%# ReturnDestinatario(Eval("Destinatario").ToString())%><br />
                            </ItemTemplate>
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Oggetto">   
                            <ItemTemplate>
                                <a href="DetailCom-<%# Eval("UIDcomunicazione") %>" class="font-bold"> <%# ReturnOggetto(Eval("idstatuslettura").ToString(), Eval("oggetto").ToString()) %></a> 
                                <%# ReturnPriorita(Eval("priorita").ToString()) %> <%# ReturnIconAttach(Eval("UIDcomunicazionePadre").ToString()) %> 
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Ultimo Aggiornamento">   
                            <ItemTemplate>
                                <%# Eval("Dataultimoaggiornamento")%> <br />
                                <%# Eval("ultimomittente")%> 
                            </ItemTemplate>                    
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Stato">   
                            <ItemTemplate>
                                <%# Eval("Statuscomunicazione")%>                           
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                                                
                        <asp:TemplateField HeaderText="Chiuso il">   
                            <ItemTemplate>
                                <%# ReturnDataEstesa(Eval("Datachiusura").ToString()) %>                           
                            </ItemTemplate>                    
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Lavorazione">   
                            <ItemTemplate>
                                <%# DifferenceDate(Eval("Datainvio").ToString(), Eval("Datachiusura").ToString()) %>                           
                            </ItemTemplate>                    
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Chiudi">   
                            <ItemTemplate>
                                <%# ReturnChiudi(Eval("Idstatuscomunicazione").ToString(), Eval("UIDcomunicazione").ToString())%>                           
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                        
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCom" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectComunicazioni" TypeName="BusinessLogic.ComunicazioniBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdusers" DbType="Guid" Name="UserId" PropertyName="Value" />
                        <asp:ControlParameter ControlID="txtDatadal" Name="datadal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtDataal" Name="dataal" PropertyName="Text" Type="DateTime" />
                        <asp:ControlParameter ControlID="ddlOggetto" Name="oggetto" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlStatusComunicazioni" Name="idstatuscomunicazione" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="hdautorizz" Name="autorizzatore" PropertyName="Value" Type="Int32" />
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                        <asp:ControlParameter ControlID="ddlNRecord" Name="numrecord" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>  
                <asp:HiddenField ID="hdautorizz" runat="server" />
                <asp:HiddenField ID="hdusers" runat="server" />

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

<script type="text/javascript" src="<%=ResolveUrl("~/")%>js/windows-tools.js"></script>

<script type="text/javascript">  
    $(document).ready(function () {  
        $(".autouser").autocomplete({
            source: "../../../Handler/ListDriver.ashx",
            select: function (event, ui) {
                $("#ContentBody_txtUsers").val(ui.item.label);
                $("#ContentBody_hdusers").val(ui.item.value);
                return false;
            }
        });         
    });  
</script>

</asp:Content>