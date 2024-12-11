using Dao;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Pacientes : System.Web.UI.Page
    {
        NegocioProvincias negocioprovincias = new NegocioProvincias();
        NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
        NegocioDomicilio negociodomicilio = new NegocioDomicilio();
        NegocioPacientes negociopacientes = new NegocioPacientes();
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

                if (Session["NombreAdmin"] != null)
                {
                    LblAdministrador.Text = "Administrador, " + Session["NombreAdmin"].ToString();
                }

            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = TxtDni.Text;
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string sexo = rbHombre.Checked ? "Masculino" : "Femenino";
                string nacionalidad = TxtNacionalidad.Text;
                DateTime fechanac = DateTime.Parse(TxtNacimiento.Text);
                string direccion = TxtDireccion.Text;
                int idprovincia = int.Parse(ddl_provincias.SelectedValue);
                int idlocalidad = int.Parse(ddl_localidades.SelectedValue);
                string correo = TxtEmail.Text;
                string telefono = TxtTelefono.Text;
                int estado = 1;


                string msj = "";
                bool campovalido = true;
                campovalido &= ValidarCampoNoVacio(nombre,"Nombre", ref msj);
                campovalido &= ValidarCampoNoVacio(apellido, "Apellido", ref msj);
                campovalido &= ValidarCampoNoVacio(dni,"Dni", ref msj);
                campovalido &= ValidarCampoNoVacio(nacionalidad, "Nacionalidad", ref msj);
                campovalido &= ValidarCampoNoVacio(direccion, "Direccion", ref msj);
                campovalido &= ValidarCampoNoVacio(correo, "Email", ref msj);
                campovalido &= ValidarNumeroTel(telefono, ref msj);
                campovalido &= ValidarDropDownList(idprovincia, "Provincia", ref msj);
                campovalido &= ValidarDropDownList(idlocalidad, "Localidad", ref msj);


                if (negociopacientes.ExistePaciente(dni))
                {

                    lbl_mensajepacientes.Text = "Error: Paciente ya existente con el mismo DNI.";
         
                }
                else if(campovalido)
                {
                    int Id_domicilio = negociodomicilio.GetIdDomicilio(idprovincia, idlocalidad,direccion);
                    Entidades.Pacientes nuevopaciente = Entidades.Pacientes.AgregarPacientes(dni, nombre, apellido, sexo, nacionalidad, fechanac, Id_domicilio, correo, telefono, estado);
                    negociopacientes.AltaPaciente(nuevopaciente);
                    lbl_mensajepacientes.Text = "Paciente registrado exitosamente.";
                    LimpiarCampos();
                }
                else
                {
                    lbl_mensajepacientes.Text = msj;
                }
            }
            catch
            {
                lbl_mensajepacientes.Text = "Error, el Paciente no pudo ser agregado, complete todos los campos.";
                
            }
        }
        private bool ValidarCampoNoVacio(string valor, string nombreCampo, ref string mensaje)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                mensaje += $"El campo {nombreCampo} no puede estar vacío. ";
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            TxtDni.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtNacionalidad.Text = "";
            TxtNacimiento.Text = "";
            TxtDireccion.Text = "";
            TxtEmail.Text = "";
            TxtTelefono.Text = "";
            ddl_localidades.SelectedIndex = 0;
            ddl_provincias.SelectedIndex = 0;
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }
        private bool ValidarNumeroTel(string telefono, ref string mensaje)
        {
            string expresionregular = @"^\d{10}$";
            mensaje += $"El campo Telefono debe contener 10 digitos. ";
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, expresionregular);
        }
        private bool ValidarDropDownList(int valorseleccionado,string nombrecampo,ref string mensaje)
        {
            if(valorseleccionado == 0)
            {
                mensaje+= $"Seleccione una {nombrecampo} valida del desplegable. ";
                return false;
            }
            return true;
        
        }




    }
}