<%@ Page Title="Riconsegna auto" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="EditRiconsegnaAuto.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.EditRiconsegnaAuto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Riconsegna auto</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewRiconsegnaAuto")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


                <div class="form-body">                    
                    <div class="vtabs">                        
                        <ul class="nav tabs-vertical">
                            <li class="tab active">
                                <a data-toggle="tab" href="#restituzione" aria-expanded="true" ><span class="hidden-xs active svg-icon-30L svg-icon-profilo p-l-30 ">Restituzione</span> </a>
                            </li>
                            <li class="tab">
                                <a data-toggle="tab" href="#contratto" aria-expanded="false"> <span class="hidden-xs  svg-icon-30L svg-icon-lavoro p-l-30">Contratto</span> </a>
                            </li>
                            <li class="tab">
                                <a aria-expanded="false" data-toggle="tab" href="#documentazione">  <span class="hidden-xs svg-icon-30L svg-icon-dots p-l-30">Documentazione Driver</span> </a>
                            </li>
                        </ul>

                        <div class="white-box  m-l-20">
                            <div class="tab-content">
                                <div id="restituzione" class="tab-pane active">
                                    <div class="row"> 
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Status Assegnazione</label>                                                
                                                <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statusassegnazione" 
                                                    DataValueField="idstatusassegnazione" CssClass="form-control select2" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="-1" Text="Status"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusContrattoAss" TypeName="BusinessLogic.ContrattiBL">
                                                    <SelectParameters>
                                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                                        </div> 
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Status Auto</label>                                                
                                                <asp:DropDownList ID="ddlstatusauto" runat="server" DataSourceID="odsstatusauto" DataTextField="statoauto" 
                                                    DataValueField="idstatoauto" CssClass="form-control select2" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="0" Text="Status"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsstatusauto" runat="server" SelectMethod="SelectStatusAuto" TypeName="BusinessLogic.ContrattiBL">
                                                    <SelectParameters>
                                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                                        </div>       
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Citt&agrave; Restituzione </label>
                                                <asp:DropDownList ID="ddlCittaRestituzione" runat="server" DataSourceID="odsscittarest" DataTextField="citta" 
                                                    DataValueField="citta" CssClass="form-control select2 ddlCittaRest" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="" Text=""></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsscittarest" runat="server" SelectMethod="SelectAllCittaCentri" TypeName="BusinessLogic.UtilitysBL" >
                                                    <SelectParameters>
                                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                                        </div>   
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Centro Restituzione </label>
                                                <asp:DropDownList ID="ddlCentroRestituzione" runat="server" DataSourceID="odsscentrorest" DataTextField="centro" 
                                                    DataValueField="centro" CssClass="form-control select2 ddlCentroRest" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="" Text=""></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsscentrorest" runat="server" SelectMethod="SelectAllCentri" TypeName="BusinessLogic.UtilitysBL" >
                                                    <SelectParameters>
                                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                                        </div>                                      
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Data Restituzione</label>
                                                <asp:TextBox ID="txtDataRestituzione" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Restituzione"></asp:TextBox> 
                                            </div>
                                        </div>     
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="control-label">Ora Restituzione</label>
                                                <asp:TextBox ID="txtOraRestituzione" runat="server" Columns="20" MaxLength="20" CssClass="form-control" placeholder="Ora Restituzione"></asp:TextBox> 
                                            </div>
                                        </div>    
                                    </div>                                    
                                    <div class="row"> 
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Annotazioni</label>
                                                <asp:TextBox ID="txtAnnotazionicontratto" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row"> 
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="hdcodsocieta" runat="server" />
                                            <asp:HiddenField ID="hduid" runat="server" />
                                            <asp:HiddenField ID="hdidass" runat="server" />
                                            <asp:HiddenField ID="hdassegnatoal" runat="server" />
                                            <asp:HiddenField ID="hdtarga" runat="server" />
                                            <asp:HiddenField ID="hdidcontratto" runat="server" />
                                            <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                                        </div>
                                    </div>
                                </div>

    

                                <div id="contratto" class="tab-pane">
                                    <div class="row"> 
                                        <div class="col-md-12">
                                            <h4>Contratto:</h4>                                            
                                            <asp:Label ID="lblAuto" runat="server" CssClass="font-bold" Text="" /><br /><br />
                                            <asp:Label ID="lblDatiDriver" runat="server" Text="" /><br /><br />
                                            <asp:Label ID="lblDatiOrdine" runat="server" Text="" />
                                        </div>                        
                                    </div>
                                </div>

                                

                                <div id="documentazione" class="tab-pane">
                                    <div class="row"> 
                                        <div class="col-12">
                                            <h4>Documentazione Driver:</h4>

                                            File verbale consegna: <asp:Label ID="lblviewfileverbale" runat="server" Text=""></asp:Label><br />
                                            File relazione perito: <asp:Label ID="lblviewfilerelazione" runat="server" Text=""></asp:Label><br />
                                            File denunce: <asp:Label ID="lblviewfiledenunce" runat="server" Text=""></asp:Label><br /><br />
                                            
                                            Tipo gomme: <asp:Label ID="lbltipogomme" runat="server" Text=""></asp:Label><br />
                                            Luogo gomme: <asp:Label ID="lblluogogomme" runat="server" Text=""></asp:Label><br />
                                            Data ultimo cambio gomme: <asp:Label ID="lbldatacambiogomme" runat="server" Text=""></asp:Label><br />
                                            Km restituzione: <asp:Label ID="lblkmrestituzione" runat="server" Text=""></asp:Label><br /><br />

                                            Note Driver: <asp:Label ID="lblnotedriver" runat="server" Text=""></asp:Label><br /><br />
                                            
                                            <asp:Label ID="lblcontrollata" runat="server" Text="" CssClass="font-bold"></asp:Label>
                                            <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Conferma Controllo" CssClass="btn btn-success" />
                                        </div>                        
                                    </div>
                                </div>

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

        $(".ddlCittaRest").change(function () {
            var citta = $(this).val();

            $.ajax({
                type: "POST",
                url: "../../../Handler/ListCentriXCitta.ashx?citta=" + citta,
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
        listItems += "<option value=''></option>";
        jQuery(checkboxlistItems).each(function () {
            listItems += "<option value='" + this.id + "'>" + this.name + "</option>";
        });
        jQuery("#ContentBody_ddlCentroRestituzione").html(listItems);
    }

</script>

</asp:Content>