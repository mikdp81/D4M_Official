<%@ Page Title="Modifica FAQ" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModFAQ.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.ModFAQ" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica FAQ</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Utility/ViewFAQ")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <label class="control-label col-md-3">Argomento *</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlArgomento" runat="server" DataSourceID="odsarg" DataTextField="argomento" 
                                        DataValueField="idargomentofaq" CssClass="form-control select2" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" Text="Argomento"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsarg" runat="server" SelectMethod="SelectAllArgomentoFAQ" TypeName="BusinessLogic.UtilitysBL">
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
                                <label class="control-label col-md-3">DAL *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtValidaDal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Valida DAL"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3">AL *</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtValidaAl" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Valida AL"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                    </div>    
                    
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="box-title colorverded">FAQ</h3>
                            <hr class="m-t-0 m-b-40">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-2">Domanda *</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtDomanda" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control" placeholder="Domanda"></asp:TextBox> 
                                </div>
                            </div>
                        </div>   
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-2">Risposta *</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtRisposta" runat="server" Rows="10" TextMode="MultiLine" CssClass="form-control" placeholder="Risposta"></asp:TextBox> 
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
</div>



</asp:Content>