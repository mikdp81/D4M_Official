<%@ Page Title="Modifica Multa" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModMulte.aspx.cs" Inherits="DFleet.Admin.Modules.Multa.ModMulte" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Multa</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Multa/ViewMulte")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


                 <div class="form-body panel-body form-horizontal">


      

                 <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Status</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                </div>

         <div class="row">
                    <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Pagamento *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlStatusPag" runat="server" DataSourceID="odsstatuspag" DataTextField="statuspagamento" 
                                    DataValueField="idstatuspagamento" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="-1" Text="Status Pagamento"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstatuspag" runat="server" SelectMethod="SelectAllStatusPagamento" TypeName="BusinessLogic.MulteBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                           </div>
                           </div>
                        </div> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Lavorazione *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlStatusLav" runat="server" DataSourceID="odsstatuslav" DataTextField="statuslavorazione" 
                                    DataValueField="idstatuslavorazione" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Status Lavorazione"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstatuslav" runat="server" SelectMethod="SelectAllStatusLavorazione" TypeName="BusinessLogic.MulteBL" >
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
                            <h3 class="box-title colorverded">Dati Generali</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
               </div>
                      <div class="row">
                       <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label  col-md-3">Numero Verbale *</label>
                                  <div class="col-md-9">
                                <asp:TextBox ID="txtNumeroVerbale" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Numero Verbale"></asp:TextBox> 
                             </div>
                           </div>
                        </div> 
                         
                  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Data Notifica</label>
                                 <div class="col-md-9">
                                <asp:TextBox ID="txtDataNotifica" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Notifica"></asp:TextBox> 
                                  </div>
                           </div>
                        </div> 
                    </div>

                      <div class="row">
                          <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Ente emittente</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtEnte" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Ente"></asp:TextBox> 
                             </div>
                           </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Codice fiscale Ente  </label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtCfemittente" runat="server" Columns="30" MaxLength="11" CssClass="form-control" placeholder="Codice fiscale emittente"></asp:TextBox> 
                              </div>
                           </div>
                        </div> 
                    </div>




                      <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Tipo Multa *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlCodTipoMulta" runat="server" DataSourceID="odstipomulta" DataTextField="tipomulta" 
                                    DataValueField="codtipomulta" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Tipo Multa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstipomulta" runat="server" SelectMethod="SelectAllTipoMulte" TypeName="BusinessLogic.MulteBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>  
                             </div>
                           </div>
                        </div>   
                          
                          
                          <div class="col-md-6">
                            <div class="form-group">
                              <label class="control-label col-md-3">File Verbale * (*.pdf)</label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="fuFileVerbale"  CssClass="form-control" runat="server" />
                                    <asp:HiddenField ID="hdFileVerbale" runat="server" />
                                    <asp:Label ID="lblViewFileVerbale" runat="server" Text=""></asp:Label>
                                </div>
                           </div>
                    </div>
                    </div>


         <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Protocollo *</label>

                                  <div class="col-md-9">
                         <asp:TextBox ID="txtProtocollo" runat="server" Columns="30" MaxLength="22" CssClass="form-control" placeholder="Protocollo"></asp:TextBox>  
                                 </div>
                              </div>  
                          </div> 
                             <div class="col-md-6">
                            <div class="form-group">
                              <label class="control-label col-md-3">Punti</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtPunti" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Punti" TextMode="Number"></asp:TextBox> 
                             </div>
                           </div>
                        </div> 
                    </div>



                       <div class="row">
                            <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Data Infrazione *</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtDataInfrazione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Infrazione"></asp:TextBox> 
                            </div>
                           </div>
                        </div>    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Ora Infrazione </label>   
                                <div class="col-md-9">
                                <asp:TextBox ID="txtOraInfrazione" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Ora Infrazione"></asp:TextBox>
                            </div>
                           </div>
                        </div> 
                    </div>


         <div class="row">
              
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Infrazione</label>
                                 <div class="col-md-9">
                                               <asp:TextBox ID="txtInfrazione" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Infrazione"></asp:TextBox> 
                             </div>
                           </div>
                        </div>
             
             <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Tipo Trasmissione *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlTipoTrasm" runat="server" DataSourceID="odstipotrasm" DataTextField="tipotrasmissione" 
                                    DataValueField="idtipotrasmissione" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Tipo Trasmissione"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstipotrasm" runat="server" SelectMethod="SelectAllTipoTrasmissioneMulte" TypeName="BusinessLogic.MulteBL" >
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
                            <h3 class="box-title colorverded">Dati Ricevente</h3>
                            <hr class="m-t-0 m-b-40">
                         </div>
                </div>
                         



      <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Targa *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlTarga" runat="server" DataSourceID="odstarga" DataTextField="targa" 
                                    DataValueField="targa" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Targa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstarga" runat="server" SelectMethod="SelectAllTargheExt" TypeName="BusinessLogic.MulteBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                           </div>
                           </div>
                        </div> 
                 <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Societ&agrave; </label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlCodSocieta" runat="server" DataSourceID="odscodsocieta" DataTextField="societa" 
                                    DataValueField="codsocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Societa"></asp:ListItem>
                                </asp:DropDownList>     
                                <asp:ObjectDataSource ID="odscodsocieta" runat="server" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                         </div>
                           </div>
                        </div>           


         <div class="row">
                     <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Driver *</label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                             </div>
                           </div>
                        </div>  
              

                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Titolare Pagamento </label>
                                <div class="col-md-9">
                                <asp:DropDownList ID="ddlTitolarePag" runat="server" DataSourceID="odstitolarepag" DataTextField="titolarepagamento" 
                                    DataValueField="idtitolarepagamento" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="-1" Text="Titolare Pagamento"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstitolarepag" runat="server" SelectMethod="SelectAllTitolarePagamento" TypeName="BusinessLogic.MulteBL" >
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
                            <h3 class="box-title colorverded">Dati pagamento</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

 
            <div class="row">  
                      
                 <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Importo scontato (1-5 gg)</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtImportoMultaScontato" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo Multa Scontato"></asp:TextBox> 
                           </div>
                           </div>
                        </div> 
                   <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Importo ridotto (6-60 gg)</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtImportoMultaRidotto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo Multa Ridotto"></asp:TextBox> 
                             </div>
                          </div>
                           </div>
                        </div> 


                    <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Importo intero (oltre 60 gg)</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtImportoMulta" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo Multa"></asp:TextBox> 
                           </div>
                           </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Spese Pagamento </label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtSpesePagamento" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Spese Pagamento"></asp:TextBox> 
                            </div>
                           </div>
                        </div> 
                    </div> 
                     

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Codice PagoPA</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCodPagoPa" runat="server" Columns="30" MaxLength="22" CssClass="form-control" placeholder="Codice PagoPA"></asp:TextBox> 
                                </div>
                            </div>
                        </div>                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Iban </label>
                                <div class="col-md-9">
                                     <asp:TextBox ID="txtIban" runat="server" Columns="30" MaxLength="27" CssClass="form-control" placeholder="Iban"></asp:TextBox> 
                                </div>
                           </div>
                        </div> 
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Codice PagoPA 60 gg</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCodPagoPa60" runat="server" Columns="30" MaxLength="22" CssClass="form-control" placeholder="Codice PagoPA 60 gg"></asp:TextBox> 
                                </div>
                            </div>
                        </div> 
                    </div>


                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati pagamento Effettuato</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">File Ricevuta Pagamento (*.pdf)</label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="fuFilePagamento"  CssClass="form-control" runat="server" />
                                    <asp:HiddenField ID="hdFilePagamento" runat="server" />
                                    <asp:Label ID="lblViewFilePagamento" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Data Pagamento </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtDataPagamento" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Pagamento"></asp:TextBox> 
                                </div>
                            </div>
                        </div> 
                    </div>
                     
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Importo Pagamento </label>                                
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlImportoPagamento" runat="server" DataSourceID="odsimporto" DataTextField="tipomulta" 
                                        DataValueField="importomulta" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" Text="Importo Pagamento"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsimporto" runat="server" SelectMethod="SelectAllImporto" TypeName="BusinessLogic.MulteBL" OldValuesParameterFormatString="original_{0}" >
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hduid" DbType="Guid" Name="Uid" PropertyName="Value" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource> 
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Tipo Pagamento </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodPagamento" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Tipo Pagamento"></asp:ListItem>
                                        <asp:ListItem Value="PagoPa" Text="">PagoPa</asp:ListItem>
                                        <asp:ListItem Value="Bonifico" Text="">Bonifico</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                     
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Conto di pagamento </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlContoPagamento" runat="server" DataSourceID="odscontopag" DataTextField="contopagamento" 
                                        DataValueField="idcontopagamento" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" Text="Conto pagamento"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscontopag" runat="server" SelectMethod="SelectAllContoPagamento" TypeName="BusinessLogic.MulteBL" >
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
                            <h3 class="box-title colorverded">Quote riferimento</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                     

                    <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Quota driver</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtQuotaDriver" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Quota driver"></asp:TextBox> 
                           </div>
                           </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Quota societ&agrave;</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtQuotaSocieta" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Quota societa"></asp:TextBox> 
                            </div>
                           </div>
                        </div> 
                    </div> 




                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">File ManLeva</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label ID="lblFileManLeva" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Annotazioni</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Note</label>
                                <div class="col-md-9">
                                <asp:TextBox ID="txtAnnotazioni" runat="server" Columns="30" Rows="3" CssClass="form-control" placeholder="Note" TextMode="MultiLine"></asp:TextBox> 
                           </div>
                           </div>
                        </div> 
                    </div> 

                </div>


                <hr class="text-verde"/>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function() {  
        $("#ContentBody_txtEnte").autocomplete({
            source: "../../../Handler/ListEnti.ashx"
        });  
        $("#ContentBody_txtInfrazione").autocomplete({
            source: "../../../Handler/ListInfrazioni.ashx"
        });          
    });  
</script>

</asp:Content>