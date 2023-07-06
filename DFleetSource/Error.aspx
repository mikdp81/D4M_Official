<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="DFleet.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                
   <br /><br /><br /><br /><div style="text-align:center">
    ATTENZIONE!<br /><br /> Si è verificato un errore: <%= Request.QueryString["message"].ToString() %><br /><br /></div>
        

        </div>
    </form>
</body>
</html>
