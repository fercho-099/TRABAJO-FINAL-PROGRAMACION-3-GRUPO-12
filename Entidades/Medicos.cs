using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Globalization;


namespace Entidades
{
    public class Medicos
    {

        private string Legajo_med;
        private string DNI_med;
        private string Nombre_med;
        private string Apellido_med;
        private string Sexo_med;
        private string Nacionalidad_med;
        private DateTime FechaNac_med;
        private int ID_Domicilio_med;
        private string CorreoElec_med;
        private string Telefono_med;
        private int ID_Especialidad_med;
        private string Usuario_med;
        private string Contraseña_med;
        private int Estado_med;

        public Medicos() { }

        public static Medicos AgregarMedicos(string LegajoMed, string dniMed, string Nombremed, string ApellidoMed, string sexoMed, string NacionaMed, DateTime FechaNacMed, string EmailMed, string telefonoMed, int ddlEspecialida, string usuarioMed, string ClaveMed, int estado_med, int domicilio_med)
        {
            Medicos medicos = new Medicos();

            medicos.setLegajoMed(LegajoMed);
            medicos.setDNIMedico(dniMed);
            medicos.setNombreMedico(Nombremed);
            medicos.setApellidoMedico(ApellidoMed);
            medicos.setSexoMedico(sexoMed);
            medicos.setNacionalidad(NacionaMed);
            medicos.setFechaNac(FechaNacMed);
            medicos.setEmail(EmailMed);
            medicos.setTelefono(telefonoMed);
            medicos.setEspecialidad(ddlEspecialida);
            medicos.setUsuario(usuarioMed);
            medicos.setClave(ClaveMed);
            medicos.setEstado(estado_med);
            medicos.setDomicilio(domicilio_med);
            return medicos;
        }


        public string getLegajoMed()
        {
            return Legajo_med;
        }
        public string getNombreMedico()
        {
            return Nombre_med;
        }
        public string getApellidoMedico()
        {
            return Apellido_med;
        }
        public string getDNIMedico()
        {
            return DNI_med;
        }
        public string getSexoMedico()
        {
            return Sexo_med;
        }
        public string getNacionalidad()
        {
            return Nacionalidad_med;
        }
        public DateTime getFechaNac()
        {
            return FechaNac_med;
        }
        public int getDomicilio()
        {
            return ID_Domicilio_med;
        }
        public string getEmail()
        {
            return CorreoElec_med;
        }
        public string getTelefono()
        {
            return Telefono_med;
        }
        public int getEspecialidad()
        {
            return ID_Especialidad_med;
        }
        public string getUsuario()
        {
            return Usuario_med;
        }
        public string getClave()
        {
            return Contraseña_med;
        }
        public int getEstado()
        {
            return Estado_med;
        }
        public void setLegajoMed(string legajomed)
        {
            Legajo_med = legajomed;
        }
        public void setNombreMedico(string nommed)
        {
            Nombre_med = nommed;
        }
        public void setApellidoMedico(string apell)
        {
            Apellido_med = apell;
        }
        public void setDNIMedico(string dnimed)
        {
            DNI_med = dnimed;
        }
        public void setSexoMedico(string sexomed)
        {
            Sexo_med = sexomed;
        }
        public void setNacionalidad(string nacimed)
        {
            Nacionalidad_med = nacimed;
        }
        public void setFechaNac(DateTime fechamed)
        {
            FechaNac_med = fechamed;
        }
        public void setDomicilio(int domiciliomed)
        {
            ID_Domicilio_med = domiciliomed;
        }
        public void setEmail(string mailmed)
        {
            CorreoElec_med = mailmed;
        }
        public void setTelefono(string telefonomed)
        {
            Telefono_med = telefonomed;
        }
        public void setEspecialidad(int especialidadMed)
        {
            ID_Especialidad_med = especialidadMed;
        }
        public void setUsuario(string usuarioMed)
        {
            Usuario_med = usuarioMed;
        }
        public void setClave(string claveMed)
        {
            Contraseña_med = claveMed;
        }

        public void setEstado(int estadoMed)
        {
            Estado_med = estadoMed;
        }


        public string SexoSeleccionado(RadioButton rbFemenino, RadioButton rbMasculino)
        {
            if (rbFemenino.Checked)
            {
                return "Mujer";
            }
            else if (rbMasculino.Checked)
            {
                return "Hombre";
            }
            else
            {
                return "None";
            }
        }

        public static DateTime ConvertirFecha(string fecha)
        {

            DateTime FechaConvertida;
            string[] formatos = { "dd/mm/yy", "dd 'de' mmmm 'del' yyyy" };

            foreach (string formato in formatos)
            {
                if (DateTime.TryParseExact(fecha, formato, null, DateTimeStyles.None, out FechaConvertida))
                {
                    return FechaConvertida;
                }
            }

            return new DateTime(1990, 1, 1);/* pedir que convierta una fecha  por defecto*/
        }

    }
}
