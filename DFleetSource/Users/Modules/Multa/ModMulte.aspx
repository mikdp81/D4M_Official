<%@ Page Title="Modifica Multa" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ModMulte.aspx.cs" Inherits="DFleet.Users.Modules.Multa.ModMulte" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Multa</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Multa/ViewMulte")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
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
                            <div class="form-group">
                                <div class="col-md-12">Accettando questa multa, l'importo pagato con rivalsa sar&agrave; trattenuto dal tuo prossimo cedolino<br /><br /></div>
                                 <div class="row">
                                <asp:Label ID="lblDatiMulta" runat="server" Text=""></asp:Label>
</div>
                            </div>
                        </div> 
                    </div>
                </div>
                <div class="form-action m-t-30">  
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-10">              
                            <asp:Button ID="btnAccetto" runat="server" onclick="btnAccetto_Click" Text="ACCETTO MULTA"  /><br />
                        </div>
                    </div>
                </div> 

                <hr />
                <div class="form-body" runat="server" id="blockmanleva">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <br />Nel caso tu abbia riscontrato che sussistano gli estremi per il ricorso carica il <a href="../Dash/Documenti" target="_blank">documento di manleva</a> e allegalo <br /><br />
                                    <label class="control-label">Carica Documento di ManLeva * (sono accettati solo i file .pdf)</label>
                                    <asp:FileUpload ID="fuFileManLeva"  CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>   
                    </div>
                </div>
                <div class="form-action m-t-30">  
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-10">   
                            <asp:HiddenField ID="hduid" runat="server" />
                            <asp:Button ID="btnContesto" runat="server" onclick="btnContesto_Click" Text="CONTESTO MULTA" CssClass="btn btn-success" /><br />
                        </div>
                    </div>
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>