using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCalendario
    {
        DaoCalendario daoCalendario = new DaoCalendario();
        
        public DataTable GetFechas(string legajo, int idDxH)
        {
            return daoCalendario.ObtenerFechas(legajo, idDxH);
        }

        public bool VerificarTurno(string fechaTurnoStr, int idDxH, string legajoMed)
        {
            DateTime fechaTurno;
            if (!DateTime.TryParse(fechaTurnoStr, out fechaTurno))
            {
                throw new Exception("La fecha no es válida");
            }

            bool existeTurno = daoCalendario.VerificarTurnoExistente(fechaTurno, idDxH, legajoMed);

            return existeTurno;
        }
    }
}
