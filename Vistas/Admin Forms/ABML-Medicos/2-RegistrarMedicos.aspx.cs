using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Dao;



namespace Vistas
{
    public partial class Medicos : System.Web.UI.Page
    {
        Entidades.Medicos medico = new Entidades.Medicos();
        NegocioProvincias negocioprovincias = new NegocioProvincias();
        NegocioMedico negociomedico = new NegocioMedico();
        NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioDias negocioDias = new NegocioDias();
        NegocioHorarios negocioHorarios = new NegocioHorarios();
        NegocioDomicilio negocioDomicilio = new NegocioDomicilio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CacheDatos.PrecargarDatos();


                //Cargar provincias
                ddl_provincias.DataSource = CacheDatos.Provincias;
                ddl_provincias.DataTextField = "Nombre_prov";
                ddl_provincias.DataValueField = "ID_Prov";
                ddl_provincias.DataBind();
                ddl_provincias.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));

                //Cargar localidades
                ddl_localidades.DataSource = CacheDatos.Localidades;
                ddl_localidades.DataTextField = "Nombre_loc";
                ddl_localidades.DataValueField = "ID_Loc";
                ddl_localidades.DataBind();
                ddl_localidades.Items.Insert(0, new ListItem("Seleccione una Localidad", "0"));

                //Cargar especialidad
                DataTable tablaEspecialidad = negocioEspecialidad.GetEspecialidad();
                ddlEspecialidad.DataSource = tablaEspecialidad;
                ddlEspecialidad.DataTextField = "Nombre_espec";
                ddlEspecialidad.DataValueField = "ID_Espec";
                ddlEspecialidad.DataBind();

                //Cargar días
                DataTable tablaDias = negocioDias.getDias();
                checkDias.DataSource = tablaDias;
                checkDias.DataTextField = "Nombre_dia";
                checkDias.DataValueField = "ID_Dia";
                checkDias.DataBind();

                //Cargar horarios
                DataTable tablaHorarios = negocioHorarios.getHorarios();
                checkHorarios.DataSource = tablaHorarios;
                checkHorarios.DataTextField = "RangoHorario";
                checkHorarios.DataValueField = "ID_Horario";
                checkHorarios.DataBind();
            }

            if (Session["NombreAdmin"] != null)
            {
                LblAdministrador.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }

        }

        protected void btnRegistrarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                string legajo = txtLegajo.Text.Trim();
                string direccion = txtDireccion.Text.Trim(); // Cambiado a string
                string dni = txtDni.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string nacionalidad = txtNacionalidad.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string usuario = txtUsuario.Text.Trim();
                string contrasenia = txtContrasenia.Text.Trim();

                // Obtener la provincia seleccionada
                if (!int.TryParse(ddl_provincias.SelectedValue, out int provinciaId) || provinciaId == 0)
                {
                    lbl_mensajemedicos.Text = "Debe seleccionar una provincia válida.";
                    return;
                }

                // Obtener la localidad seleccionada
                if (!int.TryParse(ddl_localidades.SelectedValue, out int localidadId) || localidadId == 0)
                {
                    lbl_mensajemedicos.Text = "Debe seleccionar una localidad válida.";
                    return;
                }

                if (!negociomedico.VerificarLegajo(legajo))
                {
                    // Validar y convertir fecha de nacimiento
                    if (!DateTime.TryParse(txtNacimiento.Text, out DateTime fechaNacimiento))
                    {
                        lbl_mensajemedicos.Text = "Fecha de nacimiento inválida.";
                        return;
                    }

                    // Obtener especialidad desde DropDownList
                    if (!int.TryParse(ddlEspecialidad.SelectedValue, out int especialidadId))
                    {
                        lbl_mensajemedicos.Text = "Debe seleccionar una especialidad válida.";
                        return;
                    }

                    // Obtener el sexo seleccionado
                    string sexoSeleccionado = medico.SexoSeleccionado(rbMujer, rbHombre);

                    // Obtener ID de domicilio con provincia y localidad
                    int domicilioId = negocioDomicilio.GetIdDomicilio(provinciaId, localidadId, direccion);

                    // Crear el objeto médico
                    Entidades.Medicos datos = Entidades.Medicos.AgregarMedicos(
                        legajo, dni, nombre, apellido, sexoSeleccionado, nacionalidad, fechaNacimiento,
                        correo, telefono, especialidadId, usuario, contrasenia, 1, domicilioId
                    );

                    datos.setDomicilio(domicilioId);

                    // Guardar el médico
                    if (negociomedico.guardarMedico(datos))
                    {
                        lbl_mensajemedicos.Text = "Médico registrado exitosamente.";
                        LimpiarCampos();
                    }
                    else
                    {
                        lbl_mensajemedicos.Text = "Ocurrió un error al guardar el médico.";
                    }
                }
                else
                {
                    lbl_mensajemedicos.Text = "Error: Medico ya existente con el mismo legajo.";
                }
            }
            catch (Exception ex)
            {
                lbl_mensajemedicos.Text = "Error en la carga del médico: " + ex.Message;
            }
        }
            private void LimpiarCampos()
            {
            txtLegajo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            txt_repetircontraseña.Text = "";
            ddl_provincias.SelectedIndex = 0;
            ddl_localidades.SelectedIndex = 0;
            rbHombre.Checked = false;
            rbMujer.Checked = false;
            }

    }


}



