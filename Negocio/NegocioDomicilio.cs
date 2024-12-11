using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDomicilio
    {
      DaoDomicilio domicilio = new DaoDomicilio();  
        public NegocioDomicilio() { }

        public int GetIdDomicilio(int ID_provincia, int ID_localidad, string direccion)
        {
            return domicilio.ObtenerIdDomicilio(ID_provincia, ID_localidad, direccion);
        }

        public void ModificarDomicilio(int idDom, string direc)
        {
            if (!this.domicilio.ModificarDom(idDom, direc)) throw new Exception("No se pudo modificar el domicilio");

        }
    }
}
