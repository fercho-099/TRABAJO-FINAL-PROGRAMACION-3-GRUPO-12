<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5-EliminarMedico.aspx.cs" Inherits="Vistas.Admin_Forms.EliminarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baja Medico</title>
<link rel="stylesheet" type="text/css" href="../../CSS%20formularios/EliminarMedico.css" />

 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuarioadmin" runat="server" Text="Administrador x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volverabmlmedicos" runat="server" NavigateUrl="~/Admin Forms/ABML-Medicos/1-Inicio-ABML-Medicos.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Eliminar Medico</h2>
            <br />
            <asp:Label ID="lbl_paciente_eliminar" runat="server" Text="Ingrese Legajo del medico a eliminar:"></asp:Label>
&nbsp;<asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_eliminarmedico" runat="server" Text="Eliminar medico" OnClick="btn_eliminarmedico_Click" />
            <br />
            <br />
            <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
