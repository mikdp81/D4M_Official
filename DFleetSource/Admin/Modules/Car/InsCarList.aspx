<%@ Page Title="Inserimento Auto &amp; Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsCarList.aspx.cs" Inherits="DFleet.Admin.Modules.Car.InsCarList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Auto &amp; Optional</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/ViewCarList")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Car List *</label>
                                <div class="col-md-9">
                                    <asp:ListBox ID="ddlCarList" CssClass="select2 select2-multiple" SelectionMode="Multiple" multiple="multiple"
                                        runat="server" DataSourceID="odscarlist"  DataTextField="carlist" DataValueField="codcarlist" AppendDataBoundItems="True">
                                    </asp:ListBox>      
                                    <asp:ObjectDataSource ID="odscarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>                                
                                </div>
                            </div>
                        </div>    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Status </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlVisibile" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="ATTIVO">ATTIVO</asp:ListItem>
                                        <asp:ListItem Value="SOSPESO">SOSPESO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Modello</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Fornitore *</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodFornitore" runat="server" DataSourceID="odscodfornitore" DataTextField="fornitore" 
                                        DataValueField="codfornitore" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Fornitore"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscodfornitore" runat="server" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL" >
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>     
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Codjato Auto *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCodjatoAuto" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Codjato Auto"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Marca *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtMarca" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Marca"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Modello *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtModello" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Modello"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                    </div>  
                    <div class="row">  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Foto (.jpg, .png)</label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="fuFileFotoAuto"  CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>   
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Caratteristiche</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Cilindrata </label>                                
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCilindrata" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Cilindrata"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Cambio </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCambio" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="">Scegli Cambio</asp:ListItem>
                                        <asp:ListItem Value="Automatico">Automatico</asp:ListItem>
                                        <asp:ListItem Value="Manuale">Manuale</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Alimentazione</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtAlimentazione" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Alimentazione"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Alimentazione Secondaria</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtAlimentazioneSecondaria" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Alimentazione Secondaria"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Serbatoio</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtSerbatoio" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Serbatoio"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">KW/CV</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtKwcv" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="KW/CV"></asp:TextBox> 
                                </div>
                            </div>
                        </div>       
                    </div>  

                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Consumi ed emissioni</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Consumo Misto</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtConsumo" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Consumo Misto"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Consumo Urbano </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtConsumoUrbano" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Consumo Urbano"></asp:TextBox> 
                                </div>
                            </div>
                        </div>     
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Consumo Extra Urbano</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtConsumoExtraUrbano" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Consumo Extra Urbano"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Emissioni</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEmissioni" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Emissioni"></asp:TextBox> 
                                </div>
                            </div>
                        </div>     
                    </div> 


                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Importi</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Costo Auto Base</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCostoAutoBase" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo Auto Base"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Costo Aci (Bollo) </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCostoAci" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Costo Aci"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Canone Leasing</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCanoneLeasing" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Leasing"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Fringe benefit base</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtFringeBenefit" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Fringe benefit base"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Altro</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Giorni consegna</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtGiorni" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Giorni consegna"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Mesi Contratto</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtMesiContratto" runat="server" Columns="30" MaxLength="10" CssClass="form-control" placeholder="Mesi Contratto"></asp:TextBox> 
                                </div>
                            </div>
                        </div>     
                    </div>
                </div>
                <div class="form-action">
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva e nuovo" CssClass="btn btn-success" /> 
                    <asp:Button ID="btnInserisci2" runat="server" onclick="btnInserisci2_Click" Text="Salva e chiudi" CssClass="btn btn-success" /> 
                </div>
            </div> 
        </div>
    </div>
</div>


</asp:Content>