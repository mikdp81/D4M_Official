<%@ Page Title="Inserimento Voltura" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsVoltura.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsVoltura" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Voltura</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewVolture")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnlStep1" runat="server">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-12">                            
                                <asp:Button ID="btnModo1" runat="server" onclick="btnModo1_Click" Text="Variazione contratto infragruppo" CssClass="btn btn-success" />
                                <asp:Button ID="btnModo2" runat="server" onclick="btnModo2_Click" Text="Voltura in entrata da esterno" CssClass="btn btn-success" />
                                <asp:Button ID="btnModo3" runat="server" onclick="btnModo3_Click" Text="Voltura in uscita da esterno" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                
                <asp:Panel ID="pnlModo1" runat="server">
                    <div class="form-body">
                        <div class="row">                        
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Contratto *</label>
                                    <asp:DropDownList ID="ddlContratto" runat="server" DataSourceID="odscontratto" DataTextField="Codjatoauto" 
                                        DataValueField="Uid" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Scegli Contratto"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscontratto" runat="server" SelectMethod="SelectContrattiXVolture" TypeName="BusinessLogic.ContrattiBL" >
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>                         
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Societ&agrave; *</label>
                                    <asp:DropDownList ID="ddlCodSocieta2" runat="server" DataSourceID="odssocieta" DataTextField="codsocieta" 
                                        DataValueField="codsocieta" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Scegli Societa"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>    
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Numero Contratto *</label>
                                    <asp:TextBox ID="txtNumeroContratto2" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Contratto"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data inizio contratto *</label>
                                    <asp:TextBox ID="txtDatainiziouso2" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio contratto"></asp:TextBox> 
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-action">
                        <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci1_Click" Text="Salva" CssClass="btn btn-success" /> 
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlModo2" runat="server">
                    <div class="form-body">
                        <div class="row">                        
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Societ&agrave; *</label>
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
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Utente *</label>
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
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codjato Auto *</label>
                                    <asp:TextBox ID="txtCodjatoAuto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codjato Auto"></asp:TextBox> 
                                </div>
                            </div>    
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Targa *</label>
                                    <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                                </div>
                            </div>   
                        </div>  
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Car Policy</label>
                                    <asp:TextBox ID="txtCodcarpolicy" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codice Car Policy"></asp:TextBox> 
                                </div>
                            </div>  
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Car List</label>
                                    <asp:TextBox ID="txtCodcarlist" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Codice Car List"></asp:TextBox> 
                                </div>
                            </div>   
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Fornitore *</label>                                
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
                                    <label class="control-label">Codice Tipo contratto</label>
                                    <asp:TextBox ID="txtCodtipocontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Codice Tipo contratto"></asp:TextBox> 
                                </div>
                            </div>    
                        </div>  
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Codice Tipo uso contratto</label>
                                    <asp:TextBox ID="txtCodtipousocontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Codice tipo uso contratto"></asp:TextBox> 
                                </div>
                            </div>  
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Numero Ordine </label>
                                    <asp:TextBox ID="txtNumeroOrdine" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine"></asp:TextBox> 
                                </div>
                            </div>   
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Numero Contratto *</label>
                                    <asp:TextBox ID="txtNumeroContratto" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Contratto"></asp:TextBox> 
                                </div>
                            </div>     
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data Contratto</label>
                                    <asp:TextBox ID="txtDataContratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Contratto"></asp:TextBox> 
                                </div>
                            </div>      
                        </div> 
                        <div class="row"> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Durata Mesi</label>
                                    <asp:TextBox ID="txtDurataMesi" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Durata Mesi" TextMode="Number"></asp:TextBox> 
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Km Contratto</label>
                                    <asp:TextBox ID="txtKmContratto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Km Contratto" TextMode="Number"></asp:TextBox> 
                                </div>
                            </div>   
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label">Franchigia </label>
                                    <asp:TextBox ID="txtFranchigia" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Franchigia"></asp:TextBox> 
                                </div>
                            </div>     
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label">Data inizio contratto</label>
                                    <asp:TextBox ID="txtDatainiziocontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio contratto"></asp:TextBox> 
                                </div>
                            </div> 
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label">File Contratto * (sono accettati solo i file .pdf)</label>
                                    <asp:FileUpload ID="fuFileContratto"  CssClass="form-control" runat="server" />
                                </div>
                            </div>      
                        </div>
                        <div class="row"> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data inizio uso</label>
                                    <asp:TextBox ID="txtDatainiziouso" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data inizio uso"></asp:TextBox> 
                                </div>
                            </div>    
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data fine contratto</label>
                                    <asp:TextBox ID="txtDatafinecontratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine contratto"></asp:TextBox> 
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
                                    <label class="control-label">Canone leasing</label>
                                    <asp:TextBox ID="txtCanoneleasing" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone leasing"></asp:TextBox> 
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
                            <div class="col-md-2">
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
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Scadenza Bollo</label>
                                    <asp:TextBox ID="txtScadenzaBollo" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza Bollo"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Scadenza Super Bollo</label>
                                    <asp:TextBox ID="txtScadenzaSuperBollo" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Scadenza Super Bollo"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-action">
                        <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva" CssClass="btn btn-success" /> 
                    </div>
                </asp:Panel>


            
                
                <asp:Panel ID="pnlModo3" runat="server">
                    <div class="form-body">
                        <div class="row">                           
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Contratto *</label>
                                    <asp:DropDownList ID="ddlContratto2" runat="server" DataSourceID="odscontratto" DataTextField="Codjatoauto" 
                                        DataValueField="Uid" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Scegli Contratto"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Data fine contratto *</label>
                                    <asp:TextBox ID="txtDatafinecontratto2" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine contratto"></asp:TextBox> 
                                </div>
                            </div>  
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Annotazioni voltura *</label>
                                    <asp:TextBox ID="txtAnnotazioniVoltura" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni contratto" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-action">
                        <asp:Button ID="btnInserisci3" runat="server" onclick="btnInserisci3_Click" Text="Salva" CssClass="btn btn-success" /> 
                    </div>
                </asp:Panel>
            

            </div> 
        </div>
    </div>
</div>


</asp:Content>