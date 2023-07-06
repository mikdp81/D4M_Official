<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionPage.aspx.cs" Inherits="DFleet.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Errore</title>
</head>
<body>
    
   <br /><br /><br /><br /><center>
    <h2> ATTENZIONE!<br /><br /> Si è verificato un errore: <%= Application["err"] %><br /><br />
        
        
        <a href='<%=ResolveUrl("~/Admin/Modules/Dash/Dashboard")%>'>Ritorna alla dashboard</a></h2>
    </center>
</body>
</html>
