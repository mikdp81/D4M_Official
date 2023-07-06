<%@ Page Title="Modifica Utente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModUser.aspx.cs" Inherits="DFleet.Admin.Modules.Users.ModUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">


    <div class="row white-box">
       
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Utente</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewUsers")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
    
    </div>


        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


            

    <div class="form-body">

                    <div class="vtabs">
                                <ul class="nav tabs-vertical">
                                    <li class="tab active">
                                        <a data-toggle="tab" href="#datipersonali" aria-expanded="true" ><span class="hidden-xs active svg-icon-30L svg-icon-profilo p-l-30 ">Dati Personali</span> </a>
                                    </li>
                                    <li class="tab">
                                        <a data-toggle="tab" href="#datilavoro" aria-expanded="false"> <span class="hidden-xs  svg-icon-30L svg-icon-lavoro p-l-30">Dati Lavorativi</span> </a>
                                    </li>
                                    <li class="tab">
                                        <a aria-expanded="false" data-toggle="tab" href="#altro">  <span class="hidden-xs  svg-icon-30L svg-icon-dots p-l-30">Altro</span> </a>
                                    </li>
                                    <li class="tab">
                                        <a aria-expanded="false" data-toggle="tab" href="#firma">  <span class="hidden-xs  svg-icon-30L svg-icon-dots p-l-30">Credenziali Firma</span> </a>
                                    </li>
                                </ul>
                <div class="white-box  m-l-20">
                       <div class="tab-content">

                      

                        <div id="datipersonali" class="tab-pane active">
                                 

            <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                <label class="control-label">Nome *</label>      
                                    <asp:TextBox ID="txtNome" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                <label class="control-label">Cognome *</label>      
                                    <asp:TextBox ID="txtCognome" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                      
             </div>
            <div class="row">

                             <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Cellulare *</label>  
                                    <asp:TextBox ID="txtCellulare" runat="server" Columns="30" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Email *</label> 
                                    <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                  </div>
            <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data nascita</label>  
                                    <asp:TextBox ID="txtDataNascita" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Luogo nascita</label> 
                                    <asp:TextBox ID="txtLuogoNascita" runat="server" Columns="30" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Provincia nascita</label>  
                                    <asp:TextBox ID="txtProvinciaNascita" runat="server" Columns="30" MaxLength="3" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice fiscale</label> 
                                    <asp:TextBox ID="txtCodiceFiscale" runat="server" Columns="30" MaxLength="16" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
  
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Indirizzo residenza</label>  
                                    <asp:TextBox ID="txtIndirizzoResidenza" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Localita residenza</label> 
                                    <asp:TextBox ID="txtLocalitaResidenza" runat="server" Columns="30" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Provincia residenza</label>  
                                    <asp:TextBox ID="txtProvinciaResidenza" runat="server" Columns="30" MaxLength="3" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">CAP residenza</label> 
                                    <asp:TextBox ID="txtCapResidenza" runat="server" Columns="30" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
     
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Nr patente</label>  
                                    <asp:TextBox ID="txtNrPatente" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data emissione</label> 
                                    <asp:TextBox ID="txtDataEmissione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data scadenza</label>  
                                    <asp:TextBox ID="txtDataScadenza" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Ufficio emittente</label> 
                                    <asp:TextBox ID="txtUfficioEmittente" runat="server" Columns="30" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Status *</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="odsStatus"
                                        DataTextField="statusutente" DataValueField="idstatususer">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsStatus" runat="server" DataObjectTypeName="BusinessObject.Account" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="SelectStatus" TypeName="BusinessLogic.AccountBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>

                     <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Annotazioni</label>  
                                    <asp:TextBox ID="txtAnnotazioni" runat="server" Rows="3" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                   </div> 

      </div> 

                        <div id="datilavoro" class="tab-pane">
                                      
                
            <div class="row">                        
                               <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Societ&agrave; *</label>
                                    <asp:DropDownList ID="ddlCodSocieta" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsSoc"
                                        DataTextField="societa" DataValueField="codsocieta">
                                        <asp:ListItem Value="">Scegli Societa</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsSoc" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>          
                                        
                         <div class="col-md-2">
                                <div class="form-group">
                                <label class="control-label">Matricola *</label>      
                                    <asp:TextBox ID="txtMatricola" runat="server" Columns="30" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div> 
                            
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data Assunzione</label>  
                                    <asp:TextBox ID="txtDataAssunzione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div>
                        
                         </div>
            <div class="row">     
                             <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Grade Code</label>
                                    <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                        DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Grade"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Person Type</label>  
                                    <asp:DropDownList ID="ddlPersonType" runat="server" DataSourceID="odspersontype" DataTextField="persontype" 
                                        DataValueField="codpersontype" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Person Type"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odspersontype" runat="server" SelectMethod="SelectAllPersonType" TypeName="BusinessLogic.UtilitysBL">
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                             <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Funzione</label>  
                                    <asp:TextBox ID="txtFunzione" runat="server" Columns="30" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Maternit&agrave;</label> 
                                    <asp:TextBox ID="txtMaternita" runat="server" Columns="30" MaxLength="1" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                   </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Codice CDC</label> 
                                        <asp:TextBox ID="txtCodiceCDC" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
           
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Perc. CDC</label> 
                                        <asp:TextBox ID="txtPercCDC" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Descrizione CDC</label>  
                                        <asp:TextBox ID="txtDescrizioneCDC" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>              
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Codice CDC 2</label> 
                                        <asp:TextBox ID="txtCodiceCDC2" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
           
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Perc. CDC 2</label>  
                                        <asp:TextBox ID="txtPercCDC2" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>              

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Codice CDC 3</label> 
                                        <asp:TextBox ID="txtCodiceCDC3" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
           
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Perc. CDC 3</label>  
                                        <asp:TextBox ID="txtPercCDC3" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>              
                            </div>
            <div class="row">
         
                   <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice divisione</label> 
                                    <asp:TextBox ID="txtCodiceDivisione" runat="server" Columns="30" MaxLength="25" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                         <div class="col-md-9">
                                <div class="form-group">
                                    <label class="control-label">Descrizione divisione</label>  
                                    <asp:TextBox ID="txtDescrizioneDivisione" runat="server" Columns="30" MaxLength="25" CssClass="form-control"></asp:TextBox>
                                </div>

                        </div>
                   </div>
            <div class="row">  
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label class="control-label">Codice sede</label>  
                                    <asp:TextBox ID="txtCodiceSede" runat="server" Columns="30" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Descrizione sede</label> 
                                    <asp:TextBox ID="txtDescrizioneSede" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Indirizzo sede</label> 
                                    <asp:TextBox ID="txtIndirizzoSede" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                 
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label">Citt&agrave; sede</label>  
                                    <asp:TextBox ID="txtCittaSede" runat="server" Columns="30" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label class="control-label">Provincia sede</label> 
                                    <asp:TextBox ID="txtProvinciaSede" runat="server" Columns="30" MaxLength="2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label class="control-label">CAP sede</label>  
                                    <asp:TextBox ID="txtCapSede" runat="server" Columns="30" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data prevista dimissione</label> 
                                    <asp:TextBox ID="txtDataPrevistaDimissione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data dimissioni</label>  
                                    <asp:TextBox ID="txtDataDimissioni" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                                </div>
                            </div>
                       </div>    
                         
                         
                </div>                  
                                   
                                   
                <div id="altro" class="tab-pane">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Ruolo *</label>                                
                                <asp:DropDownList ID="ddlGruppo" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="odsGruppo"
                                    DataTextField="gruppouser" DataValueField="idgruppouser">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsGruppo" runat="server" DataObjectTypeName="BusinessObject.Account" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectGruppi" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group blockfornitore" style="display:none;">
                                <label class="control-label">Codice Fornitore</label>
                                <asp:DropDownList ID="ddlCodFornitore" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsFornitori"
                                    DataTextField="fornitore" DataValueField="codfornitore">
                                    <asp:ListItem Value="">Scegli Fornitore</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsFornitori" runat="server" DataObjectTypeName="BusinessObject.Utilitys" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>   
                        <div class="col-md-2">
                            <div class="form-group blockflgdriver" style="display:none;">
                                <label class="control-label">Entra come driver</label><br />
                                NO <input type="checkbox" id="flgdriver" class="js-switch" data-color="#13dafe" runat="server" /> SI
                            </div>
                        </div> 


                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Number</label>  
                                <asp:TextBox ID="txtNumber" runat="server" Columns="30" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Tipo Driver</label> 
                                <asp:TextBox ID="txtTipoDriver" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Fascia Car Policy</label> 
                                <asp:TextBox ID="txtFasciaCarPolicy" runat="server" Columns="30" MaxLength="5" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                      
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Matricola approvatore</label>  
                                <asp:TextBox ID="txtMatricolaApprovatore" runat="server" Columns="30" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice Societ&agrave; approvatore</label> 
                                <asp:TextBox ID="txtCodiceSocietaApprovatore" runat="server" Columns="30" MaxLength="5" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data inizio validit&agrave;</label>  
                                <asp:TextBox ID="txtDataInizioValidita" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Codice settore</label> 
                                <asp:TextBox ID="txtCodiceSettore" runat="server" Columns="30" MaxLength="30" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
              
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Descrizione settore</label>  
                                <asp:TextBox ID="txtDescrizioneSettore" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Descrizione approvatore</label> 
                                <asp:TextBox ID="txtDescrizioneApprovatore" runat="server" Columns="30" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Email approvatore</label>  
                                <asp:TextBox ID="txtEmailApprovatore" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>                      
                        </div>                 
                    </div>
                    
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Fascia importazione</label> 
                                <asp:TextBox ID="txtFasciaImportazione" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
          




                <div id="firma" class="tab-pane">
                    
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="color:red;font-weight:bold;">Lasciare vuoti se non si intende modificare</label> 
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">ClientId</label> 
                                <asp:TextBox ID="txtClientId" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">ImpersonatedUserId</label> 
                                <asp:TextBox ID="txtImpersonatedUserId" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">AuthServer</label> 
                                <asp:TextBox ID="txtAuthServer" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">PrivateKey</label> 
                                <asp:TextBox ID="txtPrivateKey" runat="server" Columns="30" Rows="5" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">BasePath</label> 
                                <asp:TextBox ID="txtBasePath" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">AccountId</label> 
                                <asp:TextBox ID="txtAccountId" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">PingUrl</label> 
                                <asp:TextBox ID="txtPingUrl" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">SignerEmail</label> 
                                <asp:TextBox ID="txtSignerEmail" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">SignerName</label> 
                                <asp:TextBox ID="txtSignerName" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">SignerClientId</label> 
                                <asp:TextBox ID="txtSignerClientId" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>





                <div class="form-actions">
                    <asp:HiddenField ID="hdgradecode" runat="server" />
                    <asp:HiddenField ID="hdidutente" runat="server" />
                    <asp:HiddenField ID="hdiduser" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
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

<script type="text/javascript">  
    $(document).ready(function () {  

        var idgruppo = $("#ContentBody_ddlGruppo").val();

        if (idgruppo == "3") {
            $(".blockfornitore").show();
        }
        else {
            $(".blockfornitore").hide();
        }

        if (idgruppo == "1") {
            $(".blockflgdriver").show();
        }
        else {
            $(".blockflgdriver").hide();
        }

        $("#ContentBody_ddlGruppo").change(function () {
            var valore = $(this).val();

            if (valore == "1") {
                $(".blockflgdriver").show();
            }
            else {
                $(".blockflgdriver").hide();
            }

            if (valore == "3") {
                $(".blockfornitore").show();
            }
            else {
                $(".blockfornitore").hide();
            }
        });         
    });  
</script>

</asp:Content>