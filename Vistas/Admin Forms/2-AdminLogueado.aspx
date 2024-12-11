<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-AdminLogueado.aspx.cs" Inherits="Vistas.AdminLogueado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administrador</title>
    <link rel="stylesheet" type="text/css" href="../CSS%20formularios/EstiloAdministrador.css"/>
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="Identificacion">
            <asp:Label ID="lblAdminlog" runat="server"></asp:Label>
        </div>
        <div class="botones">
          
            <table class="todosBoton">
                <tr>
                    <td>  <asp:Button ID="BtnPacientes" runat="server" Text="Pacientes" Width="120px" OnClick="BtnPacientes_Click" />
                    </td>
                    <td> <asp:Button ID="BtnMedicos" runat="server" Text="Medicos" Width="120px" OnClick="BtnMedicos_Click" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnTurnos" runat="server" Text="Turnos" Width="120px" OnClick="BtnTurnos_Click" />
                    </td>
                    <td><asp:Button ID="BtnInformes" runat="server" Text="Informes" Width="120px" OnClick="BtnInformes_Click" /></td>
                </tr>
            </table>

          
        </div>
    <p>
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Cerrar Sesion" />
        </p>
    </form>
    </body>
</html>
