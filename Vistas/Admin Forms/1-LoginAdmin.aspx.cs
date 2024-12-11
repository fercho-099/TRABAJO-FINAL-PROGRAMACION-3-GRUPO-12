using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class UsuarioAdministrador : System.Web.UI.Page
    {
        NegocioLogin negocioLogin = new NegocioLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            String nombreAdmin = negocioLogin.LoginAdmin(txtUsuarioAdmin.Text, txtClaveAdmin.Text);

            if (!string.IsNullOrEmpty(nombreAdmin))
            {
                txtErrorCredenciales.Text = "";
                Session["NombreAdmin"] = nombreAdmin;
                Response.Redirect("2-AdminLogueado.aspx");
            }
            else
            {
                txtErrorCredenciales.Text = "Las credenciales son Incorrectas";
            }

        }
    }
}