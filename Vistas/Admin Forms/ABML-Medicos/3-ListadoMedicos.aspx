<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3-ListadoMedicos.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Medicos.ListadoMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/ListadoMedicos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuarioadministrador" runat="server" Text="Admin x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveratras" runat="server" NavigateUrl="~/Admin Forms/ABML-Medicos/1-Inicio-ABML-Medicos.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Listado de Medicos</h2>
            <p>
                <asp:Label ID="lbl_ingreselegajo" runat="server" Text="Ingrese el Legajo del Medico a buscar:"></asp:Label>
                <asp:TextBox ID="txt_legajomedico" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_buscarporlegajo" runat="server" Text="Buscar Medico" OnClick="btn_buscarporlegajo_Click1" />
&nbsp;<asp:Button ID="btn_filtrartodos" runat="server" Text="Filtrar todos" OnClick="btn_filtrartodos_Click" />
            </p>
            <p>
                <asp:GridView ID="grv_medicos" runat="server" AllowPaging="True" OnPageIndexChanging="grv_medicos_PageIndexChanging">
                </asp:GridView>
            </p>
            <p>
                <asp:Label ID="lbl_msj" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
