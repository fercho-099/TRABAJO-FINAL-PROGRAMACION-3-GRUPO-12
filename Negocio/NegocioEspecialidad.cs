using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        public NegocioEspecialidad() { }

        DaoEspecialidad daoEspecialidad = new DaoEspecialidad();

        public DataTable GetEspecialidad()
        {
            return daoEspecialidad.ObtenerEspecialidad();
        }

    }
}
