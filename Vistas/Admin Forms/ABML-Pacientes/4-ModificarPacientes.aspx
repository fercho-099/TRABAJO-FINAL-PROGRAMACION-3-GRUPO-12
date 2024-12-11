<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4-ModificarPacientes.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Pacientes._4_ModificarPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/ModPacientes.css" />
    <style type="text/css">
        .auto-style1 {
            margin-top: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_usuarioadministrador" runat="server" Text="Admin x"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hl_volveratras" runat="server" NavigateUrl="~/Admin Forms/ABML-Pacientes/1-Inicio-ABML-Pacientes.aspx">Volver atras</asp:HyperLink>
            <br />
            <h2>Modificar pacientes</h2>
            <p>
                <asp:Label ID="lbl_ingreselegajo" runat="server" Text="Ingrese el DNI del paciente a modificar:"></asp:Label>
                <asp:TextBox ID="tbDniPaciente" runat="server"></asp:TextBox>
                <asp:Button ID="btn_buscarPaciente" runat="server" Text="Buscar paciente" OnClick="btn_buscarPaciente_Click" />
                &nbsp;
                <asp:Button ID="btn_filtrartodos" runat="server" Text="Filtrar todos" OnClick="btn_filtrartodos_Click" />
            </p>
            <p>
                <asp:Label ID="lbl_msj" runat="server"></asp:Label>
            </p>
            <p id="grv_pacientes">
                <asp:GridView ID="grv_pacientes_mod" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" Height="85px" Width="356px" OnRowCancelingEdit="grv_pacientes_mod_RowCancelingEdit" OnRowEditing="grv_pacientes_mod_RowEditing" OnRowUpdating="grv_pacientes_mod_RowUpdating" CssClass="auto-style1" AllowPaging="True" OnPageIndexChanging="grv_pacientes_mod_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="DNI Paciente">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_ei_dni_paciente" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtDniPaciente" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ei_nombre" runat="server" Text='<%# Bind("Nombre") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ei_apellido" runat="server" Text='<%# Bind("Apellido") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="SqlDataSource1" DataTextField="Sexo_pac" DataValueField="Sexo_pac">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=localhost\sqlexpress;Initial Catalog=ClinicaMedica_G12;Integrated Security=True;Encrypt=True;TrustServerCertificate=True" SelectCommand="SELECT DISTINCT [Sexo_pac] FROM [Paciente]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtSexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ei_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtNacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbEditFecha" runat="server" Text='<%# Bind("[Fecha de nacimiento]") %>' Height="26px" Width="109px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacimiento" runat="server" Text='<%# Eval("[Fecha de nacimiento]", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_ei_domicilio" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_domicilio" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo electronico">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ei_correo" runat="server" Text='<%# Bind("[Correo Electronico]") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtCorreo" runat="server" Text='<%# Bind("[Correo electronico]") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ei_telefono" runat="server" Text='<%# Bind("Telefono") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
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
            </p>
        </div>
    </form>
</body>
</html>
