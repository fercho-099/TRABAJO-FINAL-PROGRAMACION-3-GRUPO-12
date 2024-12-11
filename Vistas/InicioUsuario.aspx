<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioUsuario.aspx.cs" Inherits="Vistas.InicioUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS formularios/InicioUsuario1.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Clinica Medica</h2>
            Seleccionar usuario<br />
            <br />
            <asp:HyperLink  ID="hlAdministrador"  runat="server" NavigateUrl="~/Admin Forms/1-LoginAdmin.aspx">Administrador</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="hlMedico" runat="server" NavigateUrl="~/Medico Forms/1-LoginMedico.aspx">Medico</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
