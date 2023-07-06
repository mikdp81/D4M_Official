<%@ Page Title="" Language="C#" MasterPageFile="~/Partner/MasterpagePartner.Master" AutoEventWireup="true" CodeBehind="Configura.aspx.cs" Inherits="DFleet.Partner.Modules.Dash.Configura" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

        
<div class="col-sm-12">  
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Scelta Nuova Auto</h3>
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
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                     <div class="form-group">
                                        <label class="control-label">Testo *</label>
                                        <asp:TextBox ID="txtTesto" runat="server" Rows="3" CssClass="form-control" placeholder="Testo" TextMode="MultiLine"></asp:TextBox> 
                                    </div>
                                </div> 
                                <div class="col-md-12">
                                    <div class="form-group">                                
							            <label class="control-label"><strong>Allega uno o pi&ugrave; file</strong> (*.pdf, *.doc, *.docx, *.xls, *.xlsx) </label>
							            <input type="file" id="myfile" multiple="multiple" name="myfile" runat="server" size="100" />
                                    </div>
                                </div> 
                                <div class="col-md-12">
                                    <div class="form-group">    
                                        <asp:Button ID="btnInserisci" runat="server" onclick="btnInserisci_Click" Text="Invia" CssClass="btn btn-success" />                             
                                    </div>
                                </div> 
                            </div>
                        </div>
                        <div class="col-md-6 text-center">                        
                            <img src="../../../plugins/images/car_conf.png" alt="" border="0" style="max-width:100%;height:auto;" /><br />
                            Richiedi al nostro consulente di affiancarti <br /> nella configurazione della tua nuova auto.<br /><br />
                            Allega il preventivo se già in tuo possesso.
                        </div>
                    </div>  
                </div>
            </div> 
        </div>
    </div>
</div>

</asp:Content>