using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using static System.Net.Mime.MediaTypeNames;


namespace Vistas.Admin_Forms.ABML_Medicos
{
    public partial class _4_ModificarMedico : System.Web.UI.Page
    {
        NegocioMedico datos = new NegocioMedico();
        NegocioDomicilio domicilio = new NegocioDomicilio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreAdmin"] != null)
            {
                lblAdminlog.Text = "Administrador, " + Session["NombreAdmin"].ToString();
            }

            if (!IsPostBack)
            {
                DataTable medicos = datos.GetMedicos();
                Session["MedicosData"] = medicos;
            }

        }

        public void CargarGridView()
        {
            DataTable Medicos;
            string legajoVAR = Session["legajoVAR"] != null ? Session["legajoVAR"].ToString() : string.Empty;
            if (!string.IsNullOrEmpty(legajoVAR) && Session["FiltrarTodos"] == null)
            {
                Medicos = datos.GetMedicoPorLegajo(legajoVAR);
                gv_medicos_Mod.DataSource = Medicos;
                gv_medicos_Mod.DataBind();
            }
            else
            {
                Medicos = datos.GetMedicos();
                gv_medicos_Mod.DataSource = Medicos;
                gv_medicos_Mod.DataBind();
                Session["filtrarTodos"] = null;
                Session["legajoVAR"] = null;
            }
        }

        protected void btn_buscarporlegajo_Click(object sender, EventArgs e)
        {
            string legajo = TbLegMed.Text;

            try
            {
                DataTable Medicos = datos.GetMedicoPorLegajo(legajo);
                if (Medicos.Rows.Count > 0)
                {
                    Session["MedicosData"] = Medicos;
                    Session["legajoVAR"] = legajo;
                    gv_medicos_Mod.DataSource = Medicos;
                    gv_medicos_Mod.DataBind();
                    lbl_msj.Text = "";
                    TbLegMed.Text = "";
                }
                else
                {
                    lbl_msj.ForeColor = System.Drawing.Color.Red;
                    lbl_msj.Text = "No se encontraron médicos con el legajo ingresado.";
                    TbLegMed.Text = "";
                    gv_medicos_Mod.DataSource = null;
                    gv_medicos_Mod.DataBind();

                }
            }
            catch (Exception ex)
            {
                lbl_msj.ForeColor = System.Drawing.Color.Red;
                lbl_msj.Text = "Error al intentar traer listados de los médicos: ";
            }
        }

        protected void gv_medicos_Mod_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_medicos_Mod.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        protected void gv_medicos_Mod_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_medicos_Mod.EditIndex = -1;
            CargarGridView();
        }

        protected void gv_medicos_Mod_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable medicos = (DataTable)Session["MedicosData"];
            DataRow row = medicos.Rows[e.RowIndex];
          
            string LegajoMed = Convert.ToString(row["Legajo"]);
            string Nombremed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtNombre")).Text;
            string ApellidoMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtApellido")).Text;
            string dniMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("txtDNI")).Text;
            string sexoMed = ((DropDownList)gv_medicos_Mod.Rows[e.RowIndex].FindControl("ddlSexo")).SelectedValue;
            string NacionaMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtNacionalidad")).Text;
            string fechaTexto = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtFechaNacimiento")).Text;
            DateTime FechaNacMed;
            if (!DateTime.TryParse(fechaTexto, out FechaNacMed))
            {
                throw new Exception("La fecha no es válida");
            }
            int idDomicilio = Convert.ToInt32(row["ID_Dom"]);
            string nuevoDomicilio = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtDomicilio")).Text;
            string EmailMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtEmail")).Text;
            string telefonoMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtTelefono")).Text;
            string ddlEspecialidad = ((DropDownList)gv_medicos_Mod.Rows[e.RowIndex].FindControl("ddlEspecialidad")).SelectedValue;
            int especialidad;
            int.TryParse(ddlEspecialidad, out especialidad);
            string usuarioMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtUsuario")).Text;
            string ClaveMed = ((TextBox)gv_medicos_Mod.Rows[e.RowIndex].FindControl("EdtClave")).Text;
            int estadoMed = Convert.ToInt32(row["Estado"]);

            Entidades.Medicos medicoMod = Entidades.Medicos.AgregarMedicos(LegajoMed, dniMed, Nombremed, ApellidoMed, sexoMed, NacionaMed, FechaNacMed, EmailMed, telefonoMed, especialidad, usuarioMed, ClaveMed, estadoMed, idDomicilio);
            datos.ModificarMedico(medicoMod);
            domicilio.ModificarDomicilio(idDomicilio, nuevoDomicilio);

            gv_medicos_Mod.EditIndex = -1;
            CargarGridView();
        }

        protected void btn_filtrartodos_Click(object sender, EventArgs e)
        {
            Session["filtrarTodos"] = true;
            CargarGridView();

            lbl_msj.Text = " ";
        }

        protected void gv_medicos_Mod_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_medicos_Mod.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}