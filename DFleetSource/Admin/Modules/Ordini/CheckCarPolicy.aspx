<%@ Page Title="Check CarPolicy" Language="C#" MasterPageFile="~/Admin/MasterpageAdmin.Master" AutoEventWireup="true" CodeBehind="CheckCarPolicy.aspx.cs" Inherits="DFleet.Admin.Modules.Ordini.CheckCarPolicy" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


<div class="col-sm-12">
    <div class="white-box">
        <div class="row">
            <div class="col-md-7">
                <h3 class="box-title m-b-0">Check CarPolicy</h3>
            </div>	
            <div class="col-md-5 text-right">
                <a href="<%=ResolveUrl("~/Admin/Modules/Ordini/ViewDocCarPolicy")%>" class="btn btn-info waves-effect waves-light m-t-10">Torna alla Lista</a> 
            </div>		
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-12">
                <asp:Label runat="server" ID="lblDati" Text=""></asp:Label>
            </div>
        </div>
    </div>

    <div class="white-box">
        <div class="row">
            <div class="col-md-6">
                <embed src="<%=ReturnLinkPdf() %>" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                <embed src="<%=ReturnLinkPdfPatente() %>" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
                <embed src="<%=ReturnLinkPdfFuelCard() %>" width="100%" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html" />
            </div>
            <div class="col-md-3">                
                <asp:Panel ID="pnlMessage" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:Panel>

                Conferma validit&agrave; documento <br /><br />

                <asp:Label ID="lblApprovato" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hddocumentocarpolicy" runat="server" />
                <asp:HiddenField ID="hddocumentopatente" runat="server" />
                <asp:HiddenField ID="hddocumentofuelcard" runat="server" />
                <asp:HiddenField ID="hduid" runat="server" />
                <asp:HiddenField ID="hduiduser" runat="server" />

                <br /><br />
                <asp:Button ID="btnApprova" runat="server" onclick="btnApprova_Click" Text="Approva" CssClass="btn btn-success" /> 
                <asp:Button ID="btnNonApprova" runat="server" onclick="btnNonApprova_Click" Text="Non Approva" CssClass="btn btn-success" /> 

            </div> 
        </div>


    </div>
</div>


</asp:Content>