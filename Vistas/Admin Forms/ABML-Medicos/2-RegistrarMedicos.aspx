<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-RegistrarMedicos.aspx.cs" Inherits="Vistas.Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medicos</title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/A-Medicos.css" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 9px;
        }
        .auto-style2 {
            margin-left: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div>
                <asp:Label ID="LblAdministrador" runat="server" Text="Admin x"></asp:Label></div>
            &nbsp;<h2>Registrar nuevo medico:</h2>
            <p>
            <asp:HyperLink ID="hl_volverMedicos" runat="server" NavigateUrl="~/Admin Forms/ABML-Medicos/1-Inicio-ABML-Medicos.aspx">Volver atras</asp:HyperLink>
            </p>
            <p>&nbsp;</p>
        </div>
        
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>

        <asp:Label ID="lblDni" runat="server" Text="Dni: "></asp:Label>
        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RFVLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese un legajo</asp:RequiredFieldValidator>
&nbsp;<asp:RequiredFieldValidator ID="RFVDNI" runat="server" ControlToValidate="txtDni" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese un DNI</asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese un Nombre</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RFVApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese un Apellido</asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lblGenero" runat="server" Text="Genero: "></asp:Label>
        <asp:RadioButton ID="rbHombre" runat="server" Text="Hombre" />
        &nbsp;
        <asp:RadioButton ID="rbMujer" runat="server" Text="Mujer" />

        <br />

        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad: "></asp:Label>
        <asp:TextBox ID="txtNacionalidad" runat="server"></asp:TextBox>

        &nbsp;

        <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de nacimiento: "></asp:Label>
        <asp:TextBox ID="txtNacimiento" runat="server" TextMode="Date" Width="133px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RFVNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese una Nacionalidad</asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>

        <asp:Label ID="lbl_provincia" runat="server" Text="Provincia:"></asp:Label>
        <asp:DropDownList ID="ddl_provincias" runat="server">
        </asp:DropDownList>

        <asp:Label ID="lbl_localidad" runat="server" Text="Localidad:"></asp:Label>
        <asp:DropDownList ID="ddl_localidades" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RFVProvincia" runat="server" ControlToValidate="ddl_provincias" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Seleccione Una Provincia</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RFVLocalidad" runat="server" ControlToValidate="ddl_localidades" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Seleccione una Localidad</asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico: "></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" Height="30px" TextMode="Email"></asp:TextBox>

        <br />

        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RFVEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Seleccione una Especialidad</asp:RequiredFieldValidator>
        <br />

        <br />

        <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" Width="105px"></asp:TextBox>

        <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="txtContrasenia" runat="server" Height="16px" Width="105px"></asp:TextBox>

        &nbsp;&nbsp;

        <asp:Label ID="lbl_repetircontraseña" runat="server" Text="Repetir contraseña:"></asp:Label>
        <asp:TextBox ID="txt_repetircontraseña" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese un Usuario</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RfVClave" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Ingrese una Contraseña</asp:RequiredFieldValidator>
        &nbsp;<asp:CompareValidator ID="cv_contraseñas" runat="server" ControlToCompare="txtContrasenia" ControlToValidate="txt_repetircontraseña" ForeColor="Red">Las contraseñas no coinciden.</asp:CompareValidator>
        <br />
        <br />

        <asp:Label ID="lblDia" runat="server" Text="Días de atención: "></asp:Label>
        <asp:CheckBoxList ID="checkDias" runat="server">
        </asp:CheckBoxList>

        <br />

        <asp:Label ID="lblDia0" runat="server" Text="Horario de atención: "></asp:Label>
        <asp:CheckBoxList ID="checkHorarios" runat="server">
        </asp:CheckBoxList>
        <br />
        <br />

        <asp:Button ID="btnRegistrarMedico" runat="server" Text="Registrar" OnClick="btnRegistrarMedico_Click" CssClass="auto-style2" />
        <br />
        <asp:Label ID="lbl_mensajemedicos" runat="server"></asp:Label>
    </form>
</body>
</html>
