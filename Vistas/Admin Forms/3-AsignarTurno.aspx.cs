using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Admin_Forms
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioCalendario negocioCalendario = new NegocioCalendario();
        NegocioPacientes negocioPacientes = new NegocioPacientes();
        NegocioTurno negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Cargar especialidad
                DataTable tablaEspecialidad = negocioEspecialidad.GetEspecialidad();
                ddlEspecialidad.DataSource = tablaEspecialidad;
                ddlEspecialidad.DataTextField = "Nombre_espec";
                ddlEspecialidad.DataValueField = "ID_Espec";
                ddlEspecialidad.DataBind();

                if (ddlEspecialidad.Items.Count > 0)
                {
                    ddlEspecialidad.SelectedIndex = 0;
                    ddlEspecialidad_SelectedIndexChanged(ddlEspecialidad, EventArgs.Empty);
                }

                if (Session["NombreAdmin"] != null)
                {
                    lblAdminlog.Text = "Administrador, " + Session["NombreAdmin"].ToString();
                }
            }
        }

        //Cargar medico
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Especialidad = int.Parse(ddlEspecialidad.SelectedValue);
            DataTable tablaNombreMedico = negocioMedico.GetMedicoEspecialidad(Especialidad);
            ddlMedico.DataSource = tablaNombreMedico;
            ddlMedico.DataTextField = "Nombre_med";
            ddlMedico.DataValueField = "Legajo_med";
            ddlMedico.DataBind();

            if (ddlMedico.Items.Count > 0)
            {
                ddlMedico.SelectedIndex = 0; // Selecciona automáticamente el único ítem
                ddlMedico_SelectedIndexChanged1(ddlMedico, EventArgs.Empty); // Dispara manualmente el evento
            }

        }

        //Cargar Dia
        protected void ddlMedico_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string legajo = ddlMedico.SelectedValue;
            DataTable tablaDias = negocioMedico.GetDiaMedico(legajo);
            ddlDia.DataSource = tablaDias;
            ddlDia.DataTextField = "Nombre_dia";
            ddlDia.DataValueField = "ID_Dia";
            ddlDia.DataBind();

            if (ddlDia.Items.Count > 0)
            {
                ddlDia.SelectedIndex = 0; // Selecciona automáticamente el único ítem
                ddlDia_SelectedIndexChanged(ddlDia, EventArgs.Empty); // Dispara manualmente el evento
            }
        }


        //Cargar Horario
        protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string legajo = ddlMedico.SelectedValue;
            int idDia = int.Parse(ddlDia.SelectedValue);
            DataTable tablaHorarios = negocioMedico.GetHorarioMedico(legajo, idDia);
            ddlHorario.DataSource = tablaHorarios;
            ddlHorario.DataTextField = "RangoHorario";
            ddlHorario.DataValueField = "ID_DiasXHorario_mdh";
            ddlHorario.DataBind();

            if (ddlHorario.Items.Count > 0)
            {   
                ddlHorario.SelectedIndex = 0; // Selecciona automáticamente el único ítem
                ddlHorario_SelectedIndexChanged(ddlHorario, EventArgs.Empty); // Dispara manualmente el evento
            }
        }

        //Cargar Fechas Disponibles
        protected void ddlHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string legajo = ddlMedico.SelectedValue;
            int idDxH = int.Parse(ddlHorario.SelectedValue);
            DataTable tablaFechas = negocioCalendario.GetFechas(legajo, idDxH);
            ddlFechas.DataSource = tablaFechas;
            ddlFechas.DataTextField = "Fecha_cal";
            ddlFechas.DataValueField = "Fecha_cal";
            ddlFechas.DataBind();
        }


        protected void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (negocioPacientes.ExistePaciente(txtDniPaciente.Text))
                {
                    string fechaTurno = ddlFechas.SelectedValue;
                    int idDxH = int.Parse(ddlHorario.SelectedValue);
                    string legajoMed = ddlMedico.SelectedValue;

                    if (!negocioCalendario.VerificarTurno(fechaTurno, idDxH, legajoMed))
                    {
                        string dniPacTurn = txtDniPaciente.Text;

                        Turnos turno = Turnos.AgregarTurno(dniPacTurn, idDxH, fechaTurno, legajoMed);
                        negocioTurno.AltaTurno(turno);

                        lbl_mensajeaclaratorio.Text = "Turno registrado con exito";
                        txtDniPaciente.Text = "";
                    }
                    else
                    {
                        lbl_mensajeaclaratorio.Text = "Error. El turno ya está registrado";
                    }
                }
                else
                {
                    lbl_mensajeaclaratorio.Text = "Error. El paciente no está registrado";
                    txtDniPaciente.Text = " ";
                }


            }
            catch (Exception ex)
            {
                lbl_mensajeaclaratorio.Text = "Error al registrar el turno: " + ex.Message;
            }
        }


    }
}