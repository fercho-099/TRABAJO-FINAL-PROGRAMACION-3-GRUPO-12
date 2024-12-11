using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoPacientes
    {
        AccesoDatos ds = new AccesoDatos();
        
        
        private void ArmarParametrosPacientes(SqlCommand Comando, Pacientes pac)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = pac.getDNI_pac();
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            SqlParametros.Value = pac.getNombre_pac();
            SqlParametros = Comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            SqlParametros.Value = pac.getApellido_pac();
            SqlParametros = Comando.Parameters.Add("@Sexo", SqlDbType.VarChar);
            SqlParametros.Value = pac.getSexo_pac();
            SqlParametros = Comando.Parameters.Add("@Nacionalidad",SqlDbType.VarChar);
            SqlParametros.Value = pac.getNacionalidad_pac();
            SqlParametros = Comando.Parameters.Add("@Fechanacimiento", SqlDbType.Date);
            SqlParametros.Value = pac.getFechaNac_pac();
            SqlParametros = Comando.Parameters.Add("@Domicilio", SqlDbType.Int);
            SqlParametros.Value = pac.getId_Domicilio_pac();
            SqlParametros = Comando.Parameters.Add("@Correoelectronico", SqlDbType.VarChar);
            SqlParametros.Value = pac.getCorreoElec_pac();
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.NChar);
            SqlParametros.Value = pac.getTelefono_pac();
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Int);
            SqlParametros.Value = pac.getEstado_pac();


        }



        public DataTable ObtenerPacientes()
        {
            string consulta = "Select DNI_pac as DNI,Nombre_pac as Nombre, Apellido_pac as Apellido,Sexo_pac as Sexo,Nacionalidad_pac as Nacionalidad, FechaNac_pac as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad,Direccion_dom as Direccion,CorreoElec_pac as [Correo Electronico],Telefono_pac as Telefono, Estado_pac as Estado from Paciente inner join Domicilio on ID_Domicilio_pac = ID_Dom inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc Where Estado_pac = 1";
            DataTable tabla = ds.ObtenerTabla("Paciente", consulta);
            return tabla;
        }


        public DataTable ObtenerPacientesPorDNI(string DNI)
        {
            string consulta = $"Select DNI_pac as DNI,Nombre_pac as Nombre, Apellido_pac as Apellido,Sexo_pac as Sexo,Nacionalidad_pac as Nacionalidad, FechaNac_pac as [Fecha de nacimiento],Direccion_dom as Direccion,CorreoElec_pac as [Correo Electronico],Telefono_pac as Telefono, Estado_pac as Estado from Paciente inner join Domicilio on ID_Domicilio_pac = ID_Dom where DNI_pac = '{DNI}' ";
            DataTable tabla = ds.ObtenerTabla("Paciente", consulta);
            return tabla;
        }

        public bool validarDniPaciente(string dni)
        {
            string consulta = $"SELECT * FROM Paciente WHERE DNI_pac = '{dni}' and Estado_pac = 1";
            return ds.validarDniPaciente(consulta);
        }
        public bool ExistePaciente(string dni)
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select count (*) from Paciente where DNI_pac = @dni";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@dni", dni);
            try
            {
                int cant = (int)comando.ExecuteScalar();
                return cant > 0;
            }
            catch
            {
                throw new Exception("Error al buscar el dni del paciente");
            }

        }
        public bool BajaPaciente(string dni)
        {
            string consulta = $"UPDATE Paciente Set Estado_pac = 0 Where DNI_pac = '{dni}' and Estado_pac = 1";
            return ds.BajaPaciente(consulta);
        }
        public bool AgregarPaciente(Pacientes pac)
        {
            SqlCommand comando = new SqlCommand();
            this.ArmarParametrosPacientes(comando, pac);
            string consulta = "Insert into Paciente(DNI_pac, Nombre_pac, Apellido_pac, Sexo_pac, Nacionalidad_pac, FechaNac_pac, ID_Domicilio_pac, CorreoElec_pac, Telefono_pac, Estado_pac)" +
                "Values (@DNI,@Nombre,@Apellido,@Sexo,@Nacionalidad,@Fechanacimiento,@Domicilio,@Correoelectronico,@Telefono, @Estado)";
            return ds.EjecutarConsulta(consulta, comando);

        }
        public DataTable ObtenerPacientePorDniLike(string dni)
        {
            SqlConnection conexion = ds.ObtenerConexion();
            string consulta = "Select DNI_pac as DNI,Nombre_pac as Nombre, Apellido_pac as Apellido,Sexo_pac as Sexo,Nacionalidad_pac as Nacionalidad, FechaNac_pac as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad,Direccion_dom as Direccion,CorreoElec_pac as [Correo Electronico],Telefono_pac as Telefono, Estado_pac as Estado from Paciente inner join Domicilio on ID_Domicilio_pac = ID_Dom inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc  Where DNI_pac LIKE @dni and Estado_pac = 1";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@dni", "%" + dni + "%");

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tablapacientes = new DataTable();
                adapter.Fill(tablapacientes);
                return tablapacientes;


            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }

        }

        public DataTable ObtenerPacientesPorDni(string dni)
        {
            string consulta = $"Select DNI_pac as DNI,Nombre_pac as Nombre, Apellido_pac as Apellido,Sexo_pac as Sexo,Nacionalidad_pac as Nacionalidad, FechaNac_pac as [Fecha de nacimiento],Nombre_prov as Provincia,Nombre_loc as Localidad,Direccion_dom as Direccion,CorreoElec_pac as [Correo Electronico],Telefono_pac as Telefono, Estado_pac as Estado from Paciente inner join Domicilio on ID_Domicilio_pac = ID_Dom inner join Provincia on ID_Prov_dom = ID_prov inner join Localidad on ID_Loc_dom = ID_Loc WHERE DNI_pac = {dni} AND Estado_pac = 1 ";
            DataTable tabla = ds.ObtenerTabla("Paciente", consulta);
            return tabla;
        }

        public bool ModificarPaciente(Pacientes pac)
        {
            SqlCommand comando = new SqlCommand();
            this.ArmarParametrosPacientes(comando, pac);
            string consulta = "UPDATE Paciente " + "SET Nombre_pac = @Nombre, " + "Apellido_pac = @Apellido, " + "Sexo_pac = @Sexo, " + "Nacionalidad_pac = @Nacionalidad, " + "FechaNac_pac = @Fechanacimiento, " + "ID_Domicilio_pac = @Domicilio, " + "CorreoElec_pac = @Correoelectronico, " + "Telefono_pac = @Telefono, " + "Estado_pac = @Estado " + "WHERE DNI_pac = @DNI";

            return ds.EjecutarConsulta(consulta, comando);
        }



    }
}
