<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-UsuarioMedicoTurnosAsig.aspx.cs" Inherits="Vistas.UsuarioMedicoLogueado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" type="text/css" href="../CSS%20formularios/UsuarioMedicoLogueado.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="lblMedicoLog" runat="server" Font-Bold="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Cerrar Sesion" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <h2>Turnos</h2>
            <br />
            <asp:Label ID="lbl_busqueda_pordni" runat="server" Text="Ingrese DNI del paciente:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txt_buscarPorDni" runat="server" Width="149px" ValidationGroup="grupoDniTurnos"></asp:TextBox>
&nbsp;
            <asp:Button ID="btn_buscarpaciente" runat="server" Text="Buscar paciente" Width="124px" OnClick="btn_buscarpaciente_Click" ValidationGroup="grupoDniTurnos" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_buscarTodos" runat="server" Text="Todos los turnos" Width="124px" OnClick="btn_buscarTodos_Click" ValidationGroup="grupoDniTurnos" />
            <br />
            <br />
            <asp:GridView ID="Gv_Turnos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="Gv_Turnos_RowCancelingEdit" OnRowDataBound="Gv_Turnos_RowDataBound" OnRowEditing="Gv_Turnos_RowEditing" OnRowUpdating="Gv_Turnos_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Turno">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_ei_IdTurno" runat="server" Text='<%# Bind("NroTurno") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_IdTurno" runat="server" Text='<%# Bind("NroTurno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PACIENTE">
                        <ItemTemplate>
                            <asp:Label ID="txtNombrePaciente" runat="server" Text='<%# Bind("Nombre_pac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:Label ID="lbl_dni" runat="server" Text='<%# Bind("DNI_Pac_turn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FECHA NACIMIENTO">
                        <ItemTemplate>
                            <asp:Label ID="lbl_fechanac" runat="server" Text='<%# Bind("FechaNac_pac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DIA">
                        <ItemTemplate>
                            <asp:Label ID="lbl_dia" runat="server" Text='<%# Bind("Nombre_dia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HORARIO">
                        <ItemTemplate>
                            <asp:Label ID="lbl_horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ESTADO">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_ei_estado" runat="server" Width="100px">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_estado" runat="server" Text='<%# Bind("Estado_turn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OBSERVACION">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_ei_observacion" runat="server" Text='<%# Bind("Observacion_turn") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_observacion" runat="server" Text='<%# Bind("Observacion_turn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
