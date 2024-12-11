<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5-EliminarPaciente.aspx.cs" Inherits="Vistas.Admin_Forms.EliminarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baja Paciente</title>
 <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/EliminarPaciente.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuarioadmin" runat="server" Text="Admin x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volverabmlpacientes" runat="server" NavigateUrl="~/Admin Forms/ABML-Pacientes/1-Inicio-ABML-Pacientes.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Eliminar Paciente</h2>
            <br />
            <asp:Label ID="lbl_paciente_eliminar" runat="server" Text="Ingrese DNI del paciente a eliminar:"></asp:Label>
&nbsp;<asp:TextBox ID="txtDniEliminar" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_eliminarmedico" runat="server" Text="Eliminar paciente" OnClick="btn_eliminarmedico_Click" />
            <br />
            <br />
            <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
