<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-RegistrarPacientes.aspx.cs" Inherits="Vistas.Pacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pacientes</title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/RegistrarPacientes.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblAdministrador" runat="server" Text="Hola Administrador x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volverabmlpacientes" runat="server" NavigateUrl="~/Admin Forms/ABML-Pacientes/1-Inicio-ABML-Pacientes.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Registrar nuevo paciente:</h2>
        </div>
        
        <asp:Label ID="LblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>

        <asp:Label ID="LblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>

        <asp:Label ID="LblDni" runat="server" Text="Dni:"></asp:Label>
        <asp:TextBox ID="TxtDni" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="LblSexo" runat="server" Text="Género: "></asp:Label>
        <asp:RadioButton ID="rbHombre" runat="server" Text="Hombre" />
        &nbsp;
        <asp:RadioButton ID="rbMujer" runat="server" Text="Mujer" />

        <br />

        <asp:Label ID="LblNacionalidad" runat="server" Text="Nacionalidad: "></asp:Label>
        <asp:TextBox ID="TxtNacionalidad" runat="server"></asp:TextBox>

        &nbsp;

        <asp:Label ID="LbNachimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
        <asp:TextBox ID="TxtNacimiento" runat="server" TextMode="Date" Width="133px"></asp:TextBox>

        <br />

        <asp:Label ID="LblDireccion" runat="server" Text="Dirección: "></asp:Label>
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>

        <asp:Label ID="Lbl_provincia" runat="server" Text="Provincia: "></asp:Label>
        <asp:DropDownList ID="ddl_provincias" runat="server">
        </asp:DropDownList>

        <asp:Label ID="Lbl_localidad" runat="server" Text="Localidad:"></asp:Label>
        <asp:DropDownList ID="ddl_localidades" runat="server">
        </asp:DropDownList>
        <br />

        <asp:Label ID="LblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" Height="25px" TextMode="Email"></asp:TextBox>

        <br />

        <asp:Label ID="LblTelefono" runat="server" Text="Teléfono: "></asp:Label>
        <asp:TextBox ID="TxtTelefono" runat="server" Height="26px" TextMode="Phone"></asp:TextBox>

        &nbsp;
        <asp:Button ID="btn_registrar" runat="server" Text="Registrar" OnClick="btn_registrar_Click" />
&nbsp;<div class="Botones">
            <br />
            <asp:Label ID="lbl_mensajepacientes" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
