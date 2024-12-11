using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms
{
    public partial class _4_SeleccionarInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreAdmin"] != null)
                {
                    lblAdminlog.Text = "Administrador, " + Session["NombreAdmin"].ToString();
                }
            }
        }

        protected void BtnTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/5-Informes.aspx");
        }

        protected void BtnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin Forms/6-Informes2.aspx");
        }
    }
}