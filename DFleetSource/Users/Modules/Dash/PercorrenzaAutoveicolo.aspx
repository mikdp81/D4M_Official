<%@ Page Title="Percorrenza Autoveicolo" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="PercorrenzaAutoveicolo.aspx.cs" Inherits="DFleet.Users.Modules.Dash.PercorrenzaAutoveicolo" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

  
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Percorrenza Autoveicolo</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <h4>Veicolo attuale</h4>                
                <asp:Literal ID="ltdati" runat="server"></asp:Literal>
            </div>
        </div>
    </div>

    <div class="white-box">
               <div class="row">
            <div class="col-md-5">
                <br />Rilevazioni precedenti sul veicolo <asp:Label ID="lblTarga" runat="server" Text="" CssClass="font-bold"></asp:Label>

                <asp:GridView ID="gvKmPercorsi" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsKmPercorsi" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                    
                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <%# String.Format(CultureInfo.CurrentCulture, "{0:d}",Eval("datains")) %>  
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Rilevazioni km a cruscotto">
                            <ItemTemplate>
                                <DIV class="text-right"><%# Eval("kmpercorsi")%></DIV>
                            </ItemTemplate>
                        </asp:TemplateField>  
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsKmPercorsi" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectKmPercorsi" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                            <asp:ControlParameter ControlID="lblTarga" Name="targa" PropertyName="Text" Type="String" />
                        </SelectParameters>
                </asp:ObjectDataSource>  

            </div>
            <div class="col-md-6">
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div class="form-body">
                    <div class="row">                        
                        <div class="col-md-6">
                            <div class="form-group">
                                <br /><label class="control-label">Aggiorni le sue percorrenze *</label>  <br />
                                Km percorsi al <strong><%=DateTime.Now.ToString("dd/MM/yyyy") %></strong> <asp:TextBox ID="txtKmPercorsi" runat="server" Cols="10" Maxlength="10" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Invia" CssClass="btn btn-success" />
                </div>
                
                <asp:HiddenField ID="hdiduser" runat="server" />
            </div>
        </div>
    </div>
</div>


</asp:Content>

