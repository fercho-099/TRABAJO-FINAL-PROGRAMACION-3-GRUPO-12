using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioHorarios
    {
        public NegocioHorarios() { }

        DaoHorarios daoHorarios = new DaoHorarios();

        public DataTable getHorarios()
        {
           return daoHorarios.ObtenerHorarios();
        }
    }
}
