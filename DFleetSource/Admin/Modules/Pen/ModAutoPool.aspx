<%@ Page Title="Modifica" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModAutoPool.aspx.cs" Inherits="DFleet.Admin.Modules.Pen.ModAutoPool" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Pen/AutoPool")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>
    
    <div class="white-box">
        <div class="row">          
            <div class="col-md-4"> 
                MARCA<br />
                <h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
                <h3 class="font-bold"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h3>
                Targa <br />
                <h4> <asp:Label ID="lblTarga" runat="server" Text=""></asp:Label> </h4>
                Societa <br />
                <h4><asp:Label ID="lblSocieta" runat="server" Text=""></asp:Label></h4> 
                CarPolicy <br />
                <h4><asp:Label ID="lblCodCarPolicy" runat="server" Text=""></asp:Label></h4> 
                Ex Driver <br />
                <h6><asp:Label ID="lblAssegnazioni" runat="server" Text=""></asp:Label></h6> 
            </div>                         
            <div class="col-md-4">
                Fornitore <br />
                <h4><asp:Label ID="lblFornitore" runat="server" Text=""></asp:Label></h4> 
                Fringebenefit <br />
                <h4><asp:Label ID="lblFringe" runat="server" Text=""></asp:Label></h4> 
                Percorrenza <br />
                <h4><asp:Label ID="lblPercorrenza" runat="server" Text=""></asp:Label></h4> 
                Km da contratto <br />
                <h4><asp:Label ID="lblKmContratto" runat="server" Text=""></asp:Label></h4> 
                Colore <br />
                <h4><asp:Label ID="lblColore" runat="server" Text=""></asp:Label></h4> 
                Assegnazione <br />
                <h4><asp:Label ID="lblCkAssegnazione" runat="server" Text="" CssClass="text-red"></asp:Label></h4> 
                In Riparazione <br />
                <h4><asp:Label ID="lblRiparazione" runat="server" Text=""></asp:Label></h4> 
            </div>                         
            <div class="col-md-4">
                Cambio <br />
                <h4><asp:Label ID="lblCambio" runat="server" Text=""></asp:Label></h4> 
                Citt&agrave; e centro di restituzione <br />
                <h4><asp:Label ID="lblCittaRestituzione" runat="server" Text=""></asp:Label></h4> 
                Canone leasing <br />
                <h4><asp:Label ID="lblCanone" runat="server" Text=""></asp:Label></h4> 
                Alimentazione <br />
                <h4><asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label></h4> 
                Emissioni <br />
                <h4><asp:Label ID="lblEmissione" runat="server" Text=""></asp:Label></h4> 
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Visualizzazioni ordini auto in pool</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">  
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Auto Visualizzabile da driver per prenotazione </label>                                       
                                NO <input type="checkbox" id="checkordinepool" class="js-switch" data-color="#13dafe" runat="server" /> SI<br /><br />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Grade per visualizzazione (se vuoto visibile da tutti)</label>
                                <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                    DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Grade"></asp:ListItem>
                                </asp:DropDownList> 
                                <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Visualizzazioni opzioni auto in pool</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">   
                        <div class="col-md-12">
                            <div class="col-md-3">
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
                                    <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
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
                </div>
                
                <div class="form-actions text-center">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div>

            </div>
        </div>
    </div>

</div>

</asp:Content>