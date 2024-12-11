<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-Inicio-ABML-Medicos.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Medicos.Inicio_ABML_Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/InicioABML-Pacientes.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblAdministrador" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveraadminlogueado" runat="server" NavigateUrl="~/Admin Forms/2-AdminLogueado.aspx">Volver atras</asp:HyperLink>
            <br />
            <br />
            <asp:Button ID="btnRegistarMedico" runat="server" Text="Registrar medico" Width="120px" OnClick="btnRegistarMedico_Click" />
            <asp:Button ID="BtnBuscarMedico" runat="server" Text="Buscar medico" Width="120px" OnClick="BtnBuscarMedico_Click" />
            <asp:Button ID="BtnModificarMedico" runat="server" Text="Modificar medico" Width="120px" OnClick="BtnModificarMedico_Click" />
            <asp:Button ID="BtnEliminarMedico" runat="server" Text="Eliminar medico" Width="120px" OnClick="BtnEliminarMedico_Click" />
        </div>
    </form>
</body>
</html>
