<%@ Page Title="Modifica Penale" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModPenale.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModPenale" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Penale</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewPenali")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label">Societ&agrave; *</label>
                                <asp:DropDownList ID="ddlCodsocieta" runat="server" DataSourceID="odssocieta" DataTextField="societa" 
                                    DataValueField="codsocieta" CssClass="form-control ddlSocieta" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Societa"></asp:ListItem>
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
                                <label class="control-label">Grade *</label>
                                <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                    DataValueField="codgrade" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Value="" Text="Grade"></asp:ListItem>
                                </asp:DropDownList> 
                                <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Importo *</label>
                                <asp:TextBox ID="txtImporto" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Importo"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Tipo *</label>
                                <asp:DropDownList ID="ddlTipo" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                        data-toggle="tooltip" data-placement="top" data-original-title="Tipo">
                                    <asp:ListItem Value="">Tipo</asp:ListItem>
                                    <asp:ListItem Value="Cessazione">Cessazione</asp:ListItem>
                                </asp:DropDownList>
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