using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoEspecialidad
    {
        public DaoEspecialidad() { }

        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerEspecialidad()
        {
            string consulta = "Select * from Especialidad";
            DataTable tabla = ds.ObtenerTabla("Especialidad", consulta);
            return tabla;
        }
    }

}
