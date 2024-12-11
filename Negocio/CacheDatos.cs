using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;


namespace Dao
{
    public static class CacheDatos
    {
        public static List<Provincia> Provincias { get; set; } = new List<Provincia>();
        public static List<Localidad> Localidades { get; set; } = new List<Localidad>();

        public static void PrecargarDatos()
        {
            var negocioProvincias = new NegocioProvincias();
            var negocioLocalidades = new NegocioLocalidades();

            Provincias = negocioProvincias.GetProvincias().AsEnumerable()
                .Select(r => new Provincia
                {
                    Id_Prov = r.Field<int>("ID_Prov"),
                    Nombre_prov = r.Field<string>("Nombre_prov")
                }).ToList();

            Localidades = negocioLocalidades.GetLocalidades().AsEnumerable()
                .Select(r => new Localidad
                {
                    Id_Loc = r.Field<int>("ID_Loc"),
                    Nombre_loc = r.Field<string>("Nombre_loc")
                }).ToList();


        }



    }
}
