using System;
using System.Web;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioLogin
    {
        DaoLogin dao = new DaoLogin();
        public string LoginAdmin(string usuarioAdmin, string contraseniaAdmin)
        {
            return dao.LoginAdmin(usuarioAdmin, contraseniaAdmin);
        }

        public string LoginMedic(string usuarioMed, string password)
        {
            return dao.LoginMedic(usuarioMed, password);
        }

    }
}
