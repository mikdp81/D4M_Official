<%@ Page Title="Modifica Contratto" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModContratti.aspx.cs" Inherits="DFleet.Admin.Modules.EPartner.ModContratti" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Contratto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/EPartner/ViewContratti")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#contratto" aria-controls="contratto" role="tab" data-toggle="tab" aria-expanded="true"><span class="visible-xs"><i class="ti-home"></i></span><span class="hidden-xs"> Contratto</span></a></li>
                    <li role="presentation" class=""><a href="#storico" aria-controls="storico" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Storico</span></a></li>
                    <li role="presentation" class=""><a href="#ordine" aria-controls="ordine" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Rif. Ordine</span></a></li>
                    <li role="presentation" class=""><a href="#proroga" aria-controls="proroga" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Data Proroga</span></a></li>
                    <li role="presentation" class=""><a href="#kmauto" aria-controls="kmauto" role="tab" data-toggle="tab" aria-expanded="false"><span class="visible-xs"><i class="ti-user"></i></span> <span class="hidden-xs">Km Auto</span></a></li>
                
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="contratto">
                        
                        
                       
                   <!-- Dati Generali-->
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Dati Generali</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label font-bold">Fornitore *</label>                                
                                        <asp:DropDownList ID="ddlFornitore" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                            DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="" Text="Fornitore"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div> 
                                
                          
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Numero</label>
                                        <asp:TextBox ID="txtNumeroContratto" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Contratto"></asp:TextBox> 
                                    </div>
                                </div>     
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Data </label>
                                        <asp:TextBox ID="txtDataContratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Contratto"></asp:TextBox> 
                                    </div>
                                </div>  
                            </div>
                         </div>
                       

                        <div class="row">
                            <div class="col-md-12">
                                

                                <div class="col-md-6">

                                    <div class="form-group">
                                        <label class="control-label">Ordine rif. </label>
                                        <asp:TextBox ID="txtNumeroOrdine" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine"></asp:TextBox> 
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Tipologia</label>
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
                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Uso</label>
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
                         </div>
                          
                          <div class="row">
                            <div class="col-md-12">
                        <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">File Contratto (*.pdf)</label>
                                        <asp:FileUpload ID="fuFileContratto"  CssClass="form-control" runat="server" />
                                        <asp:HiddenField ID="hdFileContratto" runat="server" />
                                        <asp:Label ID="lblViewFileContratto" runat="server" Text=""></asp:Label>
                                    </div>
                                </div> 
                             <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Status *</label>
                                        <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statuscontratto" 
                                            DataValueField="idstatuscontratto" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1" Text="Status Contratto"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusContratto" TypeName="BusinessLogic.ContrattiBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                             </div>
                                </div>  
                         </div>
                      


                 <!-- Auto-->
                      <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Auto</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label font-bold">Targa *</label>
                                        <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                                    </div>
                                </div> 
                                 <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label font-bold">Modello *</label>
                                        <asp:DropDownList ID="ddlCodjatoAuto" runat="server" CssClass="form-control select2 ddlAuto" AppendDataBoundItems="True"
                                            DataSourceID="odsauto" DataTextField="modello" DataValueField="codjatoauto">
                                            <asp:ListItem Selected="True" Value="" Text="Auto"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsauto" runat="server" SelectMethod="SelectAllAuto" TypeName="BusinessLogic.CarsBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Colore </label>                                
                                        <asp:DropDownList ID="ddlColore" runat="server" DataSourceID="odscolore" DataTextField="optional" 
                                            DataValueField="codoptional" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="" Text="Colore"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscolore" runat="server" SelectMethod="SelectAllColori" TypeName="BusinessLogic.CarsBL" OldValuesParameterFormatString="original_{0}">
                                            <SelectParameters>
                                                <asp:Parameter Name="codjatoauto" Type="String" />
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div> 
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Car Policy</label>                             
                                        <asp:DropDownList ID="ddlCodCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
                                                DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                            <asp:ListItem Selected="True" Value="" Text="Codice Car Policy"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscarpolicy" runat="server" SelectMethod="SelectAllCarPolicy" TypeName="BusinessLogic.CarsBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>  
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Car List</label>                             
                                        <asp:DropDownList ID="ddlCodCarList" runat="server" CssClass="form-control select2 ddlCarList" AppendDataBoundItems="True"
                                            DataSourceID="odscarlist" DataTextField="carlist" DataValueField="codcarlist">
                                            <asp:ListItem Selected="True" Value="" Text="Codice Car List"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odscarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>  
                 
                            </div>
                         </div>
                       </div>
     
                    
                    
                    <!-- Contraente-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Contraente</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label font-bold">Societ&agrave; *</label>
                                        <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                            DataValueField="codsocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="" Text="Societa"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odssocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL" >
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div> 
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label">Driver Attuale *</label>
                                        <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                            DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True" Enabled="false">
                                            <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>    

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label">Tipo Assegnazione *</label>
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
  
                      
                          
                                 </div>  
                            </div>  
 </div> 


                    <!-- Validit-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Validit&agrave;</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Durata (Mesi)</label>
                                        <asp:TextBox ID="txtDurataMesi" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Durata Mesi" TextMode="Number"></asp:TextBox> 
                                    </div>
                                </div>  

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Inizio Contratto</label>
                                        <asp:TextBox ID="txtDatainiziocontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio contratto"></asp:TextBox> 
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Inizio uso</label>
                                        <asp:TextBox ID="txtDatainiziouso" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio uso"></asp:TextBox> 
                                    </div>
                                </div> 
                                 
                             
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Fine contratto</label>
                                        <asp:TextBox ID="txtDatafinecontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine contratto"></asp:TextBox> 
                                    </div>
                                </div>   
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Data revisione </label>
                                        <asp:TextBox ID="txtDatarevisione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data revisione"></asp:TextBox> 
                                    </div>
                                </div>  
                     
                            </div>
                        </div>    
                    </div>


                    <!-- km-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Km</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Km Previsti</label>
                                        <asp:TextBox ID="txtKmContratto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Km Contratto" TextMode="Number"></asp:TextBox> 
                                    </div>
                                </div>   
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Franchigia km </label>
                                        <asp:TextBox ID="txtFranchigia" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Franchigia"></asp:TextBox> 
                                    </div>
                                </div>  
                                    <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Soglia km</label>
                                        <asp:TextBox ID="txtSogliakm" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Soglia km"></asp:TextBox> 
                                    </div>
                                </div> 
                             <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Costo km eccedente</label>
                                        <asp:TextBox ID="txtCostokmeccedente" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo km eccedente"></asp:TextBox> 
                                    </div>
                                </div>                       
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Costo km rimborso</label>
                                        <asp:TextBox ID="txtCostokmrimborso" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo km rimborso"></asp:TextBox> 
                                    </div>
                                </div>                       
                         
                          </div>


                        </div>
                         </div>

           <!-- Dati immatricolazione-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Dati immatricolazione</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">

                                   <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Immatricolazione</label>
                                        <asp:TextBox ID="txtDataimmatricolazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data immatricolazione"></asp:TextBox> 
                                    </div>
                                </div>    
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Bollo</label>
                                        <asp:TextBox ID="txtBollo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Bollo"></asp:TextBox> 
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
                                        <label class="control-label">Super Bollo</label>
                                        <asp:TextBox ID="txtSuperBollo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Super Bollo"></asp:TextBox> 
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Scadenza Super Bollo</label>
                                        <asp:TextBox ID="txtScadenzaSuperBollo" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza Super Bollo"></asp:TextBox>
                                    </div>
                                </div>

                                                     
                             
                   </div>
                   
                        </div>   

                         </div>


        <!-- Dati Finanziari-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Dati Finanziari</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Canone leasing</label>
                                        <asp:TextBox ID="txtCanoneleasing" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone leasing"></asp:TextBox> 
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
                                        <label class="control-label">Canone Figurativo Partner</label>
                                        <asp:TextBox ID="txtCanoneFigurativo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Figurativo Partner"></asp:TextBox> 
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Delta Canone</label>
                                        <asp:TextBox ID="txtDeltaCanone" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Delta Canone"></asp:TextBox> 
                                    </div>
                                </div> 
                            </div>
                         </div>
                                
                         </div>


        <!-- Fringe-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Fringe</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">

                            <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Emissioni</label>
                                        <asp:TextBox ID="txtEmissioni" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Emissioni"></asp:TextBox> 
                                    </div>
                                </div> 
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Fringe Benefit</label>
                                        <asp:TextBox ID="txtFringe" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Fringe Benefit"></asp:TextBox> 
                                    </div>
                                </div> 
                                <div class="col-md-3">
                                    <div class="form-group">                                                
                                        <br /><asp:Label ID="lblCalcoloFringe" runat="server" Text=""></asp:Label>
                                    </div>
                                </div> 
                     
                            </div>
                            
                              
                            </div>
                           
                              
                            </div>
                       

        <!-- Annotazioni-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Annotazioni</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                         <div class="row">   
                            <div class="col-md-12">
                                  <div class="col-md-12">
                                    <div class="form-group">
                                <asp:TextBox ID="txtAnnotazionicontratto" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni contratto" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                 </div>
                                                         
                            </div>
                           </div>
                        



                              <!-- Pool-->
                         <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Pool</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                            <div class="row">   
                                <div class="col-md-12">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label class="control-label">Pool Attivo</label>   <br />                                         
                                            NO <input type="checkbox" id="checkpool" class="js-switch" data-color="#13dafe" runat="server" /> SI<br /><br />
                                        </div>
                                    </div> 
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label class="control-label">Status Pool</label>                                            
                                            <asp:DropDownList ID="ddlStatusPool" runat="server" DataSourceID="odsstatuspool" DataTextField="statuspool" 
                                                DataValueField="idstatuspool" CssClass="form-control" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="-1" Text="Status Pool"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsstatuspool" runat="server" SelectMethod="SelectAllStatusContrattoPool" TypeName="BusinessLogic.ContrattiBL">
                                                <SelectParameters>
                                                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>                                         
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Driver Assegnatario</label>
                                            <asp:DropDownList ID="ddlUserIdPool" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                                DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Driver Assegnatario"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>  
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label class="control-label">Solo Assegnatari</label>   <br />                                         
                                            NO <input type="checkbox" id="checkassegnatario" class="js-switch" data-color="#13dafe" runat="server" /> SI<br /><br />
                                        </div>
                                    </div> 
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Note</label>
                                            <asp:TextBox ID="txtNotePool" runat="server" Rows="3" CssClass="form-control" TextMode="MultiLine" placeholder="Note"></asp:TextBox> 
                                        </div>
                                    </div>   
                                </div>
                            </div>                              
                        
                         
                            <div class="row"> 
                                <div class="col-md-12">
                                    <asp:HiddenField ID="hdidcontratto" runat="server" />
                                    <asp:HiddenField ID="hduid" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
     

                    <div id="storico" class="tab-pane">
                        <div class="row"> 
                            <div class="col-md-12">
                                <h4>Storico Assegnazioni:</h4><br />
                                <asp:Literal ID="ltstoricoassegnazioni" runat="server"></asp:Literal><br /><br />
                            </div>                        
                        </div>
                    </div>

                                

                    <div id="ordine" class="tab-pane">
                        <div class="row"> 
                            <div class="col-12">
                                <asp:Label ID="lblAuto" runat="server" CssClass="font-bold" Text="" /><br />                
                                <asp:Label ID="lblDatiAuto" runat="server" Text="" /><br /><br />
                                <asp:Label ID="lblDatiOrdine" runat="server" Text="" />

                                <div style="text-align:right;">                                    
                                    <asp:Label ID="lblcanoneleasing" runat="server" CssClass="font-bold" Text=""></asp:Label>
                                </div>
                                
                                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br />
                                <asp:Literal ID="ltoptional" runat="server"></asp:Literal>
                            </div>                        
                        </div>
                    </div>

                    
                    <div id="proroga" class="tab-pane">
                        <div class="row"> 
                            <div class="col-md-12">                             
                                <div class="row"> 
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:Label ID="lblnoteproroga" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>                             
                                <div class="row"> 
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Data Proroga</label>
                                            <asp:TextBox ID="txtDataProroga" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Proroga"></asp:TextBox> 
                                        </div>
                                    </div>    
                                </div>     
                            </div>
                        </div>
                    </div>




                        

                    <div id="kmauto" class="tab-pane">
                                                
                        <div class="row"> 
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Data Rilevazione</label>
                                    <asp:TextBox ID="txtDataInsKm" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Rilevazione"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Km Percorsi</label>
                                    <asp:TextBox ID="txtKmPercorsi" runat="server" Cols="10" Maxlength="10" CssClass="form-control" placeholder="Km Percorsi"></asp:TextBox>
                                </div>
                            </div>    
                        </div>   

                        
                        <div class="row"> 
                            <div class="col-md-12">
                                <br /><br />
                            </div>    
                        </div>  

                        <div class="row"> 
                            <div class="col-12">

                                <asp:GridView ID="gvKmPercorsi" runat="server"
                                        AutoGenerateColumns="False" DataSourceID="odsKmPercorsi" CssClass="display nowrap dataTable" 
                                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">   
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>                    
                                        </asp:TemplateField>  
                    
                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate>
                                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datains")) %>  
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="Rilevazioni km a cruscotto">
                                            <ItemTemplate>
                                                <DIV class="text-right"><%# Eval("kmpercorsi")%></DIV>
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                    </Columns>    
                                    <PagerStyle HorizontalAlign="Right" />    
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsKmPercorsi" runat="server" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="SelectKmPercorsiXTarga" TypeName="BusinessLogic.ContrattiBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtTarga" Name="targa" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>   

                            </div>                        
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script>
    jQuery(document).ready(function () {
        jQuery(".btnass").click(function () {
            var value = $(this).attr("data-id");
            var value1 = $(this).attr("data-userid");
            var value2 = $(this).attr("data-dataassdal");
            var value3 = $(this).attr("data-dataassal");
            var value4 = $("#ContentBody_ddlCodsocieta").val();
            var value5 = $(this).attr("data-idstatus");

            jQuery("#ContentBody_hdidassegnazione").val(value);
            jQuery("#ContentBody_ddlUserAss option[value='" + value1 + "']").prop("selected", true);
            jQuery("#ContentBody_ddlSocietaNewPool option[value='" + value4 + "']").prop("selected", true);
            jQuery("#ContentBody_ddlSocietaNewRitiro option[value='" + value4 + "']").prop("selected", true);
            jQuery("#ContentBody_txtDataInizioAssegnazione").val(value2);
            jQuery("#ContentBody_txtDataFineAssegnazione").val(value3);
            jQuery("#ContentBody_hdistatusassegnazione").val(value5);
        });

    });
</script>

</asp:Content>