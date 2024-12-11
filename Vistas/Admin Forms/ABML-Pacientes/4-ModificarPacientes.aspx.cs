using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms.ABML_Pacientes
{
    public partial class _4_ModificarPacientes : System.Web.UI.Page
    {
        NegocioPacientes negociopacientes = new NegocioPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                lbl_usuarioadministrador.Text = "Admin, " + Session["NombreAdmin"].ToString();
            }

            if (!IsPostBack)
            {
                DataTable Pacientes = negociopacientes.GetPacientes();
                Session["PacientesData"] = Pacientes;
            }
        }

        public void CargarGridView()
        {
            DataTable Pacientes;
            string dniVAR = Session["dniVAR"] != null ? Session["dniVAR"].ToString() : string.Empty;
            if (!string.IsNullOrEmpty(dniVAR) && Session["filtrarTodos"] == null)
            {
                Pacientes = negociopacientes.GetPacientePorDniLike(dniVAR);
                grv_pacientes_mod.DataSource = Pacientes;
                grv_pacientes_mod.DataBind();
            }
            else
            {
                Pacientes = negociopacientes.GetPacientes();
                grv_pacientes_mod.DataSource = Pacientes;
                grv_pacientes_mod.DataBind();
                Session["filtrarTodos"] = null;
                Session["dniVAR"] = null;
            }
        }

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            string dni = tbDniPaciente.Text;

            try 
            {
                if (string.IsNullOrEmpty(dni))
                {
                    lbl_msj.ForeColor = System.Drawing.Color.Red;
                    lbl_msj.Text = "Por favor, ingrese un DNI para buscar.";
                    grv_pacientes_mod.DataSource = null;
                    grv_pacientes_mod.DataBind();
                    return;
                }

                DataTable Pacientes = negociopacientes.ObtenerPacientesPorDni(dni);
                if (Pacientes.Rows.Count > 0)
                {
                    Session["PacientesData"] = Pacientes;
                    Session["dniVAR"] = dni;
                    grv_pacientes_mod.DataSource = Pacientes;
                    grv_pacientes_mod.DataBind();
                    lbl_msj.Text = "";
                    tbDniPaciente.Text = "";
                }
                else
                {
                    lbl_msj.Text = "No se encontraron pacientes con el dni ingresado.";
                    tbDniPaciente.Text = "";
                    grv_pacientes_mod.DataSource = null;
                    grv_pacientes_mod.DataBind();

                }
            }
            catch (Exception ex)
            {
                lbl_msj.ForeColor = System.Drawing.Color.Red;
                lbl_msj.Text = "Error al intentar traer listados de los pacientes: ";
            }
        }

        protected void grv_pacientes_mod_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grv_pacientes_mod.EditIndex = e.NewEditIndex;
            CargarGridView();

        }

        protected void grv_pacientes_mod_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grv_pacientes_mod.EditIndex = -1;
            CargarGridView();
        }

        protected void grv_pacientes_mod_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)grv_pacientes_mod.Rows[e.RowIndex].FindControl("lbl_ei_dni_paciente")).Text;
            string nombre = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("txt_ei_nombre")).Text;
            string apellido = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("txt_ei_apellido")).Text;
            string sexo = ((DropDownList)grv_pacientes_mod.Rows[e.RowIndex].FindControl("ddlSexo")).SelectedValue;
            string nacionalidad = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("txt_ei_nacionalidad")).Text;
            string fechaTexto = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("tbEditFecha")).Text;
            DateTime fechanac;
            if (!DateTime.TryParse(fechaTexto, out fechanac))
            {
                throw new Exception("La fecha no es válida");
            }
            int Id_domicilio = 1;
            string correo = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("txt_ei_correo")).Text;
            string telefono = ((TextBox)grv_pacientes_mod.Rows[e.RowIndex].FindControl("txt_ei_telefono")).Text;
            int estado =1;

            Entidades.Pacientes pacienteMod = Entidades.Pacientes.AgregarPacientes(dni, nombre, apellido, sexo, nacionalidad, fechanac, Id_domicilio, correo, telefono, estado);
            negociopacientes.ModificarPaciente(pacienteMod);

            grv_pacientes_mod.EditIndex = -1;
            CargarGridView();

        }

        protected void btn_filtrartodos_Click(object sender, EventArgs e)
        {
            CargarGridView();
            Session["filtrarTodos"] = true;

        }

        protected void grv_pacientes_mod_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_pacientes_mod.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}