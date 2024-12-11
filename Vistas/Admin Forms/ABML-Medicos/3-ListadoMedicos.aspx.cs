using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas.Admin_Forms.ABML_Medicos
{
    public partial class ListadoMedicos : System.Web.UI.Page
    {
        NegocioMedico negocioMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["NombreAdmin"] != null)
            {
                lbl_usuarioadministrador.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }

            DataTable Medicos = negocioMedico.GetMedicos();
            grv_medicos.DataSource = Medicos;
            grv_medicos.DataBind();


           
        }
    


        protected void btn_filtrartodos_Click(object sender, EventArgs e)
        {
            DataTable Medicos = negocioMedico.GetMedicos();
            grv_medicos.DataSource = Medicos;
            grv_medicos.DataBind();
            txt_legajomedico.Text = "";
        }

        protected void btn_buscarporlegajo_Click1(object sender, EventArgs e)
        {
            string legajo = txt_legajomedico.Text.Trim();
         
            try
            {
                DataTable Medicos = negocioMedico.GetMedicoPorLegajoLike(legajo);
                if (Medicos.Rows.Count > 0)
                {
                    grv_medicos.DataSource = Medicos;
                    grv_medicos.DataBind();
                    txt_legajomedico.Text = "";
                    lbl_msj.Text = "";

                }
                else
                {
                    lbl_msj.Text = "No se encontraron Medicos con el legajo ingresado.";
                    txt_legajomedico.Text = "";
                }
            }
            catch
            {
                lbl_msj.Text = "Error al intentar traer los listados de los medicos.";
            }


        }

        protected void grv_medicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_medicos.PageIndex = e.NewPageIndex;
            DataTable Medicos = negocioMedico.GetMedicos();
            grv_medicos.DataSource = Medicos;
            grv_medicos.DataBind();
        }
    }
}