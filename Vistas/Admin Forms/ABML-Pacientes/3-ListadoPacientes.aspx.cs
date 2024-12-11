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
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        NegocioPacientes negociopacientes = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["NombreAdmin"] != null)
            {
                lbl_usuarioadministrador.Text = "Admin, " + Session["NombreAdmin"].ToString();
            }

            DataTable Pacientes = negociopacientes.GetPacientes();
            grv_pacientes.DataSource = Pacientes;
            grv_pacientes.DataBind();
        }

        protected void btn_buscarpordni_Click1(object sender, EventArgs e)
        {
            string dni = txtDniPaciente.Text;
            try
            {
                DataTable Pacientes = negociopacientes.GetPacientePorDniLike(dni);
                if (Pacientes.Rows.Count > 0)
                {
                    grv_pacientes.DataSource = Pacientes;
                    grv_pacientes.DataBind();
                    lbl_msj.Text = "";
                    txtDniPaciente.Text = "";
                }
                else
                {
                    lbl_msj.ForeColor = System.Drawing.Color.Red;
                    lbl_msj.Text = "No se encontraron pacientes con el dni ingresado.";
                    txtDniPaciente.Text = "";
                }
            }
            catch (Exception ex)
            {
                lbl_msj.ForeColor = System.Drawing.Color.Red;
                lbl_msj.Text = "Error al intentar traer listados de los pacientes: " + ex.Message;
            }
        }

        protected void btn_filtrartodos_Click(object sender, EventArgs e)
        {
            DataTable Pacientes = negociopacientes.GetPacientes();
            grv_pacientes.DataSource = Pacientes;
            grv_pacientes.DataBind();
            txtDniPaciente.Text = "";
            lbl_msj.Text = "";
        }

        protected void grv_pacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_pacientes.PageIndex = e.NewPageIndex;
            DataTable Pacientes = negociopacientes.GetPacientes();
            grv_pacientes.DataSource = Pacientes;
            grv_pacientes.DataBind();
        }
    }   
}