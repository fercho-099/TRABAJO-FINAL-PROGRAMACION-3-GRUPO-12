using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoHorarios
    {
        public DaoHorarios() { }

        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerHorarios()
        {
            string consulta = "SELECT ID_Horario, CONCAT(CONVERT(VARCHAR(5), HoraInicio_horario, 108), ' - ', CONVERT(VARCHAR(5), HoraFin_horario, 108)) AS RangoHorario FROM HORARIOS;";
            DataTable tabla = ds.ObtenerTabla("Horarios", consulta);
            return tabla;
        }
    }
}
