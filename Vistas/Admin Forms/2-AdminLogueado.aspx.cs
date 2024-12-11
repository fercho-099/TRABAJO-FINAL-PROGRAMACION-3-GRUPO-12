using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AdminLogueado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                lblAdminlog.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            } else
            {
                {
                    Response.Redirect("1-LoginAdmin");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("NombreAdmin");
            Response.Redirect("1-LoginAdmin.aspx");
        }

        protected void BtnPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Pacientes/1-Inicio-ABML-Pacientes.aspx");
        }

        protected void BtnMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/ABML-Medicos/1-Inicio-ABML-Medicos.aspx");
        }

        protected void BtnTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/3-AsignarTurno.aspx");
        }

        protected void BtnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/4-Seleccionarinforme.aspx");
        }
    }
}