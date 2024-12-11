<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-LoginAdmin.aspx.cs" Inherits="Vistas.UsuarioAdministrador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <link rel="stylesheet" type="text/css" href="../CSS%20formularios/UsuarioAdministrador.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Administrador</h2>
            <asp:TextBox ID="txtUsuarioAdmin" runat="server" Width="195px" Height="20px" placeholder="Usuario" ValidationGroup="grupoLoginAdmin"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtClaveAdmin" runat="server" Height="27px" Width="195px"  placeholder="Clave" ValidationGroup="grupoLoginAdmin" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" Height="30px" Width="100px" OnClick="btnIngresar_Click" ValidationGroup="grupoLoginAdmin" />
        </div>
        <p>
             <asp:Label ID="txtErrorCredenciales" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:Label>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtUsuarioAdmin" ValidationGroup="grupoLoginAdmin" Font-Bold="True" ForeColor="Red">Debes ingresar un usuario</asp:RequiredFieldValidator>    
        </p>
        <p>
            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClaveAdmin" ValidationGroup="grupoLoginAdmin" Font-Bold="True" ForeColor="Red">Debes ingresar una contraseña</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:HyperLink ID="hl_volveraaseleccionarinforme" runat="server" NavigateUrl="~/InicioUsuario.aspx">Volver atras</asp:HyperLink>
        </p>
    </form>
</body>
</html>
