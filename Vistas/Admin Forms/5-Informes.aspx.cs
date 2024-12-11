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
    public partial class Informes : System.Web.UI.Page
    {
       NegocioTurno negocioturno = new NegocioTurno();
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
            if(!DateTime.TryParse(txt_fechainicio.Text, out DateTime fechaInicio))
                {
                lbl_cantidadturnos.Text = "La fecha de inicio no es válida. Use el formato dd/mm/aaaa.";
                return;
            }

            if (!DateTime.TryParse(txt_fechafinal.Text, out DateTime fechaFin))
            {
                lbl_cantidadturnos.Text = "La fecha de fin no es válida. Use el formato dd/mm/aaaa.";
                return;
            }

            DateTime fechainicio = DateTime.Parse(txt_fechainicio.Text);
            DateTime fechafinal = DateTime.Parse(txt_fechafinal.Text);
            TurnosReporte reporte = negocioturno.GetTurnosParaInforme(fechainicio, fechafinal);
            List<TurnosReporteNombre> turnNom = negocioturno.GetTurnosParaInformeNombre(fechainicio, fechafinal);
            if (reporte.TotalTurnos != 0)
            {
                lbl_cantidadturnos.Text = "Cantidad de turnos entre las fechas: " + reporte.TotalTurnos;
                lbl_cantidadturnospresentes.Text = "Cantidad de pacientes presentes: " + reporte.CantidadPresentes;
                lbl_cantidadturnosausentes.Text = "Cantidad de pacientes ausentes: " + reporte.CantidadAusentes;
                lbl_porcentajeturnospresentes.Text = "Porcentaje de pacientes presentes: " + reporte.PorcentajePresentes + "%";
                lbl_porcentajeturnosausentes.Text = "Porcentaje de pacientes ausentes: " + reporte.PorcentajeAusentes + "%";

                string informe = "Pacientes Presentes: </br>";
                bool primero = true;
                foreach (var datos in turnNom)
                {
                    if(datos.Estado ==1)
                    {
                        if (!primero)
                        {
                            informe += ", ";
                        }
                        informe += $"{datos.nombre} {datos.apellido}\n";
                        primero = false;
                    }
                }

                informe += "</br> Pacientes Ausentes: </br>";
                primero = true;
                foreach (var datos2 in turnNom)
                {
                    if(datos2.Estado ==0)
                    {
                        if (!primero)
                        {
                            informe += ", ";
                        }
                        informe += $"{datos2.nombre} {datos2.apellido}";
                        primero = false;
                    }
                }
                Lbl_PacientesInformes.Text = informe;

            }
            else
            {
                lbl_cantidadturnos.Text = "No se encontraron turnos asignados entre las fechas ingresadas.";
            }
        }
    }
}