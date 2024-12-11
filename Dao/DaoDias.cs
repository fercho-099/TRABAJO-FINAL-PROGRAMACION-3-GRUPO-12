using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoDias
    {
        public DaoDias() { }
        
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerDias()
        {
            string consulta = "Select * from Dias";
            DataTable tabla = ds.ObtenerTabla("Dias", consulta);
            return tabla;
        }

    }
}
