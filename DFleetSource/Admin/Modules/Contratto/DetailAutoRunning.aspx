<%@ Page Title="Auto" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="DetailAutoRunning.aspx.cs" Inherits="DFleet.Admin.Modules.Contratto.DetailAutoRunning" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Auto</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Contratto/ViewRunningFleet")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>		
        </div>
    </div>
    


        <div class="white-box">
        <div class="row">
            <div class="col-12">                
        
              <div class="col-md-6"> 
                
                MARCA<br />
                <h4><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></h4> 
                Modello<br />
               <h3 class="font-bold"><asp:Label ID="lblModello" runat="server" Text=""></asp:Label></h3>
                Alimentazione <br />
             <h4> <asp:Label ID="lblAlimentazione" runat="server" Text=""></asp:Label> / <asp:Label ID="lblAlimentazionesecondaria" runat="server" Text=""></asp:Label><br></h4>
                Cilindrata<br />
                <h4>  <asp:Label ID="lblCilindrata" runat="server" Text=""></asp:Label></h4> 
                  Fringe benefit base (questo valore può subire variazioni)<br>
                  <div class="col-md-2 bg-verde text-center"><h3 class="text-white"><asp:Label ID="lblFringebenefitbase" runat="server" Text=""></asp:Label></h3></div> <br>
                </div>
                <div class="col-md-6"> 

                   
                    
                    
                    <div class="row">
                        <div class="col-md-3 text-center">
                            Consumo medio (l/100km)<br />
                            <h4 class="text-verde"><asp:Label ID="lblConsumo" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                             urbano (l/100km)<br />
                           <h4 class="text-verde"><asp:Label ID="lblConsumourbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            extraurbano (l/100km)<br />
                           <h4 class="text-verde"> <asp:Label ID="lblConsumoextraurbano" runat="server" Text=""></asp:Label></h4>
                          </div>
                        <div class="col-md-3 text-center">
                            Emissioni (gr/km dich.)<br />
                            <h4 class="text-verde"><asp:Label ID="lblEmissioni" runat="server" Text=""></asp:Label></h4>
                          </div>
                      
                    </div>

                    <asp:Label ID="lblFoto" runat="server" Text=""></asp:Label>
                 
                
                
                </div>


             
</div>

        </div>


            
        <div class="row">
            <div class="col-md-3 text-center">
                Km attuali vettura<br />
                <h4 class="text-verde"><asp:Label ID="lblkmattuali" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                    Km totali contratto<br />
                <h4 class="text-verde"><asp:Label ID="lblkmtotali" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                Scadenza contratto<br />
                <h4 class="text-verde"> <asp:Label ID="lblscadenza" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="col-md-3 text-center">
                Luogo di ritiro<br />
                <h4 class="text-verde"><asp:Label ID="lblluogoritiro" runat="server" Text=""></asp:Label></h4>
                </div>
        </div>



        </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">                
                <h4>Storico Assegnazioni:</h4>
                <asp:Literal ID="ltstoricoassegnazioni" runat="server"></asp:Literal><br /><br />
            </div> 
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">                
                <div class="clear"></div>


                <h5>Colore</h5>
                <asp:Literal ID="ltcolori" runat="server"></asp:Literal><br /><br />
                
                <h5>Optional</h5>
                <div style="text-align:right;"><strong>OPTIONAL CANONE: </strong> <span style="font-weight:bold;color:red;">&euro;</span> <span id="totale" style="font-weight:bold;color:red;">0</span></div>
                <asp:Literal ID="ltoptional" runat="server"></asp:Literal><br /><br />
                

                <asp:HiddenField ID="hdcodjatoauto" runat="server" />
                <asp:HiddenField ID="hdidordine" runat="server" />
                <asp:HiddenField ID="hdidcontratto" runat="server" />
                <asp:HiddenField ID="hdUserId" runat="server" />
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
                        <div class="col-12">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Status Contratto</label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" DataSourceID="odsstatus" DataTextField="statuscontratto" 
                                        DataValueField="idstatuscontratto" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="-1" Text="Status Contratto"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsstatus" runat="server" SelectMethod="SelectAllStatusContratto" TypeName="BusinessLogic.ContrattiBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Condizione Auto </label>
                                    <asp:DropDownList ID="ddlCondizione" runat="server" DataSourceID="odscondizione" DataTextField="statoauto" 
                                        DataValueField="idstatoauto" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" Text="Condizione Auto"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odscondizione" runat="server" SelectMethod="SelectStatusAuto" TypeName="BusinessLogic.ContrattiBL">
                                        <SelectParameters>
                                            <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div> 
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Note</label>
                                    <asp:TextBox ID="txtNote" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control" placeholder="Note"></asp:TextBox> 
                                </div>
                            </div>
                        </div>  
                    </div> 
                </div>
            </div>
            <div class="form-action">
                <asp:HiddenField ID="hdUid" runat="server"></asp:HiddenField>
                <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
            </div> 
        </div>
    </div>
</div>



</asp:Content>