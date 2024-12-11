using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms.ABML_Pacientes
{
    public partial class Inicio_ABML_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                LblAdministrador.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }

        }

        protected void btnRegistarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Pacientes/2-RegistrarPacientes.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Pacientes/3-ListadoPacientes.aspx");
        }

        protected void BtnModificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Pacientes/4-ModificarPacientes.aspx");
        }

        protected void BtnBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Pacientes/5-EliminarPaciente.aspx");
        }
    }
}