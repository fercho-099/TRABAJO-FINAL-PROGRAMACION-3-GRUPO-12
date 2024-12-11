using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoCalendario
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable ObtenerFechas(string legajo, int idDxH)
        {
            string consulta = "SELECT CONVERT(VARCHAR, Fecha_cal, 103) AS Fecha_cal FROM Calendario WHERE ID_DxH_cal = @idDxH AND LegajoMed_cal = @legajo AND EstadoTurno_cal = 0";
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.Parameters.AddWithValue("@idDxH", idDxH);

            DataTable tabla = ds.ObtenerTablaConComando(comando);

            return tabla;
        }

        public bool VerificarTurnoExistente(DateTime fechaTurno, int idDxH, string legajoMed)
        {
            SqlCommand comando = new SqlCommand();
            string consulta = "SELECT COUNT(*) " +
                              "FROM Calendario " +
                              "WHERE Fecha_cal = @Fecha_turno " +
                              "AND ID_DxH_cal = @IdDxH " +
                              "AND LegajoMed_cal = @LegajoMed " +
                              "AND EstadoTurno_cal = 1";
                
            comando.Parameters.AddWithValue("@Fecha_turno", fechaTurno);
            comando.Parameters.AddWithValue("@IdDxH", idDxH);
            comando.Parameters.AddWithValue("@LegajoMed", legajoMed);

            SqlConnection conexion = ds.ObtenerConexion();
            comando.Connection = conexion;
            comando.CommandText = consulta;

            int count = (int)comando.ExecuteScalar();  // Ejecutar la consulta y obtener el primer valor de la primera fila
            conexion.Close();

            return count > 0;
        }


    }
}
