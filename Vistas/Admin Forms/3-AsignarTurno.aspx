<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3-AsignarTurno.aspx.cs" Inherits="Vistas.Admin_Forms.AsignarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnos</title>
    <link rel="stylesheet" type="text/css" href="../CSS%20formularios/AsignarTurno.css" />
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAdminlog" runat="server"></asp:Label>
            &nbsp;<br />
            <asp:HyperLink ID="hl_volveraadminlogueado" runat="server" NavigateUrl="~/Admin Forms/2-AdminLogueado.aspx">Volver atras</asp:HyperLink>
            &nbsp;<br />
            <br />
            <asp:Label ID="lblTitulo" runat="server" CssClass="auto-style1" Font-Bold="True" Text="Asignar Turno"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
        </div>
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad del medico: "></asp:Label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblMedico" runat="server" Text="Medico: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged1">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDia" runat="server" Text="Día de atención:  " ValidateRequestMode="Enabled"></asp:Label>
        <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDia_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblHorario" runat="server" Text="Horario de atención: "></asp:Label>
        <asp:DropDownList ID="ddlHorario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHorario_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Fechas disponibles:<asp:DropDownList ID="ddlFechas" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDniPaciente" runat="server" Text="Dni del paciente: "></asp:Label>
        <asp:TextBox ID="txtDniPaciente" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAsignarTurno" runat="server" Text="Asignar" OnClick="btnAsignarTurno_Click" />
        <br />
        <asp:Label ID="lbl_mensajeaclaratorio" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
