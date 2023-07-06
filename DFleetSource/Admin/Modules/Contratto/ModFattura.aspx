<%@ Page Title="Modifica Fattura" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModFattura.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.ModFattura" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Fattura</h3>
            </div>
            <div class="col-md-5 text-right">                
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewFatture")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:DropDownList ID="ddlTemplate" runat="server" DataSourceID="odstemplate" DataTextField="nometemplate" 
                                            DataValueField="idtemplatefattura" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Scegli Template"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odstemplate" runat="server" SelectMethod="SelectTemplateFatture" TypeName="BusinessLogic.ContrattiBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
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
                                        <asp:TextBox ID="txtData" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Riferimento"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:HiddenField ID="hdPagina" runat="server" Value="" />
                                        <asp:Button ID="btnAbbina" runat="server" onclick="btnAbbina_Click" Text="Abbina Automaticamente" CssClass="btn btn-info" />
                                        <asp:Button ID="btnSvuota" runat="server" onclick="btnSvuota_Click" Text="Svuota Abbinamento" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                
                <ul class="nav nav-tabs" role="tablist">
                    <li class="tab active">
                        <a data-toggle="tab" href="#dati" aria-expanded="true" ><span class="visible-xs"><i class="ti-home"></i></span><span class="hidden-xs"> Dati</span></a>
                    </li>
                    <li class="tab">
                        <a data-toggle="tab" href="#dettagli" aria-expanded="false"><span class="visible-xs"><i class="ti-home"></i></span><span class="hidden-xs"> Dettagli</span></a>
                    </li>
                </ul>

                <div class="tab-content">
                    <div id="dati" class="tab-pane active">
                        <div class="row">            
                            <div class="col-md-12">                                            
                                <asp:Literal ID="ltdatifattura" runat="server"></asp:Literal><br /><br />
                            </div> 
                        </div>
                    </div>    

                    <div id="dettagli" class="tab-pane">
                        <div class="row"> 
                            <div class="col-md-12">
                                            
                                <asp:GridView ID="gvRicFatture" runat="server" OnRowDataBound="OnRowDataBound" 
                                        AutoGenerateColumns="False" DataSourceID="odsRicFatture" CssClass="display nowrap dataTable" 
                                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">   
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>                    
                                        </asp:TemplateField>  
                    
                                        <asp:TemplateField HeaderText="Descrizione">
                                            <ItemTemplate>
                                                <div class="text-break width300"><a href="<%# ReturnUrlAss(Eval("descrizione").ToString(), Eval("riftesto").ToString()) %>" target="_blank"><br />
                                                <%# Eval("riftesto").ToString().Replace("***", "<br />")%> <%# Eval("descrizione").ToString().Replace("***", "<br />")%><br /> Utenti associati: <%# Eval("totuser") %></a></div>
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                        
                                        <asp:TemplateField HeaderText="Prezzo Totale">
                                            <ItemTemplate>
                                                <%# Eval("prezzotot")%>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                        
                                        <asp:TemplateField HeaderText="Abbinamento"> 
                                            <ItemTemplate>    
                                                <asp:TextBox ID="txtAutoCdc" runat="server" Columns="30" MaxLength="20" CssClass="form-control autocdc" placeholder="Inserisci cognome o cdc"></asp:TextBox> <asp:TextBox ID="txtCdc" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Inserire CDC se non presente nel menu"></asp:TextBox>
                                                <asp:TextBox ID="txtDataInizio" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Inizio Periodo" Text='<%# Eval("datainizioperiodo", "{0: dd/MM/yyyy}")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtDataFine" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Fine Periodo" Text='<%# Eval("datafineperiodo", "{0: dd/MM/yyyy}")%>'></asp:TextBox> 
                                                <asp:HiddenField ID="hdUid" runat="server" Value='<%# Eval("Uid")%>'  />
                                                <asp:HiddenField ID="hdvaloreabbinamento" runat="server" Value='<%# Eval("centrocostoabb") + ";;" + Eval("tipocentrocosto") + ";" + Eval("Uidcentrocosto")%>'  />
                                                <asp:HiddenField ID="hdvaloreabbinamento2" runat="server" Value='<%# Eval("centrocostoabb2") + ";;" + Eval("tipocentrocosto2") + ";" + Eval("Uidcentrocosto2")%>'  />
                                                <asp:HiddenField ID="hdvaloreabbinamento3" runat="server" Value='<%# Eval("centrocostoabb3") + ";;" + Eval("tipocentrocosto3") + ";" + Eval("Uidcentrocosto3")%>'  />
                                                <asp:HiddenField ID="hdvaloreabbinamento4" runat="server" Value='<%# Eval("centrocostoabb4") + ";;" + Eval("tipocentrocosto4") + ";" + Eval("Uidcentrocosto4")%>'  />
                                            </ItemTemplate>                                
                                        </asp:TemplateField>  
                                                    
                                        <asp:TemplateField HeaderText="2° Abbinamento"> 
                                            <ItemTemplate>  
                                                <asp:TextBox ID="txtAutoCdc2" runat="server" Columns="30" MaxLength="20" CssClass="form-control autocdc" placeholder="Inserisci cognome o cdc"></asp:TextBox> 
                                                <asp:TextBox ID="txtCdc2" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Inserire CDC se non presente nel menu"></asp:TextBox> 
                                                <asp:TextBox ID="txtDataInizio2" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Inizio Periodo" Text='<%# Eval("datainizioperiodo2", "{0: dd/MM/yyyy}")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtDataFine2" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Fine Periodo" Text='<%# Eval("datafineperiodo2", "{0: dd/MM/yyyy}")%>'></asp:TextBox> 
                                            </ItemTemplate>                                
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="3° Abbinamento"> 
                                            <ItemTemplate>  
                                                <asp:TextBox ID="txtAutoCdc3" runat="server" Columns="30" MaxLength="20" CssClass="form-control autocdc" placeholder="Inserisci cognome o cdc"></asp:TextBox> 
                                                <asp:TextBox ID="txtCdc3" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Inserire CDC se non presente nel menu"></asp:TextBox> 
                                                <asp:TextBox ID="txtDataInizio3" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Inizio Periodo" Text='<%# Eval("datainizioperiodo3", "{0: dd/MM/yyyy}")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtDataFine3" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Fine Periodo" Text='<%# Eval("datafineperiodo3", "{0: dd/MM/yyyy}")%>'></asp:TextBox> 
                                            </ItemTemplate>                                
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="4° Abbinamento"> 
                                            <ItemTemplate>  
                                                <asp:TextBox ID="txtAutoCdc4" runat="server" Columns="30" MaxLength="20" CssClass="form-control autocdc" placeholder="Inserisci cognome o cdc"></asp:TextBox> 
                                                <asp:TextBox ID="txtCdc4" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Inserire CDC se non presente nel menu"></asp:TextBox> 
                                                <asp:TextBox ID="txtDataInizio4" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Inizio Periodo" Text='<%# Eval("datainizioperiodo4", "{0: dd/MM/yyyy}")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtDataFine4" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Fine Periodo" Text='<%# Eval("datafineperiodo4", "{0: dd/MM/yyyy}")%>'></asp:TextBox> 
                                            </ItemTemplate>                                
                                        </asp:TemplateField> 
                                    </Columns>    
                                    <PagerStyle HorizontalAlign="Right" />    
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsRicFatture" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectDetailFatture" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hduidfattura" Name="Uidfattura" PropertyName="Value" DbType="Guid" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                        <asp:ControlParameter ControlID="hdPagina" Name="pagina" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>  

                                
                                <asp:ObjectDataSource ID="odsCdc" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectCDCXSocieta" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>  
                                                          
                                <div class="dataTables_wrapper">
                                    <div class="dataTables_info">
                                        <asp:Label ID="lblNumRecord" runat="server" Text=""></asp:Label>       
                                    </div>            

                                    <div class="dataTables_paginate paging_simple_numbers">
                                        <asp:LinkButton ID="pagingprec" runat="server" OnClick="pagingprec_Click" CssClass="paginate_button"><</asp:LinkButton>
                                        <asp:TextBox ID="txtnumpag" runat="server" Text="1" style="width:50px;text-align:center;" OnTextChanged="txtnumpag_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox> 
                                        / <asp:Label ID="lblNumPagTot" runat="server" Text=""></asp:Label>
                                        <asp:LinkButton ID="pagingnext" runat="server" OnClick="pagingnext_Click" CssClass="paginate_button">></asp:LinkButton>
                                    </div>
                                </div>
                                
                                
                                <br /><asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Conferma Abbinamento" CssClass="btn btn-success" />
                                <asp:Button ID="btnEsporta" runat="server" onclick="btnEsporta_Click" Text="Esporta" CssClass="btn btn-info" />
                            </div>                        
                        </div>
                    </div> 
                </div>
            </div> 
        </div>
    </div>
</div>

<asp:HiddenField ID="hduidfattura" runat="server" />
<asp:HiddenField ID="hdcodsocieta" runat="server" />
<asp:HiddenField ID="hdtemplateabb" runat="server" />

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function () {  
        var codsocieta = $("#ContentBody_hdcodsocieta").val();
        $(".autocdc").autocomplete({
            source: "../../../Handler/ListCdcXSocieta.ashx?codsocieta="+codsocieta
        });          
    });  
</script>

</asp:Content>