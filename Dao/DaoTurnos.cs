using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        private void ArmarParametrosTurnos(SqlCommand Comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI_Pac_turn", SqlDbType.Char, 8);
            SqlParametros.Value = turno.DNI_Pac_turn;
            SqlParametros = Comando.Parameters.Add("@ID_DxH_turn", SqlDbType.Int);
            SqlParametros.Value = turno.ID_DxH_turn;
            SqlParametros = Comando.Parameters.Add("@Fecha_turn", SqlDbType.Date);
            SqlParametros.Value = turno.Fecha_turn;
            SqlParametros = Comando.Parameters.Add("@LegajoMed_turn", SqlDbType.Char, 5);
            SqlParametros.Value = turno.LegajoMed_turn;
        }



        public bool CargarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            this.ArmarParametrosTurnos(comando, turno);
            string consulta = "INSERT INTO Turnos(DNI_Pac_turn, ID_DxH_turn, Fecha_turn, LegajoMed_turn) VALUES (@DNI_Pac_turn, @ID_DxH_turn, @Fecha_turn, @LegajoMed_turn)";

            if(ds.EjecutarConsulta(consulta, comando))
            {
                SqlCommand comando2 = new SqlCommand();
                this.ArmarParametrosTurnos(comando2, turno);
                string consulta2 = "UPDATE Calendario SET EstadoTurno_cal = 1 WHERE ID_DxH_cal = @ID_DxH_turn AND LegajoMed_cal = @LegajoMed_turn AND Fecha_cal = @Fecha_turn";
                ds.EjecutarConsulta(consulta2, comando2);

                return true;
            }
            return false;
        }

        /*aca pretendo hacer la funcion "OBTENERTURNOSPARAINFORMENOMBRES" pero no se como*/
        public TurnosReporte ObtenerTurnosParaInforme(DateTime fechaInicio, DateTime fechaFin)
        {
            TurnosReporte reporte = new TurnosReporte();
            string query = @"
        SELECT 
            COUNT(*) AS total_turnos,
            COUNT(CASE WHEN subquery.Estado_turn = '1' THEN 1 END) AS cantidad_presentes,
            COUNT(CASE WHEN subquery.Estado_turn = '0' THEN 1 END) AS cantidad_ausentes
        FROM (
            SELECT DISTINCT t.Estado_turn, t.NroTurno
            FROM Turnos t
            INNER JOIN MedicoDiasHorario mdh ON t.LegajoMed_turn = mdh.LegajoMed_mdh
            INNER JOIN DiasXHorario dxh ON mdh.ID_DiasXHorario_mdh = dxh.ID_DiasXHorario
            WHERE t.Fecha_turn >= @FechaInicio AND t.Fecha_turn <= @FechaFin
        ) AS subquery;";

            using (SqlConnection conexion = ds.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    reporte.TotalTurnos = Convert.ToInt32(reader["total_turnos"]);
                    reporte.CantidadPresentes = Convert.ToInt32(reader["cantidad_presentes"]);
                    reporte.CantidadAusentes = Convert.ToInt32(reader["cantidad_ausentes"]);

                    
                    if (reporte.TotalTurnos > 0)
                    {
                        reporte.PorcentajePresentes = (reporte.CantidadPresentes * 100.0f) / reporte.TotalTurnos;
                        reporte.PorcentajeAusentes = (reporte.CantidadAusentes * 100.0f) / reporte.TotalTurnos;
                    }
                    else
                    {
                        reporte.PorcentajePresentes = 0.0f;
                        reporte.PorcentajeAusentes = 0.0f;
                    }
                }
                else
                {
                    reporte.TotalTurnos = 0;
                    reporte.CantidadPresentes = 0;
                    reporte.PorcentajePresentes = 0.0f;
                    reporte.CantidadAusentes = 0;
                    reporte.PorcentajeAusentes = 0.0f;
                }

                reader.Close();
            }

            return reporte;
        }

        public List<TurnosReporteNombre> ObtenerTurnosParaInformeNombre(DateTime fechaInicio, DateTime fechaFin)
        {
            TurnosReporteNombre reporteNombre = new TurnosReporteNombre();
            List<TurnosReporteNombre> turnoNombre = new List<TurnosReporteNombre>();
            string query = @"
        SELECT 
            p.Nombre_pac, p.Apellido_pac, t.Estado_turn from Turnos as t
            INNER JOIN Paciente as p on p.DNI_pac = t.DNI_Pac_turn;";

            using (SqlConnection conexion = ds.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    TurnosReporteNombre turNom = new TurnosReporteNombre() {
                        nombre = reader["Nombre_pac"].ToString(),
                        apellido = reader["Apellido_pac"].ToString(),
                        Estado = Convert.ToInt32(reader["Estado_turn"])
                    };
                    turnoNombre.Add(turNom);
                    
                }

                if (turnoNombre.Count ==0)
                {
                    turnoNombre.Add(new TurnosReporteNombre
                    {
                        nombre = "No hay Datos",
                        apellido = "No hay datos",
                        Estado = 0
                    });
                }

                reader.Close();
            }

            return turnoNombre;
        }

        public DataTable ObtenerTurnosPorLegajo(string legajoMed)
        {
            string consulta = $"SELECT t.*, p.Nombre_pac, p.FechaNac_pac, d.Nombre_dia , h.HoraInicio_horario AS Horario FROM Turnos t " +
                $"INNER JOIN Paciente p ON t.DNI_Pac_turn = p.DNI_pac " +
                $"INNER JOIN DiasXHorario x ON t.ID_DxH_turn = x.ID_DiasXHorario " +
                $"INNER JOIN Dias d ON x.ID_Dia = d.ID_Dia " +
                $"INNER JOIN Horarios h ON x.ID_Horario = h.ID_Horario " +
                $"WHERE t.LegajoMed_Turn = '{legajoMed}'  ";
            DataTable tabla = ds.ObtenerTabla("Paciente", consulta);
            return tabla;
        }

        public bool ModificarTurno(int idTurno, int estado, string observacion)
        {
            SqlCommand comando = new SqlCommand();
            string consulta = $"UPDATE Turnos SET Estado_turn = '{estado}', Observacion_turn = '{observacion}' WHERE NroTurno = '{idTurno}'";
            return ds.EjecutarConsulta(consulta, comando);
        }

        public DataTable ObtenerTurnosPorLegajo()
        {
            string consulta = "Select * from EstadoTurno";
            DataTable tabla = ds.ObtenerTabla("EstadoTurno", consulta);
            return tabla;
        }

        public DataTable ObtenerTurnosPorDni(string dni, string legajoMed)
        {
            string consulta = $"SELECT t.*, p.Nombre_pac, p.FechaNac_pac, d.Nombre_dia , h.HoraInicio_horario AS Horario FROM Turnos t " +
                              $"INNER JOIN Paciente p ON t.DNI_Pac_turn = p.DNI_pac " +
                              $"INNER JOIN DiasXHorario x ON t.ID_DxH_turn = x.ID_DiasXHorario " +
                              $"INNER JOIN Dias d ON x.ID_Dia = d.ID_Dia " +
                              $"INNER JOIN Horarios h ON x.ID_Horario = h.ID_Horario " +
                              $"WHERE DNI_Pac_turn = '{dni}' AND t.LegajoMed_turn = '{legajoMed}'";

            return ds.ObtenerTabla("Turnos", consulta);

        }
        public List<TurnosPorEspecialidad> ObtenerTurnosPorEspecialidad(DateTime fechaInicio, DateTime fechaFin)
        {
            List<TurnosPorEspecialidad> listaTurnos = new List<TurnosPorEspecialidad>();
            string query = @"select es.Nombre_espec,count(t.NroTurno) AS CantidadTurnos
                            from Turnos t inner join Medico m on t.LegajoMed_turn = m.Legajo_med
                            inner join Especialidad es on m.ID_Especialidad_med = es.ID_Espec
                            where t.Fecha_turn >=@FechaInicio and t.Fecha_turn <= @FechaFin
                            group by es.Nombre_espec";

            using (SqlConnection conexion = ds.ObtenerConexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        TurnosPorEspecialidad turnoEspec = new TurnosPorEspecialidad()
                        {
                            Especialidad = reader["Nombre_espec"].ToString(),
                            CantidadTurnos = Convert.ToInt32(reader["CantidadTurnos"])
                        };
                        listaTurnos.Add(turnoEspec);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error al obtener la cantidad de turnos por especialidad", ex);
                }
            }

            return listaTurnos;
        }





    }
}
