<%@ Page Title="Report" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="DFleet.Admin.Modules.Dash.Report" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Report</h3>
            </div>		
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <div class="form-body">
                    <div class="form-group row marginbottmnull">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlReport" runat="server" DataSourceID="odsReport" AutoPostBack="True"
                                    DataTextField="nomereport" DataValueField="idreport" CssClass="form-control" AppendDataBoundItems="True"
                                    data-toggle="tooltip" data-placement="top" data-original-title="Scegli il report" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="">Scegli il report</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsReport" runat="server" OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="SelectAllReport" TypeName="BusinessLogic.UtilitysBL">
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3" id="codsocieta" runat="server">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCodSocieta" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsSoc"
                                    DataTextField="societa" DataValueField="codsocieta">
                                    <asp:ListItem Value="" Selected="True">Scegli Societa</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSoc" runat="server" DataObjectTypeName="BusinessObject.Utilitys" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3" id="codgrade" runat="server">
                            <div class="form-group">                                       
                                <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                    DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Grade"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div>
                        <div class="col-md-3" id="codfornitore" runat="server">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCodFornitore" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsFornitori"
                                    DataTextField="fornitore" DataValueField="codfornitore">
                                    <asp:ListItem Value="" Selected="True">Scegli Fornitore</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsFornitori" runat="server" DataObjectTypeName="BusinessObject.Utilitys" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllFornitori" TypeName="BusinessLogic.UtilitysBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                            </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-3" id="driver" runat="server">
                            <div class="form-group">                                      
                                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="odsusers" DataTextField="cognome" 
                                    DataValueField="UserId" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="Utente"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsusers" runat="server" SelectMethod="SelectUsers" TypeName="BusinessLogic.AccountBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group marginbottmnull">
                                        <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra ed esporta Excel" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div> 
        </div>

        <div class="row">
            <div class="col-12">
                <!-- Visualizzazione Errori -->
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div> 
        </div>

    </div>
</div>

</asp:Content>