<%@ Page Title="Modifica Multa" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="ModMulteDaPagare.aspx.cs" Inherits="DFleet.Admin.Modules.Multa.ModMulteDaPagare" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Multa</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Multa/ViewMulteDaPagare")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                                <asp:Label ID="lblDescrizioneMulta" runat="server" Text=""></asp:Label>
                            </div>
                        </div>  
                    </div>
                    <div class="row">  
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Titolare Pagamento *</label>
                                <asp:DropDownList ID="ddlTitolarePag" runat="server" DataSourceID="odstitolarepag" DataTextField="titolarepagamento" 
                                    DataValueField="idtitolarepagamento" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="-1" Text="Titolare Pagamento"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odstitolarepag" runat="server" SelectMethod="SelectAllTitolarePagamento" TypeName="BusinessLogic.MulteBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div>  
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">File Ricevuta Pagamento * <br />(sono accettati solo i file .pdf)</label>
                                <asp:FileUpload ID="fuFilePagamento"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFilePagamento" runat="server" />
                                <asp:Label ID="lblViewFilePagamento" runat="server" Text=""></asp:Label>
                            </div>
                        </div>  
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Data Pagamento *</label>
                                <asp:TextBox ID="txtDataPagamento" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data Pagamento"></asp:TextBox> 
                            </div>
                        </div>   
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Importo Pagamento *</label>                                
                                <asp:DropDownList ID="ddlImportoPagamento" runat="server" DataSourceID="odsimporto" DataTextField="tipomulta" 
                                    DataValueField="importomulta" CssClass="form-control select2" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Importo Pagamento"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsimporto" runat="server" SelectMethod="SelectAllImporto" TypeName="BusinessLogic.MulteBL" OldValuesParameterFormatString="original_{0}" >
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hduid" DbType="Guid" Name="Uid" PropertyName="Value" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Spese Pagamento </label>
                                <asp:TextBox ID="txtSpesePagamento" runat="server" Columns="30" MaxLength="20" CssClass="form-control" placeholder="Spese Pagamento"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Tipo Pagamento </label>
                                <asp:DropDownList ID="ddlCodPagamento" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="" Text="Tipo Pagamento"></asp:ListItem>
                                    <asp:ListItem Value="PagoPa" Text="">PagoPa</asp:ListItem>
                                    <asp:ListItem Value="Bonifico" Text="">Bonifico</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Conto di pagamento </label>
                                <asp:DropDownList ID="ddlContoPagamento" runat="server" DataSourceID="odscontopag" DataTextField="contopagamento" 
                                    DataValueField="idcontopagamento" CssClass="form-control" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Conto pagamento"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscontopag" runat="server" SelectMethod="SelectAllContoPagamento" TypeName="BusinessLogic.MulteBL" >
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> 
                            </div>
                        </div>  
                    </div>
                </div>
                <div class="form-action">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:HiddenField ID="hdidmulta" runat="server" />
                    <asp:HiddenField ID="hduserid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                    <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Salva e chiudi" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>