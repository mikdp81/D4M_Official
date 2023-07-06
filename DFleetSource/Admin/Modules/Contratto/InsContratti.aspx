<%@ Page Title="Inserimento Contratto" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsContratti.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsContratti" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Contratto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewContratti")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">



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
                                                        <asp:DropDownList ID="ddlFornitore" runat="server" CssClass="form-control select2 ddlFornitore" AppendDataBoundItems="True"
                                                             DataSourceID="odscodfornitore" DataTextField="fornitore" DataValueField="codfornitore">
                                                            <asp:ListItem Value="" Text="Fornitore"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="odscodfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL" >
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
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Ordine rif.  </label>
                                                <asp:TextBox ID="txtNumeroOrdine" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Tipo Utilizzo</label>
                                                <asp:DropDownList ID="ddlTipoUtilizzo" runat="server" DataSourceID="odstipoutilizzo" DataTextField="tipoutilizzo" 
                                                    DataValueField="codutilizzo" CssClass="form-control" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="" Text="Codice Tipo Utilizzo"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odstipoutilizzo" runat="server" SelectMethod="SelectTipoUtilizzo" TypeName="BusinessLogic.ContrattiBL" >
                                                    <SelectParameters>
                                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource> 
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Tipologia</label>
                                                <asp:DropDownList ID="ddlCodTipoContratto" runat="server" DataSourceID="odscontrattitipo" DataTextField="tipocontratto" 
                                                    DataValueField="codtipocontratto" CssClass="form-control select2" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="" Text="Codice Tipo contratto"></asp:ListItem>
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
                                                    <asp:ListItem Value="" Text="Codice Tipo uso contratto"></asp:ListItem>
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
                                            <label class="control-label">File contratto* (*.pdf)</label>
                                            <asp:FileUpload ID="fuFileContratto"  CssClass="form-control" runat="server" />
                                        </div>
                                    </div> 
                                 
                                  <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Status  *</label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statuscontratto" 
                                                DataValueField="idstatuscontratto" CssClass="form-control" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="-1" Text="Status Contratto"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusContratto" TypeName="BusinessLogic.ContrattiBL">
                                                <SelectParameters>
                                                    <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>

                       </div>   </div>
                        </div>


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
                                <label class="control-label">Targa *</label>
                                <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                            </div>
                        </div>  


                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Modello *</label>                                
                                <asp:DropDownList ID="ddlCodjatoAuto" runat="server" CssClass="form-control select2 ddlAuto" AppendDataBoundItems="True"
                                    DataSourceID="odsauto" DataTextField="modello" DataValueField="codjatoauto">
                                    <asp:ListItem Value="" Text="Auto"></asp:ListItem>
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
                                <label class="control-label">Car Policy *</label>                             
                                <asp:DropDownList ID="ddlCodCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
                                     DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                    <asp:ListItem Value="" Text="Codice Car Policy"></asp:ListItem>
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
                                <label class="control-label">Car List *</label>                             
                                <asp:DropDownList ID="ddlCodCarList" runat="server" CssClass="form-control select2 ddlCarList" AppendDataBoundItems="True"
                                    DataSourceID="odscarlist" DataTextField="carlist" DataValueField="codcarlist">
                                    <asp:ListItem Value="" Text="Codice Car List"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div>    

                       </div>   </div>
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
                                <label class="control-label">Societ&agrave; *</label>
                                <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                    DataValueField="codsocieta" CssClass="form-control select2 ddlSocieta" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Societa"></asp:ListItem>
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
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control select2 ddlUtente" AppendDataBoundItems="True"
                                    DataSourceID="odsusers" DataTextField="cognome" DataValueField="UserId">
                                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
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
                                    <asp:ListItem Value="" Text="Tipo Assegnazione"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstipoassegnazione" runat="server" SelectMethod="SelectAllContrattiTipoAssegnazione" TypeName="BusinessLogic.ContrattiBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div> 
                       </div>   </div>
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
                                <label class="control-label">Inizio contratto</label>
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


     </div>   </div>
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
                                <label class="control-label">Km</label>
                                <asp:TextBox ID="txtKmContratto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Km Contratto" TextMode="Number"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Franchigia Km</label>
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



     </div>   </div>
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

 </div>   </div>

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

 </div>   </div>
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
                                            <div class="form-group">
                                        <asp:TextBox ID="txtAnnotazionicontratto" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni contratto" TextMode="MultiLine"></asp:TextBox>
                                     </div>

                                     </div>
                                 </div>
                     
                        </div>
  
              </div>  
<hr class="text-verde"/>
              
                                            <div class="form-action">
                                                <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva e nuovo" CssClass="btn btn-success" /> 
                                                <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva e chiudi" CssClass="btn btn-success" /> 
                                            </div>
                                  
         
      
    </div>
</div>
        </div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $(".ddlSocieta").change(function () {
            var codsocieta = $(this).val();

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListUtentiXSocieta.ashx?codsocieta=" + codsocieta,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded,
                error: AjaxFailed
            });

            /*$.ajax({
                type: "POST",
                url: "../../../Handler/ListCarPolicyXSocieta.ashx?codsocieta=" + codsocieta,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded2,
                error: AjaxFailed2
            });*/
        });   

        $(".ddlCarList").change(function () {
            var codcarlist = $(this).val();

           /* $.ajax({
                type: "POST",
                url: "../../../Handler/ListCarPolicyXCarList.ashx?codcarlist=" + codcarlist,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded3,
                error: AjaxFailed3
            });

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListAutoXCarList.ashx?codcarlist=" + codcarlist,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded4,
                error: AjaxFailed4
            });*/
        });

        $(".ddlFornitore").change(function () {
            var codfornitore = $(this).val();

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListAutoXFornitoreXContratti.ashx?codfornitore=" + codfornitore,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded5,
                error: AjaxFailed5
            });
        });  
        
    });  


    function AjaxSucceeded(result) {
        BindCheckBoxList(result);
    }
    function AjaxFailed(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList(result, myId);
    }
    function CreateCheckBoxList(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value='00000000-0000-0000-0000-000000000000'>Utente</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlUsers").html(listItems);
    }



    function AjaxSucceeded2(result) {
        BindCheckBoxList2(result);
    }
    function AjaxFailed2(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList2(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList2(result, myId);
    }
    function CreateCheckBoxList2(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value=''>Codice Car Policy</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCodCarPolicy").html(listItems);
    }



    function AjaxSucceeded3(result) {
        BindCheckBoxList3(result);
    }
    function AjaxFailed3(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList3(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList3(result, myId);
    }
    function CreateCheckBoxList3(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value=''>Codice Car Policy</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCodCarPolicy").html(listItems);
    }



    function AjaxSucceeded4(result) {
        BindCheckBoxList4(result);
    }
    function AjaxFailed4(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList4(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList4(result, myId);
    }
    function CreateCheckBoxList4(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value=''>Auto</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCodjatoAuto").html(listItems);
    }



    function AjaxSucceeded5(result) {
        BindCheckBoxList5(result);
    }
    function AjaxFailed5(result) {
        alert('Caricamento fallito.');
    }
    function BindCheckBoxList5(result, myId) {
        //var items = JSON.parse(result.d);
        CreateCheckBoxList5(result, myId);
    }
    function CreateCheckBoxList5(checkboxlistItems, myId) {
        var listItems = "";
        listItems += "<option value=''>Fornitore</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCodjatoAuto").html(listItems);
    }
</script>

</asp:Content>