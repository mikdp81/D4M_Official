<%@ Page Title="Inserimento Utente" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="InsUserRobot.aspx.cs" Inherits="DFleet.Admin.Modules.Users.InsUserRobot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Inserimento Utente</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Users/InsUserRobotFull")%>" class="btn btn-info waves-effect waves-light m-t-10">Crea Tutti i Membership</a> 

                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ViewUsers")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 

                <a href="<%=ResolveUrl("~/Admin/Modules/Users/ModPwd")%>" class="btn btn-info waves-effect waves-light m-t-10">Modifica Password</a> 
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

                    <div class="white-box  m-l-20">

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Email *</label> 
                                    <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="255" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
     
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Ruolo *</label>                                
                                    <asp:DropDownList ID="ddlGruppo" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="odsGruppo"
                                        DataTextField="gruppouser" DataValueField="idgruppouser">
                                        <asp:ListItem Value="">Scegli Ruolo</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsGruppo" runat="server" DataObjectTypeName="BusinessObject.Account" 
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="SelectGruppi" TypeName="BusinessLogic.AccountBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="form-action">
                            <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Salva e nuovo" CssClass="btn btn-success" /> 
                        </div>
                    </div>

                </div>
   
            </div>
        </div>
    </div>
</div>

</asp:Content>
