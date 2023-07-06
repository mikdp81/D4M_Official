<%@ Page Title="Configurazioni Massive" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsConfMassiva.aspx.cs" Inherits="DFleet.Admin.Modules.Users.InsConfMassiva" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Configurazioni Massive</h3>
            </div>			
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                
                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


                
                <!-- STEP 1 - SCELTA SOCIETA -->
                <asp:Panel ID="pnlStep1" runat="server">
                    <div class="form-body">
                        <div class="row">                   
                            <div class="col-md-3">       
                                <label class="control-label">Seleziona la societ&agrave; *</label>       
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
                    <div class="form-actions text-right">
                        <asp:Button ID="btnProsegui" runat="server" onclick="btnProsegui_Click" Text="Prosegui" CssClass="btn btn-success" />
                    </div>
                </asp:Panel>

                
                
                <!-- STEP 2 - SCELTA CAR POLICY - INVIO MAIL MASSIVO -->
                <asp:Panel ID="pnlStep2" runat="server">
                    <div class="form-body">
                        <div class="row">            
                            <div class="col-md-6"> 
                                <label class="control-label">Inserisci matricole  *</label>  <br />    
                                <asp:TextBox ID="txtMatricole" runat="server" Columns="50" Rows="10" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>                                 
                            </div>
                            <div class="col-md-3">                            
                                <label class="control-label">Seleziona una policy auto *</label>
                                <asp:RadioButtonList ID="rbCarPolicy" runat="server" DataSourceID="odsCarPolicy" 
                                    DataTextField="codcarpolicy" DataValueField="codcarpolicy"></asp:RadioButtonList> 
                                <asp:ObjectDataSource ID="odsCarPolicy" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectCarPolicy" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdcodsocieta" Name="codsocieta" PropertyName="Value" Type="String" />
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="UidTenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> <br /><br />

                                <label class="control-label">Data di decorrenza  *</label>  <br />                                
                                <asp:TextBox ID="txtDataDecorrenza" runat="server" Columns="10" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox> 
                                <br /><br />

                                <label class="control-label">Data fine decorrenza  *</label>  <br />                                
                                <asp:TextBox ID="txtDataFineDecorrenza" runat="server" Columns="10" MaxLength="10" CssClass="form-control datePicker"></asp:TextBox> 

                                <br /> <br />
                            </div>

                            <div class="col-md-3">  
                                <label class="control-label">Seleziona un benefit alternativo *</label>
                                <asp:RadioButtonList ID="rbCarBenefit" runat="server" DataSourceID="odsCarBenefit" 
                                    DataTextField="carbenefit" DataValueField="codcarbenefit"></asp:RadioButtonList> 
                                <asp:ObjectDataSource ID="odsCarBenefit" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectCarBenefit" TypeName="BusinessLogic.ContrattiBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>                   
                    </div>

                    <div class="form-actions text-right">
                        <asp:HiddenField ID="hdcodsocieta" runat="server" />
                        <asp:Button ID="btnIndietro" runat="server" onclick="btnIndietro_Click" Text="Indietro" CssClass="btn btn-success" />
                        <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Invia" CssClass="btn btn-success" />
                    </div>
                
                </asp:Panel>

            </div>

        </div>
    </div>
</div>


</asp:Content>