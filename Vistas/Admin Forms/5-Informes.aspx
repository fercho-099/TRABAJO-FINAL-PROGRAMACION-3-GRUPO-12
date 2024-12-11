<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5-Informes.aspx.cs" Inherits="Vistas.Admin_Forms.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link rel="stylesheet" type="text/css" href="../CSS%20formularios/Informes.css" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuario" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveraaseleccionarinforme" runat="server" NavigateUrl="~/Admin Forms/4-SeleccionarInforme.aspx">Volver atras</asp:HyperLink>
        </div>
        <h2>Informe turnos entre fechas.</h2>
        <p>Fecha inicio:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_fechainicio" runat="server" TextMode="Date"></asp:TextBox>
        </p>
        <p>Fecha final:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_fechafinal" runat="server" TextMode="Date"></asp:TextBox>
        </p>
        <p class="auto-style1">
            <asp:Button ID="btn_generarinforme" runat="server" OnClick="btn_generarinforme_Click" Text="Producir Informe" />
        </p>
        <p>
            <asp:Label ID="lbl_cantidadturnos" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_cantidadturnospresentes" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_porcentajeturnospresentes" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_cantidadturnosausentes" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_porcentajeturnosausentes" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Lbl_PacientesInformes" runat="server"></asp:Label>
        </p>
        <p>&nbsp;</p>
    </form>
</body>
</html>
