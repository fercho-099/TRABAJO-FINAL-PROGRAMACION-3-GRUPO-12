using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoLogin
    {
        AccesoDatos ds = new AccesoDatos();


        public string LoginAdmin(string usuarioAdmin, string contraseniaAdmin)
        {
            string user = "admin";
            string consulta = 
                $"SELECT * FROM Administrador WHERE Usuario_admin = '{usuarioAdmin}' AND Contraseña_admin = '{contraseniaAdmin}'";
            return ds.VerificarLogin(consulta, user);
        }


        public string LoginMedic(string usuarioMed, string password)
        {
            string user = "medico";
            string consulta = $"SELECT * FROM Medico WHERE Usuario_med = '{usuarioMed}' AND Contraseña_med = '{password}' AND Estado_med = 1";
            return ds.VerificarLogin(consulta, user);
        }
    }
}
