<%@ Page Title="Modifica Avviso" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModAvvisi.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModAvvisi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Avviso</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewAvvisi")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Codice Societ&agrave; </label>     
                                <asp:DropDownList ID="ddlCodSocieta" runat="server" CssClass="form-control select2" AppendDataBoundItems="True" DataSourceID="odsSoc"
                                    DataTextField="societa" DataValueField="codsocieta">
                                    <asp:ListItem Selected="True" Value="" Text="Societa"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSoc" runat="server" DataObjectTypeName="BusinessObject.Utilitys" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllSocieta" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Grade </label>
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">CarPolicy </label> 
                                <asp:DropDownList ID="ddlCodCarPolicy" runat="server" DataSourceID="odscodcarpolicy" DataTextField="codcarpolicy" 
                                    DataValueField="codcarpolicy" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="CarPolicy"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscodcarpolicy" runat="server" SelectMethod="SelectAllCarPolicy" TypeName="BusinessLogic.CarsBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div>   
                    </div>           
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Avviso *</label>
                                <asp:TextBox ID="txtTestoAvviso" runat="server" Columns="30" Rows="5" CssClass="form-control" placeholder="Documento" TextMode="Multiline"></asp:TextBox>
                            </div>
                        </div>    
                    </div>  
                    <div class="row"> 
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Visibile Dal *</label>
                                <asp:TextBox ID="txtVisibileDal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Visibile Dal"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">Visibile Al *</label>
                                <asp:TextBox ID="txtVisibileAl" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Visibile Al"></asp:TextBox> 
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