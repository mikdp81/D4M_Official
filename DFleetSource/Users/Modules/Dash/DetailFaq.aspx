<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Users/MasterpageUsers.Master" AutoEventWireup="true" CodeBehind="DetailFaq.aspx.cs" Inherits="DFleet.Users.Modules.Utility.DetailFaq" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">FAQ - <asp:Label ID="lblArgomento" runat="server" Text=""></asp:Label></h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Users/Modules/Dash/ViewFAQ")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alle Faq</a> 
            </div>				
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">

                <div class="form-body">
                    <div class="form-group row ">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group ">
                                        <asp:TextBox ID="txtSearch" runat="server" Columns="30" MaxLength="255" CssClass="form-control" placeholder="Cerca..."></asp:TextBox> 
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group ">
                                        <asp:Button ID="btnCerca" runat="server" onclick="btnCerca_Click" Text="Filtra" CssClass="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>   
                    </div>    
                </div>
            </div> 
        </div>
    </div>
        
    <div class="white-box">
        <div class="row">
            <div class="col-12">
                
                <div id="accordion" class="accordion-container">
                    <asp:GridView ID="gvRicFAQ" runat="server"
                            AutoGenerateColumns="False" DataSourceID="odsRicFAQ" CssClass="display nowrap " 
                            GridLines="None" PageSize="30" Width="100%" HorizontalAlign="Center">
                        <Columns>     
                            <asp:TemplateField HeaderText=""> 
                                <ItemTemplate>
                                    <h4 class="accordion-title"><%# Eval("Domanda")%></h4>
                                    <div class="accordion-content">
                                        <p><%# Eval("Risposta")%></p>
                                    </div>                                    
                                </ItemTemplate>                                
                            </asp:TemplateField>     
                        </Columns>    
                        <PagerStyle HorizontalAlign="Right" />    
                    </asp:GridView>                    
                </div> 

                <asp:ObjectDataSource ID="odsRicFAQ" runat="server" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="SelectFAQXId" TypeName="BusinessLogic.UtilitysBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hduid" Name="idargomentofaq" PropertyName="Value" Type="Int32" />
                        <asp:ControlParameter ControlID="txtSearch" Name="keysearch" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>  

                <asp:HiddenField ID="hduid" runat="server" />
            </div>            
        </div>
    </div>
</div>


</asp:Content>