using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net;
using System.Security.Claims;

namespace Dao
{
    public class DaoMedicos
    {
        AccesoDatos ds = new AccesoDatos();

        private void ArmarParametrosMedicos(SqlCommand Comando, Medicos datos)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEG", SqlDbType.VarChar);
            SqlParametros.Value = datos.getLegajoMed();

            SqlParametros = Comando.Parameters.Add("@NOM", SqlDbType.VarChar);
            SqlParametros.Value = datos.getNombreMedico();
            SqlParametros = Comando.Parameters.Add("@APE", SqlDbType.VarChar); 
            SqlParametros.Value = datos.getApellidoMedico();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Int);
            SqlParametros.Value = datos.getDNIMedico();
            SqlParametros = Comando.Parameters.Add("@SEXO", SqlDbType.VarChar);
            SqlParametros.Value = datos.getSexoMedico();
            
            SqlParametros = Comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            SqlParametros.Value = datos.getNacionalidad();
            SqlParametros = Comando.Parameters.Add("@Fechanac", SqlDbType.Date);
            SqlParametros.Value = datos.getFechaNac();
            SqlParametros = Comando.Parameters.Add("@Domicilio", SqlDbType.Int);
            SqlParametros.Value = datos.getDomicilio();
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.VarChar);
            SqlParametros.Value = datos.getEmail();

            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.NChar);
            SqlParametros.Value = datos.getTelefono();
            SqlParametros = Comando.Parameters.Add("@Especialidad", SqlDbType.Int);
            SqlParametros.Value = datos.getEspecialidad();
            SqlParametros = Comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
            SqlParametros.Value = datos.getUsuario();
            SqlParametros = Comando.Parameters.Add("@Clave", SqlDbType.VarChar);
            SqlParametros.Value = datos.getClave();

        }
        public bool AltaMedicos(Medicos datos)
        {
            SqlCommand comando = new SqlCommand();
            this.ArmarParametrosMedicos(comando, datos);
            string consulta = "INSERT INTO Medico(Legajo_med, Nombre_med, Apellido_med, DNI_med, Sexo_med, Nacionalidad_med, FechaNac_med, ID_Domicilio_med,CorreoElec_med, Telefono_med, ID_Especialidad_med, Usuario_med, Contraseña_med)" +
                "VALUES(@LEG, @NOM, @APE, @DNI, @SEXO, @Nacionalidad, @Fechanac, @Domicilio, @Email, @Telefono, @Especialidad, @Usuario, @Clave)";
            return ds.EjecutarConsulta(consulta, comando);
               
        }

        public bool ExisteLegajo(string legajo)
        {
            bool existe = false;
            string consulta = "SELECT COUNT(*) FROM Medico WHERE Legajo_med = @legajo and Estado_med = 1";

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Parameters.AddWithValue("@legajo", legajo);

                try
                {
                    SqlConnection conexion = ds.ObtenerConexion();
                    comando.Connection = conexion;
                    comando.CommandText = consulta;

                    int count = (int)comando.ExecuteScalar(); 
                    existe = count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar el legajo en la base de datos", ex);
                }
            }
            return existe;
        }

        public bool BajaMedico(string legajo)
        {
            bool baja = false;
            string consulta = "UPDATE Medico SET Estado_med = 0 WHERE Legajo_med = @legajo";

                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Parameters.AddWithValue("@legajo", legajo);

                    try
                    {
                        SqlConnection conexion = ds.ObtenerConexion();
                        comando.Connection = conexion;
                        comando.CommandText = consulta;

                        int filasAfectadas = comando.ExecuteNonQuery(); 
                        baja = filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de baja el médico en la base de datos", ex);
                    }
                }

            return baja;
        }
        public DataTable ObtenerMedicos()
        {
            string consulta = "Select Legajo_med as Legajo,Nombre_med as Nombre,Apellido_med as Apellido,DNI_med as Dni,Sexo_med as Sexo,Nacionalidad_med as Nacionalidad, FechaNac_med as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad, Direccion_dom as Direccion,CorreoElec_med as [Correo Electronico],Telefono_med as Telefono,Nombre_espec as Especialidad,Usuario_med as Usuario,Contraseña_med as Contraseña,Estado_med as Estado,ID_Dom from Medico inner join Domicilio on ID_Domicilio_med = ID_Dom inner join Especialidad on ID_Especialidad_med = ID_Espec inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc where Estado_med = 1";
            DataTable tabla = ds.ObtenerTabla("Medico", consulta);
            return tabla;
        }

        public DataTable ObtenerMedicoPorLegajoLike(string legajoMedico)
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select Legajo_med as Legajo,Nombre_med as Nombre,Apellido_med as Apellido,DNI_med as Dni,Sexo_med as Sexo,Nacionalidad_med as Nacionalidad, FechaNac_med as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad, Direccion_dom as Direccion,CorreoElec_med as [Correo Electronico],Telefono_med as Telefono,Nombre_espec as Especialidad,Usuario_med as Usuario,Contraseña_med as Contraseña,Estado_med as Estado,ID_Dom from Medico inner join Domicilio on ID_Domicilio_med = ID_Dom inner join Especialidad on ID_Especialidad_med = ID_Espec inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc  Where Legajo_med like @legajo and Estado_med = 1";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@legajo", "%" + legajoMedico + "%");

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tablaMedicos = new DataTable();
                adapter.Fill(tablaMedicos);
                return tablaMedicos;


            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }
        public DataTable ObtenerMedicoPorLegajo(string legajoMedico)
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select Legajo_med as Legajo,Nombre_med as Nombre,Apellido_med as Apellido,DNI_med as Dni,Sexo_med as Sexo,Nacionalidad_med as Nacionalidad, FechaNac_med as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad, Direccion_dom as Direccion,CorreoElec_med as [Correo Electronico],Telefono_med as Telefono,Nombre_espec as Especialidad,Usuario_med as Usuario,Contraseña_med as Contraseña,Estado_med as Estado,ID_Dom from Medico inner join Domicilio on ID_Domicilio_med = ID_Dom inner join Especialidad on ID_Especialidad_med = ID_Espec inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc Where Legajo_med = @legajo";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@legajo", legajoMedico);

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tablaMedicos = new DataTable();
                adapter.Fill(tablaMedicos);
                return tablaMedicos;


            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }

        public DataTable ObtenerMedicoEspecialidad(int Especialidad)
        {
            string consulta = "Select Nombre_med, Legajo_med FROM Medico WHERE ID_Especialidad_med = " + Especialidad;
            DataTable tabla = ds.ObtenerTabla("Medico", consulta);
            return tabla;
        }

        public string GetLegajoMedico(string nombre, string usuario)
        {
            string consulta = $"Select Legajo_med FROM Medico WHERE Nombre_med = '{nombre}' AND Usuario_med = '{usuario}'";
            return ds.GetMedicoLegajo(consulta);
        }

        public bool ModificarMedico(Medicos med)
        {
            SqlCommand comando = new SqlCommand();
            this.ArmarParametrosMedicos(comando, med);
            string consulta = "UPDATE Medico\r\nSET \r\n Nombre_med = @NOM,\r\n    Apellido_med = @APE,\r\n    Sexo_med = @Sexo,\r\n    Nacionalidad_med = @Nacionalidad,\r\n    FechaNac_med = @Fechanac,\r\n    ID_Domicilio_med = @Domicilio,\r\n    CorreoElec_med = @Email,\r\n    Telefono_med = @Telefono,\r\n ID_Especialidad_med = @Especialidad,\r\n    Usuario_med = @Usuario,\r\n DNI_med = @DNI,\r\n  Contraseña_med = @Clave\r\nWHERE Legajo_med = @LEG;";

            return ds.EjecutarConsulta(consulta, comando);
        }

    }
}

                                                                                                                               