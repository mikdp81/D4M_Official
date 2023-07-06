<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionPage.aspx.cs" Inherits="DFleet.Partner.ExceptionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Errore</title>
</head>
<body>
    
   <br /><br /><br /><br /><center>
    <h2> ATTENZIONE!<br /><br /> Si è verificato un errore: <%= Application["err"] %><br /><br />
        
        
        <a href="../Default">Ritorna alla pagina login</a></h2>
    </center>
</body>
</html>
