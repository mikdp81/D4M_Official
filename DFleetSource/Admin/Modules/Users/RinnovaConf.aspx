<%@ Page Title="Modifica Autorizzazioni" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="RinnovaConf.aspx.cs" Inherits="DFleet.Admin.Modules.Users.RinnovaConf" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Autorizzazioni</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewUsers")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                    <asp:HiddenField ID="hdidutente" runat="server" />
                    <asp:HiddenField ID="hdcodsocieta" runat="server" />
                    <asp:HiddenField ID="hdidappr" runat="server" />
                    <asp:HiddenField ID="hddataappr" runat="server" />
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:HiddenField ID="hdiduser" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Approva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Invia Mail" CssClass="btn btn-success" />
                </div>
            </div>

        </div>
    </div>
</div>


</asp:Content>