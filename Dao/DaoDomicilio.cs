using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoDomicilio
    {
       AccesoDatos ds = new AccesoDatos();
        public DaoDomicilio() { }

        public int GenerarNuevoIdDomicilio()
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select Count(*) From Domicilio";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int count = (int)comando.ExecuteScalar();
            return count + 1;
        }

       
        public int ObtenerIdDomicilio(int ID_provincia, int ID_localidad, string direccion)
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select ID_Dom from Domicilio where Id_Prov_Dom = @Idprovincia and Id_Loc_Dom = @Idlocalidad and Direccion_dom = @Direccion";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Idprovincia", ID_provincia);
            comando.Parameters.AddWithValue("@Idlocalidad", ID_localidad);
            comando.Parameters.AddWithValue("@Direccion",direccion);
            object result;
            result = comando.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                int id_dom = GenerarNuevoIdDomicilio();
                string consulta2 = "Insert Into Domicilio (ID_Dom, Direccion_dom, Id_Prov_Dom, Id_Loc_Dom) VALUES (@id_dom, @Direccion, @Idprovincia, @Idlocalidad)";
                SqlCommand comando2 = new SqlCommand(consulta2, conexion);
                comando2.Parameters.AddWithValue("@id_dom", id_dom);
                comando2.Parameters.AddWithValue("@Direccion", direccion);
                comando2.Parameters.AddWithValue("@Idprovincia", ID_provincia);
                comando2.Parameters.AddWithValue("@Idlocalidad", ID_localidad);
                comando2.ExecuteNonQuery();
                return id_dom;



            }
        }

        public bool ModificarDom(int IdDom, string Direc)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@IdDom", IdDom);
            comando.Parameters.AddWithValue("@Direc", Direc);
            string consulta = "UPDATE Domicilio SET Direccion_dom = @Direc WHERE ID_Dom = @IdDom";

            return ds.EjecutarConsulta(consulta, comando);
        }


    }
   



}
