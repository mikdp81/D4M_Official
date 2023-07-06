<%@ Page Title="Ritiro Auto Assegnata" EnableEventValidation="false" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsRiconsegna.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.InsRiconsegna" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Ritiro Auto Assegnata</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/Assegnazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>			
        </div>
    </div>
    
    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                Targa<br />
                <h4><asp:Label ID="lblTarga" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
                <h4><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h4>
                Driver <br />
                <h4> <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label></h4>
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Citt&agrave; Restituzione </label>
                                <asp:DropDownList ID="ddlCittaRestituzione" runat="server" DataSourceID="odsscittarest" DataTextField="citta" 
                                    DataValueField="citta" CssClass="form-control ddlCittaRest" AppendDataBoundItems="True">
                                    <asp:ListItem Value="">-Seleziona-</asp:ListItem>
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
                                    DataValueField="centro" CssClass="form-control ddlCentroRest" AppendDataBoundItems="True">
                                    <asp:ListItem Value="">-Seleziona-</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsscentrorest" runat="server" SelectMethod="SelectAllCentri" TypeName="BusinessLogic.UtilitysBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div> 
                    </div>    
                    <div class="row">                                      
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Errata Sede Restituzione</label>
                                <asp:DropDownList ID="ddlErrataSedeRestituzione" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="NO">NO</asp:ListItem>
                                    <asp:ListItem Value="SI">SI</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>                            
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Penale cambio gomme</label>
                                <asp:DropDownList ID="ddlErrataRestituzioneGomme" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="NO">NO</asp:ListItem>
                                    <asp:ListItem Value="SI">SI</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>                            
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Penale mancata denuncia sinistro/danno</label>
                                <asp:DropDownList ID="ddlPenaleDenuncia" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="NO">NO</asp:ListItem>
                                    <asp:ListItem Value="SI">SI</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row"> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Annotazioni Restituzione</label>
                                <asp:TextBox ID="txtAnnotazioniRestituzione" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hdidass" runat="server" />
                    <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva" CssClass="btn btn-success" /> 
                    <asp:Button ID="btnMail" runat="server" onclick="btnMail_Click" Text="Invio Mail" CssClass="btn btn-success" />
                </div>
            </div> 
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">   
                <asp:Label ID="lblDati" runat="server" Text=""></asp:Label> 
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
                success: AjaxSucceeded,
                error: AjaxFailed
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