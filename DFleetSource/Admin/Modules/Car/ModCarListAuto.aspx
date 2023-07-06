<%@ Page Title="Modifica Auto &amp; Optional" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModCarListAuto.aspx.cs" Inherits="DFleet.Admin.Modules.Car.ModCarListAuto" %>
<%@ Import Namespace="System.Globalization" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Auto &amp; Optional</h3>
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
                                    <asp:DropDownList ID="ddlCodice" runat="server" DataSourceID="odscodcarlist" DataTextField="carlist" 
                                    DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="" Text="Car List"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscodcarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL" >
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
                             <div class="row">
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
                                    <asp:HiddenField ID="hdFileFotoAuto" runat="server" />
                                    <asp:Label ID="lblViewFileFotoAuto" runat="server" Text=""></asp:Label>
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
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>

    
    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title m-b-0">Fringe Benefit ACI</h3>
                        </div>        
                    </div> 
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvFringe" runat="server"
                                    AutoGenerateColumns="False" DataSourceID="odsFringe" CssClass="display nowrap dataTable" 
                                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">   
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>                    
                                    </asp:TemplateField>  
                    
                                    <asp:TemplateField HeaderText="Modello">
                                        <ItemTemplate>
                                            <%# Eval("marca")%> - <%# Eval("modello")%> <%# Eval("serie")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="COSTO KM 15.000">
                                        <ItemTemplate>
                                            <%# Eval("costokm")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                    
                                    <asp:TemplateField HeaderText="(25% CK)">
                                        <ItemTemplate>
                                            <%# Eval("fringe25")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>                     
                        
                                    <asp:TemplateField HeaderText="(30% CK)">
                                        <ItemTemplate>
                                            <%# Eval("fringe30")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="(50% CK)">
                                        <ItemTemplate>
                                            <%# Eval("fringe50")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="(60% CK)">
                                        <ItemTemplate>
                                            <%# Eval("fringe60")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="DAL">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("periododal")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="AL">
                                        <ItemTemplate>
                                            <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("periodoal")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>    
                                <PagerStyle HorizontalAlign="Right" />    
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsFringe" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectDetailFringeXCod" TypeName="BusinessLogic.FileTracciatiBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtCodjatoAuto" Name="codjatoauto" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource> 
                        </div>        
                    </div> 
                    <div class="row">
                        <div class="col-md-4">                              
                           <br /> <asp:DropDownList ID="ddlAbbinamento" runat="server" DataSourceID="odsabbinamentoauto" DataTextField="marca" 
                                DataValueField="idfringe" CssClass="form-control select2" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="" Text="Abbina Codice Auto"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsabbinamentoauto" runat="server" SelectMethod="SelectAutoXMarca" TypeName="BusinessLogic.FileTracciatiBL" OldValuesParameterFormatString="original_{0}" >
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtMarca" Name="marca" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>   
                            <asp:Label ID="lblAlertAbbinato" runat="server" Text="" CssClass="font-bold"></asp:Label><br /><br />
                            
                            <asp:Label ID="lblCalcoloFringe" runat="server" Text=""></asp:Label>
                        </div>        
                    </div>
                </div>
                <div class="form-action">
                    <br /><asp:Button ID="btnModifica4" runat="server" onclick="btnModifica4_Click" Text="Abbina" CssClass="btn btn-success" />
                </div> 
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <div class="form-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title m-b-0">Colore</h3>
                        </div>        
                    </div>
                    <div class="row">
                        <div class="col-md-12">                              
                            <asp:Literal ID="ltcolori" runat="server"></asp:Literal>
                        </div>        
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title m-b-0">Optional</h3>
                        </div>        
                    </div>
                    <div class="row">
                        <div class="col-md-12">                              
                            <asp:Literal ID="ltoptional" runat="server"></asp:Literal>
                        </div>        
                    </div>
                    <div class="row m-t-20" >
                        <div class="col-md-12"> 
                            <h4>Aggiungi optional/colore</h4>

                            <div class="row">
                                <div class="col-md-6">
                                    <input type="text" name="codoptional_0" id="codoptional_0" size="30" maxlength="255" value="" class="form-control optional" placeholder="Inserisci optional" /> 
                                    <input type="hidden" name="hiddencodoptional_0" id="hiddencodoptional_0" />
                                </div>
                                <div class="col-md-1">
                                    <select name="tipoimporto_0" class="form-control">
                                        <option value="0" selected="selected">di serie</option>
                                        <option value="1">non di serie</option>
                                    </select>
                                </div>                                
                                <div class="col-md-2">
                                    <input type="text" name="importo_0" size="10" maxlength="10" value="" class="form-control" placeholder="Canone mensile" />
                                </div>                                    
                                <div class="col-md-2">
                                    <input type="text" name="giorniconsegnaagg_0" size="10" maxlength="10" value="" class="form-control" placeholder="Giorni consegna aggiuntivi" /> 
                                </div>          
                                <div class="col-md-1">
                                    <img src="../../../plugins/images/icoadd.png" alt="" border="0" onclick="AddTextOptional('1')" style="cursor:pointer;" />
                                </div>
                            </div>


                            <%  for (int i = 1; i < 100; i++)
                                {
                            %>
                            <div id="block_optional_<%=i%>" class="m-t-20" style="display:none;">
                                <div class="row">
                                    <div class="col-md-6">
                                        <input type="text" name="codoptional_<%=i%>" id="codoptional_<%=i%>" size="30" maxlength="255" value="" class="form-control optional" placeholder="Inserisci optional" /> 
                                        <input type="hidden" name="hiddencodoptional_<%=i%>" id="hiddencodoptional_<%=i%>" />
                                    </div>
                                    <div class="col-md-1">
                                        <select name="tipoimporto_<%=i%>" class="form-control">
                                            <option value="0" selected="selected">di serie</option>
                                            <option value="1">non di serie</option>
                                        </select>
                                    </div>                                
                                    <div class="col-md-2">
                                        <input type="text" name="importo_<%=i%>" size="10" maxlength="10" value="" class="form-control" placeholder="Canone mensile" />   
                                    </div>                                 
                                    <div class="col-md-2">
                                        <input type="text" name="giorniconsegnaagg_<%=i%>" size="10" maxlength="10" value="" class="form-control" placeholder="Giorni consegna aggiuntivi" /> 
                                    </div>            
                                    <div class="col-md-1">
                                        <img src="../../../plugins/images/icoadd.png" alt="" border="0" onclick="AddTextOptional('<%=i+1%>')" style="cursor:pointer;" />
                                    </div>
                                </div>
                            </div>                                
                            <%
                                }
                            %>


                        </div>        
                    </div>
                </div>
                <div class="form-action">
                    <br /><asp:HiddenField ID="hdcount" runat="server" />
                    <asp:HiddenField ID="hdcountcolor" runat="server" />
                    <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                    <asp:Button ID="btnModifica3" runat="server" onclick="btnModifica3_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div>
        </div>
    </div>
</div>


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentScripts" runat="server">

<script type="text/javascript">  
    $(document).ready(function () {
        <%  for (int i = 0; i < 100; i++)
            {
        %>
        $("#codoptional_<%=i%>").autocomplete({
                source: "../../../Handler/ListOptional.ashx",
                select: function (event, ui) {
                    $("#codoptional_<%=i%>").val(ui.item.label);
                    $("#hiddencodoptional_<%=i%>").val(ui.item.value);
                    return false;
                }
            });
        <%
            }
        %>   
    });

    function AddTextOptional(count)
    {
        $("#block_optional_" + count).show();
    }

    function EliminaOpt(button) {
        var hiddenValue = $(button).next('input[type=hidden]').val();

        var verificadelete = $.ajax({
            async: false,
            url: "../../../Handler/DeleteOptionalAuto.ashx?value=" + hiddenValue,
            type: 'POST',
            dataType: 'html',
            timeout: 2000,
        }).responseText;

        if (verificadelete == "OK") {
            alert("Cancellazione avvenuta correttamente");
            location.href = 'EditCarListAuto-<%=Request.QueryString["uid"]%>';
        }
        else {
            alert("Cancellazione fallita.")
        }
    }
</script>

</asp:Content>