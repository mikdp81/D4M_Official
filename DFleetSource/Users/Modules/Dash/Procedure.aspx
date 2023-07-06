<%@ Page Title="Procedure" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="Procedure.aspx.cs" Inherits="DFleet.Users.Modules.Dash.Procedure" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
      
<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Procedure</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-6">
                <%--- <a href="RichiestaDelega">Richiesta delega a condurre</a> <br />                
                <asp:Label ID="lblViewFilePdf" runat="server" Text=""></asp:Label>               
                <asp:Label ID="lblViewFilePdfConv" runat="server" Text=""></asp:Label>
                <br /><br />
                - <a href="RichiestaZTL">Richiesta ZTL</a><br />                
                <asp:Label ID="lblViewFilePdfZTL" runat="server" Text=""></asp:Label>--%>
                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <h3>Deleghe a condurre</h3>

                <a href="RichiestaDelega" class="btn btn-success">Compila</a> <br /><br />
                
                <%---<label class="control-label">Carica File</label> (solo file .pdf) <br />
                <asp:FileUpload ID="fuFileDelega"  CssClass="form-control" runat="server" />
                <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Carica" CssClass="btn btn-success" /> <br /><br />--%>
                
                <asp:GridView ID="gvDeleghe" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsDeleghe" CssClass="display nowrap dataTable" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField> 
                                                  
                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datains").ToString())%>           
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <%# ReturnModuloFirmato(Eval("modulofirmato").ToString(), Eval("noteamministrazione").ToString(), Eval("checkdoc").ToString(), "1",
                                    Eval("Cittaresidenza").ToString(), Eval("Indirizzoresidenza").ToString(), Eval("Civicoresidenza").ToString(), Eval("Cittaresidenzadelegato").ToString(), 
                                    Eval("Indirizzoresidenzadelegato").ToString(), Eval("Civicoresidenzadelegato").ToString(), Eval("Uid").ToString(), Eval("Moduloconvivenza").ToString())%>           
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsDeleghe" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDelegheUser" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="idtipomodulo" Type="Int32" />
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        </SelectParameters>
                </asp:ObjectDataSource>  


            </div>

            
            <div class="col-md-6">
                <asp:Panel ID="pnlMessage2" runat="server">
                    <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                </asp:Panel>

                
                <h3>ZTL</h3>
                
                <a href="RichiestaZTL" class="btn btn-success">Compila</a> <br /><br /> 
                
                <%---<label class="control-label">Carica File</label> (solo file .pdf) <br />
                <asp:FileUpload ID="fuFileZTL"  CssClass="form-control" runat="server" />
                <asp:Button ID="btnModifica2" runat="server" onclick="btnModifica2_Click" Text="Carica" CssClass="btn btn-success" /> <br /><br />--%>

                <asp:GridView ID="gvDeleghe2" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsDeleghe2" CssClass="display nowrap dataTable2" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="#">   
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>                    
                        </asp:TemplateField>  
                                                  
                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <%# ReturnData(Eval("datains").ToString())%>           
                            </ItemTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <%# ReturnModuloFirmato(Eval("modulofirmato").ToString(), Eval("noteamministrazione").ToString(), Eval("checkdoc").ToString(), "2",
                                    "","","","","","","", Eval("Moduloconvivenza").ToString())%>           
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsDeleghe2" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="SelectDelegheUser" TypeName="BusinessLogic.ContrattiBL">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="2" Name="idtipomodulo" Type="Int32" />
                            <asp:ControlParameter ControlID="hdiduser" Name="UserId" PropertyName="Value" DbType="Guid" />
                        </SelectParameters>
                </asp:ObjectDataSource>

            </div>
        </div>
    </div>
</div>

    

<asp:HiddenField ID="hdiduser" runat="server" />

</asp:Content>