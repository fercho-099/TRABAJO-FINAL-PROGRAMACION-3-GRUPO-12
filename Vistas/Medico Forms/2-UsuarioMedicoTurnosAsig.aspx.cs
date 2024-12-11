using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;
using Entidades;

namespace Vistas
{
    public partial class UsuarioMedicoLogueado : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MedicoNombreLogeado"] != null)
            {
                lblMedicoLog.Text = "Medico, " + Session["MedicoNombreLogeado"].ToString();

            }
            else
            {
                Response.Redirect("1-LoginMedico");
            }

            if (!IsPostBack)
            {
                DataTable Turnos = negocioTurno.ObtenerEstadoTurnos();
                Session["TurnosData"] = Turnos;
            }
        }

        protected void btn_buscarpaciente_Click(object sender, EventArgs e)
        {
            string legajoMed = Session["LegajoMedico"].ToString();
            string dni = txt_buscarPorDni.Text.Trim();

            try
            {
                DataTable turnosFiltrados = negocioTurno.ObtenerTurnosPorDni(dni, legajoMed);

                if (turnosFiltrados.Rows.Count > 0)
                {
                    Session["TurnosData"] = turnosFiltrados;
                    Session["dniVAR"] = dni;
                    Gv_Turnos.DataSource = turnosFiltrados;
                    Gv_Turnos.DataBind();
                    lbl_busqueda_pordni.Text = "Ingrese DNI del paciente:";
                    lblError.Text = "";
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    Gv_Turnos.DataSource = negocioTurno.ObtenerTurnosPorLegajo(Session["LegajoMedico"].ToString());
                    lblError.Text = "No se encontraron turnos para el DNI ingresado.";
                    Gv_Turnos.DataSource = null;
                    Gv_Turnos.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al intentar traer listados de los médicos: ";
            }
        }


        void CargarGridViewTurnos()
        {
            string legajoMed = Session["LegajoMedico"].ToString();
            DataTable Turnos;
            string dniVAR = Session["dniVAR"] != null ? Session["dniVAR"].ToString() : string.Empty;
            if (!string.IsNullOrEmpty(dniVAR) && Session["MostrarTodos"] == null)
            {
                Turnos = negocioTurno.ObtenerTurnosPorDni(dniVAR, legajoMed);
                Gv_Turnos.DataSource = Turnos;
                Gv_Turnos.DataBind();
            }
            else
            {
                Turnos = negocioTurno.ObtenerTurnosPorLegajo(legajoMed);
                Gv_Turnos.DataSource = Turnos;
                Gv_Turnos.DataBind();
                Session["MostrarTodos"] = null;
                Session["dniVAR"] = null;
            }
        }

        protected void Gv_Turnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_Turnos.EditIndex = e.NewEditIndex;
            CargarGridViewTurnos();
        }

        protected void Gv_Turnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_Turnos.EditIndex = -1;
            CargarGridViewTurnos();
        }

        protected void Gv_Turnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_estado = (Label)e.Row.FindControl("lbl_estado");
                DropDownList ddl_estado = (DropDownList)e.Row.FindControl("ddl_ei_estado");

                string estadoTurno = DataBinder.Eval(e.Row.DataItem, "Estado_turn").ToString();

                if (ddl_estado != null)
                {
                    DataTable NombreEstadoTurnos = negocioTurno.ObtenerEstadoTurnos();
                    ddl_estado.DataSource = NombreEstadoTurnos;
                    ddl_estado.DataTextField = "Nombre_Estado";
                    ddl_estado.DataValueField = "Id_Estado";
                    ddl_estado.DataBind();
                    ddl_estado.SelectedValue = estadoTurno;
                }

                if (lbl_estado != null)
                {

                    if (lbl_estado.Text == "1")
                    {
                        lbl_estado.Text = "Presente";
                    }
                    else
                    {
                        lbl_estado.Text = "Ausente";
                    }
                }
            }
        }

        protected void Gv_Turnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int idTurno = Convert.ToInt32(((Label)Gv_Turnos.Rows[e.RowIndex].FindControl("lbl_ei_IdTurno")).Text);
            int estado = Convert.ToInt32(((DropDownList)Gv_Turnos.Rows[e.RowIndex].FindControl("ddl_ei_estado")).SelectedValue);
            string observacion = ((TextBox)Gv_Turnos.Rows[e.RowIndex].FindControl("txt_ei_observacion")).Text;



            negocioTurno.ModificarTurno(idTurno, estado, observacion);

            Gv_Turnos.EditIndex = -1;
            CargarGridViewTurnos();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("MedicoNombreLogeado");
            Response.Redirect("1-LoginMedico.aspx");
        }

        protected void btn_buscarTodos_Click(object sender, EventArgs e)
        {
            Session["MostrarTodos"] = true;
            CargarGridViewTurnos();
            lblError.Text = "";
        }
    }
}