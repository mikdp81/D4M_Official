<%@ Page Title="Inserimento Penale" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsPenale.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsPenale" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Penale</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewPenali")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Fornitore *</label>                                
                                        <asp:DropDownList ID="ddlFornitore" runat="server" CssClass="form-control select2" AppendDataBoundItems="True"
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
                                        <label class="control-label">Numero Fattura</label>
                                        <asp:TextBox ID="txtNumeroFattura" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Fattura"></asp:TextBox> 
                                    </div>
                                </div>     
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Data Fattura</label>
                                        <asp:TextBox ID="txtDataFattura" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Fattura"></asp:TextBox> 
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Importo</label>
                                        <asp:TextBox ID="txtImporto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                            
                        <div class="row">   
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">File Penale (*.pdf)</label>
                                        <asp:FileUpload ID="fuFilePenale"  CssClass="form-control" runat="server" />
                                    </div>
                                </div> 
                                 
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Tipo Penale *</label>                                 
                                        <asp:DropDownList ID="ddltipopenaleauto" runat="server" DataSourceID="odstipopenaleauto" DataTextField="tipopenaleauto" 
                                            DataValueField="idtipopenaleauto" CssClass="form-control select2" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Tipo Penale"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odstipopenaleauto" runat="server" SelectMethod="SelectAllTipoPenaleAuto" TypeName="BusinessLogic.ContrattiBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Targa *</label>
                                    <asp:TextBox ID="txtTarga" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Targa"></asp:TextBox> 
                                </div>
                            </div> 
                        </div> 
                    </div>
                </div>

                <!-- Partner-->
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Partner</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">   
                        <div class="col-md-12">  
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Partner *</label>
                                    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control select2" AppendDataBoundItems="True"
                                        DataSourceID="odsusers" DataTextField="cognome" DataValueField="UserId">
                                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsersPartner" TypeName="BusinessLogic.AccountBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
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