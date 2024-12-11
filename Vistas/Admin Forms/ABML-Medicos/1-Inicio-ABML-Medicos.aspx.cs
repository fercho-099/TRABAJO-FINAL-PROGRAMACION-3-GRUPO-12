using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms.ABML_Medicos
{
    public partial class Inicio_ABML_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                LblAdministrador.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }
        }

        protected void btnRegistarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Medicos/2-RegistrarMedicos.aspx");
        }

        protected void BtnBuscarMedico_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Admin Forms/ABML-Medicos/3-ListadoMedicos.aspx");
        }

        protected void BtnModificarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Medicos/4-ModificarMedico.aspx");
        }

        protected void BtnEliminarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Medicos/5-EliminarMedico.aspx");
        }
    }
}