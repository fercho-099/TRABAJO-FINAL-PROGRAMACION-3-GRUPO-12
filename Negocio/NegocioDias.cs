using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDias
    {
        public NegocioDias() { }

        DaoDias daoDias = new DaoDias();

        public DataTable getDias()
        {
            return daoDias.ObtenerDias();
        }
    }
}
