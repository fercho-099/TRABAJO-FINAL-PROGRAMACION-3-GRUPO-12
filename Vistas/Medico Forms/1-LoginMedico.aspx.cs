using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class UsuarioMedico : System.Web.UI.Page
    {
        NegocioLogin negocioLogin = new NegocioLogin();
        NegocioMedico negocioMedico = new NegocioMedico();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresarMedico_Click(object sender, EventArgs e)
        {
            String nombreMedico = negocioLogin.LoginMedic(txtUsuarioMed.Text, txtClaveMedico.Text);

            if (!string.IsNullOrEmpty(nombreMedico))
            {
               
                txtErrorCredenciales.Text = "";
                String legajoMedico = negocioMedico.GetLegajoMedico(nombreMedico, txtUsuarioMed.Text);
                Session["MedicoNombreLogeado"] = nombreMedico;
                Session["LegajoMedico"] = legajoMedico;
                Response.Redirect("2-UsuarioMedicoTUrnosAsig.aspx");
            }
            else
            {
                txtErrorCredenciales.Text = "Las credenciales son Incorrectas";
            }
        }
    }
}