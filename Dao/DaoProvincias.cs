using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

namespace Dao
{
 
    public class DaoProvincias
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoProvincias()
        {

        }
    
        public DataTable ObtenerProvincias()
        {
            string consulta = "SELECT * FROM dbo.Provincia";
            DataTable tabla = ds.ObtenerTabla("Provincia", consulta);
            return tabla;
        }
    
    }
}
