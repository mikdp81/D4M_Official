<%@ Page Title="Modifica Autorizzazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModAutorizzazioni.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.ModAutorizzazioni" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Autorizzazioni</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/Autorizzazioni")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblDati" Text=""></asp:Label><br /><br />
                        </div>
                   
                        <div class="col-md-6">                            
                            <label class="control-label">Ha diritto alla preassegnazione auto? * </label>  <br />
                            NO <input type="checkbox" id="preassegnazione" class="js-switch" data-color="#13dafe" runat="server" /> SI<br /><br />
                  
                            <label class="control-label">CarPolicy da attribuire *</label>
                                <asp:RadioButtonList ID="rbCarPolicy" runat="server" DataSourceID="odsCarPolicy" 
                                    DataTextField="excodcarpolicy" DataValueField="codcarpolicy"></asp:RadioButtonList> 
                                <asp:ObjectDataSource ID="odsCarPolicy" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectCarPolicy" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> <br /><br />

                                <label class="control-label">Data inizio configurazione * (suggerita <asp:Label ID="lblDataSuggerita" runat="server" Text=""></asp:Label>) </label>  <br />                                
                                <asp:TextBox ID="txtDataDecorrenza" runat="server" Columns="10" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox> 

                             <br /> <br /> 

                            </div>

                    </div>
                   
                </div>

                <div class="form-actions text-right">
                    <asp:HiddenField ID="hdidutente" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:HiddenField ID="hdcodsocieta" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Approva/Aggiorna" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Invia Mail" CssClass="btn btn-success" />
                </div>
            </div>

        </div>
    </div>
</div>


</asp:Content>