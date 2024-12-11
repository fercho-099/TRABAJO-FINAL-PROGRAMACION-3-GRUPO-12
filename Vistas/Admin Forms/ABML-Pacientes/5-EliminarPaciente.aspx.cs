using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms
{
    public partial class EliminarPaciente : System.Web.UI.Page
    {
        NegocioPacientes negocioPaciente = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                lbl_usuarioadmin.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }

        }

        protected void btn_eliminarmedico_Click(object sender, EventArgs e)
        {
            bool dniPaciente = negocioPaciente.validarDniPaciente(txtDniEliminar.Text);

            if (dniPaciente) {
                bool bajaPaciente = negocioPaciente.BajaPaciente(txtDniEliminar.Text);
                if (bajaPaciente) {
                    lbl_mensaje.Text = "El Paciente con el dni " + txtDniEliminar.Text + " dado de baja con exito.";
                    txtDniEliminar.Text = "";
                }
            } else
            {
                lbl_mensaje.Text = "El Dni " +  txtDniEliminar.Text  + " no se encuentra registrado en la base de datos.";
            }

        }
    }
}