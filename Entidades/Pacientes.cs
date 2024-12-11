using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pacientes
    {
        private string DNI_pac;
        private string Nombre_pac;
        private string Apellido_pac;
        private string Sexo_pac;
        private string Nacionalidad_pac;
        private DateTime FechaNac_pac;
        private int ID_Domicilio_pac;
        private string CorreoElec_pac;
        private string Telefono_pac;
        private int Estado_pac;


        public Pacientes() { }

        public static Pacientes AgregarPacientes(string dni_pac, string nombre_pac, string apellido_pac, string sexo_pac, string nacionalidad_pac, DateTime fechanac_pac, int iddomicilio_pac, string correoelec_pac, string telefono_pac, int Estado_pac)
        {
            Pacientes pac = new Pacientes();
            pac.setDNI_pac(dni_pac);
            pac.setNombre_pac(nombre_pac);
            pac.setApellido_pac(apellido_pac);
            pac.setSexo_pac(sexo_pac);
            pac.setNacionalidad_pac(nacionalidad_pac);
            pac.setFechaNac_pac(fechanac_pac);
            pac.setID_Domicilio_pac(iddomicilio_pac);
            pac.setCorreoElec_pac(correoelec_pac);
            pac.setTelefono_pac(telefono_pac);
            pac.setEstado_pac(Estado_pac);

            return pac;
        }

        public string getDNI_pac()
            {
                return DNI_pac;
            }
        public string getNombre_pac()
        {
            return Nombre_pac;
        }
        public string getApellido_pac()
        {
            return Apellido_pac;
        }
    
        public string getSexo_pac()
        {
            return Sexo_pac;
        }
        public string getNacionalidad_pac()
        {
            return Nacionalidad_pac;
        }
        public DateTime getFechaNac_pac()
        {
            return FechaNac_pac;
        }
        public int getId_Domicilio_pac()
        {
            return ID_Domicilio_pac;    

        }        
        public string getCorreoElec_pac()
        {
            return CorreoElec_pac;  
        }
        public string getTelefono_pac()
        {
            return Telefono_pac;
        }
        public int getEstado_pac()
        {
            return Estado_pac;
        }


        public void setDNI_pac(string DNI)
        {
            DNI_pac=DNI;
        }
    
        public void setNombre_pac(string Nombre)
        {
            Nombre_pac=Nombre;
        }
        public void setApellido_pac(string Apellido)
        {
            Apellido_pac=Apellido;
        }
        public void setSexo_pac (string Sexo)
        {
            Sexo_pac=Sexo;
        }
        public void setNacionalidad_pac(string Nacionalidad)
        {
            Nacionalidad_pac=Nacionalidad;
        }
        public void setFechaNac_pac(DateTime FechaNac)
        {
            FechaNac_pac=FechaNac;
        }
        public void setID_Domicilio_pac(int ID_Domicilio)
        {
            ID_Domicilio_pac = ID_Domicilio; 
        }
        public void setCorreoElec_pac(string CorreoElec)
        {
            CorreoElec_pac=CorreoElec;
        }
        public void setTelefono_pac(string Telefono)
        {
            Telefono_pac=Telefono;
        }
        public void setEstado_pac(int Estado)
        {
            Estado_pac=Estado;
        }
    
    
    
    }   
}
