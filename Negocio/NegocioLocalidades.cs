using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioLocalidades
    {
        DaoLocalidades daoLocalidades = new DaoLocalidades();

        public NegocioLocalidades() { }

        public DataTable GetLocalidades()
        {
            return daoLocalidades.ObtenerLocalidades();
        }
    }
}
