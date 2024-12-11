using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoTurnos daoTurnos = new DaoTurnos();

        public void AltaTurno(Turnos turno)
        {
            if (!this.daoTurnos.CargarTurno(turno)) throw new Exception("No se pudo cargar el turno");
        }
        public TurnosReporte GetTurnosParaInforme(DateTime fechainicio,DateTime fechafin)
        {
            return daoTurnos.ObtenerTurnosParaInforme(fechainicio, fechafin);
        }

        public List<TurnosReporteNombre> GetTurnosParaInformeNombre(DateTime fechainicio, DateTime fechafin)
        {
            return daoTurnos.ObtenerTurnosParaInformeNombre(fechainicio, fechafin);
        }

        public DataTable ObtenerTurnosPorLegajo(string legajoMed)
        {
            return daoTurnos.ObtenerTurnosPorLegajo(legajoMed);
        }

        public bool ModificarTurno(int idTurno, int estado, string observacion)
        {
            return daoTurnos.ModificarTurno(idTurno, estado, observacion);
        }

      
        public DataTable ObtenerEstadoTurnos()
        {
            return daoTurnos.ObtenerTurnosPorLegajo();
        }

        public DataTable ObtenerTurnosPorDni(string dni, string legajoMed)
        {
            return daoTurnos.ObtenerTurnosPorDni(dni, legajoMed);

        }
        public List<TurnosPorEspecialidad> ObtenerTurnosPorEspecialidad(DateTime fechaInicio, DateTime fechaFin)
        {
            
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            List<TurnosPorEspecialidad> listaTurnos = daoTurnos.ObtenerTurnosPorEspecialidad(fechaInicio, fechaFin);

            if (listaTurnos.Count == 0)
            {
                listaTurnos.Add(new TurnosPorEspecialidad
                {
                    Especialidad = "Sin registros",
                    CantidadTurnos = 0
                });
            }

            return listaTurnos;
        }



    }
}
