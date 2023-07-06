<%@ Page Title="Trasforma in Contratto" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModContratto.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ModContratto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Trasforma in Contratto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdini")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Label ID="lblDatiRiepilogo" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Tipo Assegnazione </label>
                                <asp:DropDownList ID="ddlTipoAssegnazione" runat="server" DataSourceID="odstipoassegnazione" DataTextField="tipoassegnazione" 
                                    DataValueField="idtipoassegnazione" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Tipo Assegnazione"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstipoassegnazione" runat="server" SelectMethod="SelectAllContrattiTipoAssegnazione" TypeName="BusinessLogic.ContrattiBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>                    
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Codice Tipo contratto</label>
                                <asp:DropDownList ID="ddlCodTipoContratto" runat="server" DataSourceID="odscontrattitipo" DataTextField="tipocontratto" 
                                    DataValueField="codtipocontratto" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Codice Tipo contratto"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscontrattitipo" runat="server" SelectMethod="SelectAllContrattiTipo" TypeName="BusinessLogic.ContrattiBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>                                
                            </div>
                        </div>  
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Codice Tipo uso contratto</label>
                                <asp:DropDownList ID="ddlCodTipoUsoContratto" runat="server" DataSourceID="odscontrattitipouso" DataTextField="tipousocontratto" 
                                    DataValueField="codtipousocontratto" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Codice Tipo uso contratto"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscontrattitipouso" runat="server" SelectMethod="SelectAllContrattiTipoUso" TypeName="BusinessLogic.ContrattiBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>                                
                            </div>
                        </div>    
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Numero Contratto </label>
                                <asp:TextBox ID="txtNumeroContratto" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Contratto"></asp:TextBox> 
                            </div>
                        </div>      
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Data Contratto</label>
                                <asp:TextBox ID="txtDataContratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Contratto"></asp:TextBox> 
                            </div>
                        </div>         
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Durata Mesi</label>
                                <asp:TextBox ID="txtDurataMesi" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Durata Mesi" TextMode="Number"></asp:TextBox> 
                            </div>
                        </div>  
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Km Contratto</label>
                                <asp:TextBox ID="txtKmContratto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Km Contratto" TextMode="Number"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Franchigia </label>
                                <asp:TextBox ID="txtFranchigia" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Franchigia"></asp:TextBox> 
                            </div>
                        </div>          
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data inizio contratto</label>
                                <asp:TextBox ID="txtDatainiziocontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio contratto"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data inizio uso</label>
                                <asp:TextBox ID="txtDatainiziouso" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio uso"></asp:TextBox> 
                            </div>
                        </div>    
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data fine contratto</label>
                                <asp:TextBox ID="txtDatafinecontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine contratto"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Targa</label>
                                <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Annotazioni contratto</label>
                                <asp:TextBox ID="txtAnnotazionicontratto" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni contratto" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">File Contratto (sono accettati solo i file .pdf)</label>
                                <asp:FileUpload ID="fuFileContratto"  CssClass="form-control" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row"> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data immatricolazione</label>
                                <asp:TextBox ID="txtDataimmatricolazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data immatricolazione"></asp:TextBox> 
                            </div>
                        </div>    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Bollo</label>
                                <asp:TextBox ID="txtBollo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Bollo"></asp:TextBox> 
                            </div>
                        </div>  
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Super Bollo</label>
                                <asp:TextBox ID="txtSuperBollo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Super Bollo"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Scadenza Bollo</label>
                                <asp:TextBox ID="txtScadenzaBollo" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza Bollo"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Scadenza Super Bollo</label>
                                <asp:TextBox ID="txtScadenzaSuperBollo" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza Super Bollo"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row"> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Emissioni</label>
                                <asp:TextBox ID="txtEmissioni" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Emissioni"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Canone Finanziario</label>
                                <asp:TextBox ID="txtCanoneFinanziario" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Finanziario"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Canone Servizi</label>
                                <asp:TextBox ID="txtCanoneServizi" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Servizi"></asp:TextBox> 
                            </div>
                        </div>                      
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Costo km eccedente</label>
                                <asp:TextBox ID="txtCostokmeccedente" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo km eccedente"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                    <div class="row">                          
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Costo km rimborso</label>
                                <asp:TextBox ID="txtCostokmrimborso" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo km rimborso"></asp:TextBox> 
                            </div>
                        </div>                       
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Soglia km</label>
                                <asp:TextBox ID="txtSogliakm" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Soglia km"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Trasforma" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>