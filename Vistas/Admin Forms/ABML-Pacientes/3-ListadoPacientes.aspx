<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3-ListadoPacientes.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Pacientes.ListadoPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/ListadoPacientes.css" />
    <style type="text/css">


h2 {
    color: #333;
}

#btn_filtrartodos, #btn_buscarporlegajo {
    transition: all 0.3s ease 0s;
    border-radius: 5px;
    font-size: 14px;
    margin-top: 20px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuarioadministrador" runat="server" Text="Administrador x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveratras" runat="server" NavigateUrl="~/Admin Forms/ABML-Pacientes/1-Inicio-ABML-Pacientes.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Listado de Pacientes</h2>
            <p>
                <asp:Label ID="lbl_ingreseDni" runat="server" Text="Ingrese el DNI del Paciente a buscar:"></asp:Label>
                <asp:TextBox ID="txtDniPaciente" runat="server"></asp:TextBox>
                <asp:Button ID="btn_buscarpordni" runat="server" Text="Buscar Paciente" OnClick="btn_buscarpordni_Click1" />
&nbsp;
                <asp:Button ID="btn_filtrartodos" runat="server" Text="Filtrar todos" />
            </p>
            <p>
                <asp:GridView ID="grv_pacientes" runat="server" AllowPaging="True" OnPageIndexChanging="grv_pacientes_PageIndexChanging">
                </asp:GridView>
            </p>
            <p>
                <asp:Label ID="lbl_msj" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
