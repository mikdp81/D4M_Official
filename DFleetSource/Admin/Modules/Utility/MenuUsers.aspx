<%@ Page Title="Modifica Menu Users" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="MenuUsers.aspx.cs" Inherits="DFleet.Admin.Modules.Utility.MenuUsers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Modifica Menu Users</h3>
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>


                <asp:GridView ID="gvImpo" runat="server" AutoGenerateColumns="False" DataSourceID="odsImpo" CssClass="display nowrap dataTable" 
                    GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>                    
                        <asp:TemplateField HeaderText="Visibile">
                            <ItemTemplate>
                                <%# Eval("pagina")%>: <asp:CheckBox ID="status" runat="server" CssClass="js-switch" data-color="#13dafe" Checked='<%# GetCheckedStatus(Eval("status").ToString()) %>' />
                                <asp:HiddenField ID="hdidpagina" runat="server" Value='<%# Eval("idpagina")%>'  />
                            </ItemTemplate>
                        </asp:TemplateField>                         
                    </Columns>    
                    <PagerStyle HorizontalAlign="right" /> 
                </asp:GridView>

                <asp:ObjectDataSource ID="odsImpo" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAllPageUsers" TypeName="BusinessLogic.AccountBL">
                    <SelectParameters>
                        <asp:SessionParameter DbType="Guid" Name="Uidtenant" SessionField="Uidtenant" />
                    </SelectParameters>
                </asp:ObjectDataSource> 

                <div class="form-action">
                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Salva" CssClass="btn btn-success" />
                </div> 
            </div> 
        </div>
    </div>
</div>



</asp:Content>