using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoMedicosDxH
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerDiaMedico(string legajo)
        {
            string consulta = "Select DISTINCT Dias.ID_Dia, Nombre_dia FROM Dias INNER JOIN DiasXHorario ON Dias.ID_Dia = DiasXHorario.ID_Dia INNER JOIN MedicoDiasHorario ON DiasXHorario.ID_DiasXHorario = MedicoDiasHorario.ID_DiasXHorario_mdh WHERE LegajoMed_mdh = @legajo";
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@legajo", legajo);

            DataTable tabla = ds.ObtenerTablaConComando(comando);

            return tabla;
        }

        public DataTable ObtenerHorarioMedico(string legajo, int idDia)
        {
            string consulta = "SELECT Horarios.ID_Horario, CONCAT(CONVERT(VARCHAR(5), HoraInicio_horario, 108), ' - ', CONVERT(VARCHAR(5), HoraFin_horario, 108)) AS RangoHorario, MedicoDiasHorario.ID_DiasXHorario_mdh FROM Horarios INNER JOIN DiasXHorario ON Horarios.ID_Horario = DiasXHorario.ID_Horario INNER JOIN MedicoDiasHorario ON DiasXHorario.ID_DiasXHorario = MedicoDiasHorario.ID_DiasXHorario_mdh WHERE LegajoMed_mdh = @legajo AND DiasXHorario.ID_Dia= @IdDia ";
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.Parameters.AddWithValue("@idDia", idDia);

            DataTable tabla = ds.ObtenerTablaConComando(comando);

            return tabla;
        }
    }
}
