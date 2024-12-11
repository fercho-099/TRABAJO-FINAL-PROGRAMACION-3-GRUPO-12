<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4-SeleccionarInforme.aspx.cs" Inherits="Vistas.Admin_Forms._4_SeleccionarInforme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CSS%20formularios/EstiloAdministrador.css"/>
    <style type="text/css">


.Identificacion {
    margin-bottom: 20px;
}

.botones {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100%;
}

.todosBoton {
    border-collapse: separate;
    border-spacing: 30px; /* Esto asegura 3 cm entre los botones */
}

    .todosBoton td {
        text-align: center;
    }

    .todosBoton input[type="submit"], .todosBoton input[type="button"], .todosBoton button {
        width: 120px; /* Ajusta este valor según sea necesario */
        height: 50px;
        font-size: 16px;
        padding: 10px
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="Identificacion">
            <asp:Label ID="lblAdminlog" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveraadminlogueado" runat="server" NavigateUrl="~/Admin Forms/2-AdminLogueado.aspx">Volver atras</asp:HyperLink>
        </div>
        <div class="botones">
          
            <table class="todosBoton">
                <tr>
                    <td>  &nbsp;</td>
                    <td> &nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnInforme1" runat="server" Text="Informe 1" Width="120px" OnClick="BtnTurnos_Click" />
                    </td>
                    <td><asp:Button ID="BtnInforme2" runat="server" Text="Informe 2" Width="120px" OnClick="BtnInformes_Click" /></td>
                </tr>
            </table>

          
        </div>
        </div>
    </form>
</body>
</html>
