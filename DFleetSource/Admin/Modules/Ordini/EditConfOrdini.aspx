<%@ Page Title="Modifica Carpolicy" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="EditConfOrdini.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.EditConfOrdini" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Carpolicy</h3>
            </div>
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/ViewConfDriver")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>				
        </div>
    </div>


    <div class="white-box">
        <div class="row">
            <div class="col-12">        
                Driver <br />
                <h4> <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label><br /></h4>              
                Grade <br />
                <h4> <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label> <br /></h4>    
                Societ&agrave; <br />
                <h4> <asp:Label ID="lblSocieta" runat="server" Text=""></asp:Label></h4> 
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
                                <label class="control-label">CarPolicy</label>
                                <asp:DropDownList ID="ddlCodCarPolicy" runat="server" CssClass="form-control select2 ddlCarPolicy" AppendDataBoundItems="True"
                                     DataSourceID="odscarpolicy" DataTextField="codcarpolicy" DataValueField="codcarpolicy">
                                    <asp:ListItem Value="" Text="Codice Car Policy"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odscarpolicy" runat="server" SelectMethod="SelectAllCarPolicy" TypeName="BusinessLogic.CarsBL">
                                    <SelectParameters>
                                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                       <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data decorrenza</label>
                                <asp:TextBox ID="txtDatadecorrenzadal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data decorrenza"></asp:TextBox> 
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Data fine decorrenza</label>
                                <asp:TextBox ID="txtDatadecorrenzaal" runat="server" Columns="30" MaxLength="10" CssClass="form-control datePicker" placeholder="Data fine decorrenza"></asp:TextBox> 
                            </div>
                        </div> 


                        </div> 
                          <div class="row">   

                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Car Policy (solo file .pdf)</label>                                
                                <asp:FileUpload ID="fuFileCarPolicy"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFileCarPolicy" runat="server" />
                                <asp:Label ID="lblViewFileCarPolicy" runat="server" Text=""></asp:Label>
                            </div>
                        </div>    


                               <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Patente (solo file .pdf)</label>                                
                                <asp:FileUpload ID="fuFilePatente"  CssClass="form-control" runat="server" />
                                <asp:HiddenField ID="hdFilePatente" runat="server" />
                                <asp:Label ID="lblViewFilePatente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>   
                    </div>
                </div>
                <div class="form-actions">
                    <asp:HiddenField ID="hduid" runat="server" />
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Modifica" CssClass="btn btn-success" />
                </div>

            </div> 
        </div>
    </div>

</div>



</asp:Content>