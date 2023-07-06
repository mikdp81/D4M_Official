<%@ Page Title="Modifica Car Policy" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModCarPolicy.aspx.cs" Inherits="DFleet.Admin.Modules.Car.ModCarPolicy" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Car Policy</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Car/ViewCarPolicy")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label col-md-3">Car Policy *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtCarPolicy" runat="server" Columns="30" MaxLength="50" CssClass="form-control" placeholder="Car Policy"></asp:TextBox> 
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Ex Car Policy *</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlExCarPolicy" runat="server" DataSourceID="odsexcarpolicy" DataTextField="excodcarpolicy" 
                                        DataValueField="excodcarpolicy" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Ex Car Policy"></asp:ListItem>
                                    </asp:DropDownList>     
                                    <asp:ObjectDataSource ID="odsexcarpolicy" runat="server" SelectMethod="SelectExCarPolicy" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Specifiche</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Societ&agrave; </label>     
                                <div class="col-md-9">                           
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Car List *</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodCarList" runat="server" DataSourceID="odscarlist" DataTextField="carlist" 
                                        DataValueField="codcarlist" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Car List"></asp:ListItem>
                                    </asp:DropDownList>     
                                    <asp:ObjectDataSource ID="odscarlist" runat="server" SelectMethod="SelectAllCarList" TypeName="BusinessLogic.CarsBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>  
                    </div>
                    <div class="row">    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Grade </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                        DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Grade"></asp:ListItem>
                                    </asp:DropDownList> 
                                    <asp:ObjectDataSource ID="odscodgrade" runat="server" SelectMethod="SelectAllGrade" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource> 
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Sub Grade </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodSubGrade" runat="server" DataSourceID="odscodgrade" DataTextField="grade" 
                                     DataValueField="codgrade" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Sub Grade"></asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                            </div>
                        </div>  
                    </div>
                    <div class="row">                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Person Type </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCodPersonType" runat="server" DataSourceID="odscodpersontype" DataTextField="persontype" 
                                        DataValueField="codpersontype" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Person Type"></asp:ListItem>
                                    </asp:DropDownList>     
                                    <asp:ObjectDataSource ID="odscodpersontype" runat="server" SelectMethod="SelectAllPersonType" TypeName="BusinessLogic.UtilitysBL">
                                    </asp:ObjectDataSource> 
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Fuel Card *</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlFuelCard" runat="server" DataSourceID="odsfuelcard" DataTextField="fuelcard" 
                                        DataValueField="codfuelcard" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Value="" Text="Fuel Card"></asp:ListItem>
                                    </asp:DropDownList>     
                                    <asp:ObjectDataSource ID="odsfuelcard" runat="server" SelectMethod="SelectAllFuelCard" TypeName="BusinessLogic.UtilitysBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource> 
                                </div>
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">Validit&agrave;</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">DAL </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtValidoDal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Valido DAL"></asp:TextBox>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">AL </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtValidoAl" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Valido AL"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">Optional a Pagamento NON Visibili </label>
                                <div class="col-md-9">                                    
                                    NO <input type="checkbox" id="checkoptionalpag" class="js-switch" data-color="#13dafe" runat="server" /> SI<br /><br />
                                </div>
                            </div>
                        </div> 
                    </div>
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:HiddenField ID="hduidsocieta" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>