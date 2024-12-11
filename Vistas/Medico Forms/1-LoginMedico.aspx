<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-LoginMedico.aspx.cs" Inherits="Vistas.UsuarioMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medico</title>
    <link rel="stylesheet" type="text/css" href="../CSS%20formularios/UsuarioMedico.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Medico</h2>
            <asp:TextBox ID="txtUsuarioMed" runat="server" Width="195px" Height="20px" placeholder="Usuario" ValidationGroup="grupoLoginMedico"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtClaveMedico" runat="server" Height="27px" Width="195px"  placeholder="Clave" TextMode="Password" ValidationGroup="grupoLoginMedico"></asp:TextBox>
            <br />
            <asp:Button ID="btnIngresarMedico" runat="server" Text="Ingresar" Height="30px" Width="100px" OnClick="btnIngresarMedico_Click" ValidationGroup="grupoLoginMedico" />
            <br />
            <br />
             <asp:Label ID="txtErrorCredenciales" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtUsuarioMed" ValidationGroup="grupoLoginMedico" Font-Bold="True" ForeColor="Red">Debes ingresar un usuario</asp:RequiredFieldValidator>    
            <br />
            <br />
            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClaveMedico" ValidationGroup="grupoLoginMedico" Font-Bold="True" ForeColor="Red">Debes ingresar una contraseña</asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;<asp:HyperLink ID="hl_volveraaseleccionarinforme" runat="server" NavigateUrl="~/InicioUsuario.aspx">Volver atras</asp:HyperLink>
        </div>
    </form>
</body>
</html>