using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoLocalidades
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoLocalidades()
        {

        }

        public DataTable ObtenerLocalidades()
        {
            string consulta = "Select * from Localidad";
            DataTable tabla = ds.ObtenerTabla("Localidad", consulta);
            return tabla;
        }
    }
}
