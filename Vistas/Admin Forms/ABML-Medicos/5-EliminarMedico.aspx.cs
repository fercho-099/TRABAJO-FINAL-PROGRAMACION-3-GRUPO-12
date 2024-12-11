using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms
{
    public partial class EliminarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                lbl_usuarioadmin.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }
        }

        protected void btn_eliminarmedico_Click(object sender, EventArgs e)
        {
            if(txtLegajo.Text.Length != 5)
            {
                lbl_mensaje.Text = "Ingrese un Numero de legajo valido";
                txtLegajo.Text = "";
                return;
            }

            string legajo = txtLegajo.Text;
            
            NegocioMedico negocioMedico = new NegocioMedico();

            try
            {
                bool existeLegajo = negocioMedico.VerificarLegajo(legajo);
                if (existeLegajo)
                {
                    bool baja = negocioMedico.BajaMedico(legajo);
                    if (baja)
                    {
                        lbl_mensaje.Text = " El Medico con legajo "+txtLegajo.Text+" dado de baja con exito";
                        txtLegajo.Text = "";
                    }

                }
                else
                {
                    lbl_mensaje.Text = "El legajo "+txtLegajo.Text +" no se encuentra registrado en la base de datos";
                }
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = "Error al verificar el legajo";
                txtLegajo.Text = "";
            }
        }
    }
}