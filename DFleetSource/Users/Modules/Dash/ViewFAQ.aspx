<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="ViewFAQ.aspx.cs" Inherits="DFleet.Users.Modules.Utility.ViewFAQ" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">FAQ - domande e risposte</h3>
            </div>				
        </div>
    </div>

        
    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvRicArgomentiFAQ" runat="server"
                        AutoGenerateColumns="False" DataSourceID="odsRicArgomentiFAQ" CssClass="display nowrap" 
                        GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                    <Columns>     
                        <asp:TemplateField HeaderText=""> 
                            <ItemTemplate>
                                <div class="col-sm-12 m-b-10">
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <img src="../../../DownloadFile?type=faq&nomefile=<%# Eval("Immagine") %>" alt="" border="0" style="max-width:100%;height:auto;" />
                                        </div>
                                        <div class="col-sm-10">
                                            <br /><br /><a href="DetailFaq-<%# Eval("Uid") %>" style="font-weight:bold;font-size:24px;"><%# Eval("Argomento")%></a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>                                
                        </asp:TemplateField>     
                    </Columns>    
                    <PagerStyle HorizontalAlign="Right" />    
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRicArgomentiFAQ" runat="server" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="SelectArgomentoFAQAttivi" TypeName="BusinessLogic.UtilitysBL">
                </asp:ObjectDataSource>  
            </div>
        </div>
    </div>
</div>


</asp:Content>