using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms
{
    public partial class _6_Informes2 : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreAdmin"] != null)
                {
                    lbl_usuario.Text = "Administrador, " + Session["NombreAdmin"].ToString();
                }
            }
        }

        protected void btn_generarinforme_Click(object sender, EventArgs e)
        {
            try
            {


                // Validar fechas ingresadas
                if (!DateTime.TryParse(txt_fechainicio.Text, out DateTime fechaInicio))
                {
                    lbl_resultado.Text = "La fecha de inicio no es válida. Use el formato dd/mm/aaaa.";
                    return;
                }

                if (!DateTime.TryParse(txt_fechafinal.Text, out DateTime fechaFin))
                {
                    lbl_resultado.Text = "La fecha de fin no es válida. Use el formato dd/mm/aaaa.";
                    return;
                }

                List<TurnosPorEspecialidad> listaTurnos = negocioTurno.ObtenerTurnosPorEspecialidad(fechaInicio, fechaFin);

                if (listaTurnos.Count == 0 || (listaTurnos.Count == 1 && listaTurnos[0].Especialidad == "Sin registros"))
                {
                    lbl_resultado.Text = "No se encontraron turnos en el rango de fechas especificado.";

                    grv_informe.DataSource = null;
                    grv_informe.DataBind();
                }
                else
                {
                   
                    grv_informe.DataSource = listaTurnos;
                    grv_informe.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbl_resultado.Text = "Error al generar el informe: " + ex.Message;

            }
        }
    }
}