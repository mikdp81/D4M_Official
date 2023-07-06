<%@ Page Title="Modifica Ordine" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ModOrdini" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Ordine <asp:Label ID="lblnumordine" runat="server" Text=""></asp:Label></h3>
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

                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati Generali</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>

                    <div class="row">     
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data Ordine</label>
                                <asp:TextBox ID="txtDataOrdine" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Ordine"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Status ordine *</label>
                                <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statusordine" 
                                    DataValueField="idstatusordine" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="-1" Text="Status Ordine"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusOrdine" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Fornitore *</label>                                
                                <asp:DropDownList ID="ddlCodFornitore" runat="server" DataSourceID="odsfornitore" DataTextField="fornitore" 
                                    DataValueField="codfornitore" CssClass="form-control select2 ddlFornitore" AppendDataBoundItems="True">
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
                                <label class="control-label">Numero Ordine Fornitore</label>
                                <asp:TextBox ID="txtNumOrdineFornitore" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Numero Ordine Fornitore"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Documenti</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Offerta Renter (*.pdf)</label>
                                <asp:FileUpload ID="fuFileOffertaRenter"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileOffertaRenter" runat="server" />
                                <asp:Label ID="lblViewFileOffertaRenter" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Offerta Firmata (*.pdf)</label>
                                <asp:FileUpload ID="fuFileOffertaFirmata"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileOffertaFirmata" runat="server" />
                                <asp:Label ID="lblViewFileOffertaFirmata" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>



                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Dati Richiedente</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Societ&agrave; *</label>
                                <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                    DataValueField="codsocieta" CssClass="form-control select2 ddlSocieta" AppendDataBoundItems="True">
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
                                <label class="control-label">Driver *</label>
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control select2 ddlUtente" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" AppendDataBoundItems="True">
                                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
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
                                <label class="control-label">Car Policy</label>                             
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Sede Consegna</label>
                                <asp:TextBox ID="txtSedeConsegna" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Sede Consegna"></asp:TextBox> 
                            </div>
                        </div>
                    </div>  


                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Dati Auto</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>

                           <div class="row">
                               <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Modello Auto *</label>
                                        <asp:DropDownList ID="ddlCodjatoAuto" runat="server" CssClass="form-control select2 ddlAuto" AppendDataBoundItems="True"
                                            DataSourceID="odsauto" DataTextField="modello" DataValueField="Uid">
                                            <asp:ListItem Value="" Text="Auto"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsauto" runat="server" SelectMethod="SelectAllAuto" TypeName="BusinessLogic.CarsBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource> 
                                    </div>
                                </div>                     
                                <div class="col-md-3">
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Alimentazione</label>
                                        <asp:TextBox ID="txtAlimentazione" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Alimentazione"></asp:TextBox> 
                                    </div>
                                </div>   
                            </div>
                    
                    
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Dati Canone</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                    
                           <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Canone Leasing Offerta</label>
                                        <asp:TextBox ID="txtCanoneLeasingOfferta" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Leasing"></asp:TextBox> 
                                    </div>
                                </div>    
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Canone Leasing Base (gara)</label>
                                        <asp:TextBox ID="txtCanoneLeasing" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Canone Leasing"></asp:TextBox> 
                                    </div>
                                </div>    
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label class="control-label">Optional Canone</label>
                                        <asp:TextBox ID="txtOptionalCanone" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Optional Canone"></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                    
                    
                        <div class="row">
                            <div class="col-md-12">
                                <h3 class="box-title colorverded">Data consegna</h3>
                                <hr class="m-t-0 m-b-40">
                            </div>
                        </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data consegna prevista</label>
                                <asp:TextBox ID="txtDataConsegnaPrevista" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data consegna prevista"></asp:TextBox>
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Annotazioni ordine</label>
                                <asp:TextBox ID="txtAnnotazioniordine" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni ordine" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>
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
        $("#buttonnewcar").click(function () {
            $("#blocknewcar").toggle();
        });   


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
        });   

        $(".ddlFornitore").change(function () {
            var codfornitore = $(this).val();

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListAutoXFornitore.ashx?codfornitore=" + codfornitore,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded2,
                error: AjaxFailed2
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
        listItems += "<option value=''>Auto</option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCodjatoAuto").html(listItems);
    }

</script>

</asp:Content>