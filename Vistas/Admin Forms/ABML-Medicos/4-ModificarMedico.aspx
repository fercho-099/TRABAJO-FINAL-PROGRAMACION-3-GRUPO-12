<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4-ModificarMedico.aspx.cs" Inherits="Vistas.Admin_Forms.ABML_Medicos._4_ModificarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../CSS%20formularios/ModMedicos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAdminlog" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="hl_volveratras" runat="server" NavigateUrl="~/Admin Forms/ABML-Medicos/1-Inicio-ABML-Medicos.aspx">Volver atras</asp:HyperLink>
            <h2>Modificar medicos</h2>
            <p>
                <asp:Label ID="lbl_ingreselegajo" runat="server" Text="Ingrese el Legajo del Medico a modificar:"></asp:Label>
                <asp:TextBox ID="TbLegMed" runat="server"></asp:TextBox>
                <asp:Button ID="btn_buscarporlegajo" runat="server" Text="Buscar Medico" OnClick="btn_buscarporlegajo_Click" />
&nbsp;
                <asp:Button ID="btn_filtrartodos" runat="server" Text="Filtrar todos" OnClick="btn_filtrartodos_Click" />
            </p>
            <p>
                <asp:Label ID="lbl_msj" runat="server"></asp:Label>
            </p>
            <p>
                <asp:GridView ID="gv_medicos_Mod" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" Height="134px" Width="16px" style="margin-right: 112px" OnRowCancelingEdit="gv_medicos_Mod_RowCancelingEdit" OnRowEditing="gv_medicos_Mod_RowEditing" OnRowUpdating="gv_medicos_Mod_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gv_medicos_Mod_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre Medico">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtNombre" runat="server" Text='<%# Bind("Nombre") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLNombreMedico" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Medico">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtApellido" runat="server" Text='<%# Bind("Apellido") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLApellidoMedico" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dni">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDNI" runat="server" Text='<%# Bind("Dni") %>' Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDNI" runat="server" Text='<%# Bind("Dni") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="SqlDataSource1" DataTextField="Sexo_med" DataValueField="Sexo_med" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=localhost\sqlexpress;Initial Catalog=ClinicaMedica_G12;Integrated Security=True;Encrypt=True;TrustServerCertificate=True" ProviderName="<%$ ConnectionStrings:ClinicaMedica_G12ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [Sexo_med] FROM [Medico]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLSexoMedico" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtNacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>' Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLNacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtFechaNacimiento" runat="server" Text='<%# Bind("[Fecha de nacimiento]") %>' Width="63px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLNacimiento" runat="server" 
                                    Text='<%# Eval("[Fecha de nacimiento]", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Domicilio">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtDomicilio" runat="server" Text='<%# Bind("Direccion") %>' Width="151px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLDomicilio" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtEmail" runat="server" Text='<%# Bind("[Correo Electronico]") %>' Width="171px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLEmail" runat="server" Text='<%# Bind("[Correo Electronico]") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtTelefono" runat="server" Text='<%# Bind("Telefono") %>' Width="90px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Especialidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" DataSourceID="sdsEspecialidad" DataTextField="ID_Especialidad_med" DataValueField="ID_Especialidad_med" Width="50px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsEspecialidad" runat="server" ConnectionString="Data Source=localhost\sqlexpress;Initial Catalog=ClinicaMedica_G12;Integrated Security=True;Encrypt=True;TrustServerCertificate=True" SelectCommand="SELECT DISTINCT [ID_Especialidad_med] FROM [Medico]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LBLEspecialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtUsuario" runat="server" Text='<%# Bind("Usuario") %>' Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contraseña">
                            <EditItemTemplate>
                                <asp:TextBox ID="EdtClave" runat="server" Text='<%# Bind("Contraseña") %>' Width="80px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblContraseña" runat="server" Text='<%# Bind("Contraseña") %>'></asp:Label>
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
