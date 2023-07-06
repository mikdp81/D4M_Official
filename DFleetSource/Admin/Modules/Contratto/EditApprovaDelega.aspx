<%@ Page Title="Approva Delega" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="EditApprovaDelega.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.EditApprovaDelega" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Approva Delega</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewDeleghe")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>


    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">
                DRIVER: <br />                                    
                <h4><asp:Label ID="lblDati" runat="server" Text="" /></h4>
                SOCIET&Agrave;: <br />
                <h4><asp:Label ID="lblSocieta" runat="server" Text=""></asp:Label></h4>
                MODULO: <br />
                <h4><asp:Label ID="lblviewfilemodulo" runat="server" Text=""></asp:Label></h4>
                TIPO MODULO: <br />
                <h4><asp:Label ID="lblTipoModulo" runat="server" Text=""></asp:Label></h4>
                APPROVAZIONE: <br />
                <h4><asp:Label ID="lblAppr" runat="server" Text=""></asp:Label></h4>
            </div>                        
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-sm-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>
                              
                                 
                <div class="form-body">                                    
                    <div class="row"> 
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Annotazioni</label>
                                <asp:TextBox ID="txtNote" runat="server" Rows="3" Columns="30" CssClass="form-control" placeholder="Annotazioni" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>  
                    </div>
                    <div class="row"> 
                        <div class="col-md-12">
                            <asp:HiddenField ID="hduid" runat="server" />
                            <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Approva" CssClass="btn btn-success" />
                            <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Non Approva" CssClass="btn btn-success" />
                        </div>                        
                    </div>
                </div>
            </div> 
        </div>
    </div>
</div>



</asp:Content>