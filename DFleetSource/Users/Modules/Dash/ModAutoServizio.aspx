<%@ Page Title="Modifica" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ModAutoServizio.aspx.cs" Inherits="DFleet.Users.Modules.Dash.ModAutoServizio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Libretto di bordo</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Dash/ViewAutoServizio")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                        <div class="col-md-12">
                            <asp:Label ID="lblDatiRev" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-action m-t-30">  
                    <div class="row">              
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Scopo del viaggio</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                            <div class="row">   
                                <div class="col-md-12">                         
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="control-label">Scegli</label>
                                            <asp:DropDownList ID="ddlScopoViaggio" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                                                 DataSourceID="odsscopoviaggio" DataTextField="descrizione" DataValueField="descrizione">
                                                <asp:ListItem Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsscopoviaggio" runat="server" SelectMethod="SelectAllScopoViaggio" TypeName="BusinessLogic.ContrattiBL" >
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
                                    <h3 class="box-title colorverded">Km</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                            <div class="row">   
                                <div class="col-md-12"> 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="control-label">Km iniziali</label>
                                            <asp:TextBox ID="txtKminiziali" runat="server" Cols="10" Maxlength="10" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>  
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="control-label">Km finali</label>
                                            <asp:TextBox ID="txtKmrestituzione" runat="server" Cols="10" Maxlength="10" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>  
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Spese</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                            <div class="row">   
                                <div class="col-md-12">                         
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="control-label">Descrizione</label>
                                            <asp:TextBox ID="txtSpese" runat="server" Cols="30" Maxlength="255" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>  
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="control-label">Totale Spese</label>
                                            <asp:TextBox ID="txtImportospese" runat="server" Cols="10" Maxlength="10" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>  
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <h3 class="box-title colorverded">Annotazioni</h3>
                                    <hr class="m-t-0 m-b-40">
                                </div>
                            </div>
                            <div class="row">   
                                <div class="col-md-12">  
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="control-label">Note</label>
                                            <asp:TextBox ID="txtNote" runat="server" Rows="3" CssClass="form-control" placeholder="Testo" TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                    </div>   
                                </div>
                            </div>
                        </div>    
                        <div class="col-md-12">     
                            <asp:HiddenField ID="hduid" runat="server" />
                            <asp:Button ID="btnCheck" runat="server" onclick="btnCheck_Click" Text="SALVA" CssClass="btn btn-success" /><br />
                        </div>
                    </div>
                </div>  
            </div> 
        </div>
    </div>
</div>



</asp:Content>