<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-Inicio-ABML-Pacientes.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Pacientes.Inicio_ABML_Pacientes" %>

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
            <asp:Label ID="LblAdministrador" runat="server" Text="Admin x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveraadminlogueado" runat="server" NavigateUrl="~/Admin Forms/2-AdminLogueado.aspx">Volver atras</asp:HyperLink>
            <br />
            <br />
            <asp:Button ID="btnRegistarPaciente" runat="server" Text="Registrar paciente" Width="120px" OnClick="btnRegistarPaciente_Click" />
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar Paciente" Width="120px" OnClick="BtnBuscar_Click" />
            <asp:Button ID="BtnModificacion" runat="server" Text="Modificar Paciente" Width="120px" OnClick="BtnModificacion_Click" />
            <asp:Button ID="BtnBaja" runat="server" Text="Eliminar Paciente" Width="120px" OnClick="BtnBaja_Click" />
            <br />
        </div>
    </form>
</body>
</html>
