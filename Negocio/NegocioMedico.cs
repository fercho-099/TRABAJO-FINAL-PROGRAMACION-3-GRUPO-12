using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class NegocioMedico
    {
        DaoMedicos Medicos = new DaoMedicos();
        DaoMedicosDxH DaoMedicosDxH = new DaoMedicosDxH();

        public bool VerificarLegajo(string legajo)
        {
            return Medicos.ExisteLegajo(legajo);
        }

        public bool BajaMedico(string legajo)
        {
            return Medicos.BajaMedico(legajo);
        }

        public DataTable GetMedicos()
        {
            return Medicos.ObtenerMedicos();

        }

        public DataTable GetMedicoPorLegajoLike(string LegajoMedico)
        {
            return Medicos.ObtenerMedicoPorLegajoLike(LegajoMedico);
        }

        public DataTable GetMedicoPorLegajo(string LegajoMedico)
        {
            return Medicos.ObtenerMedicoPorLegajoLike(LegajoMedico);
        }
        public bool AgregarMedico(string legajo)
        {
            return true;
        }

        public DataTable GetMedicoEspecialidad(int Especialidad)
        {
            return Medicos.ObtenerMedicoEspecialidad(Especialidad);
        }

        public DataTable GetDiaMedico(string legajo)
        {
            return DaoMedicosDxH.ObtenerDiaMedico(legajo);
        }

        public DataTable GetHorarioMedico(string legajo, int idDia)
        {
            return DaoMedicosDxH.ObtenerHorarioMedico(legajo, idDia);
        }

        public bool guardarMedico(Medicos datos)
        {
            try
            {
                if (datos == null)
                {
                    // No se puede guardar si los datos son nulos.
                    return false;
                }

                // Intentar guardar el médico utilizando el método AltaMedicos.
                return this.Medicos.AltaMedicos(datos);
            }
            catch (Exception ex)
            {
                // Opcional: Registrar el error si es necesario.
                Console.WriteLine($"Error al guardar el médico: {ex.Message}");
                return false;
            }
        }

        public String GetLegajoMedico(string nombre, string usuario)
        {
            return Medicos.GetLegajoMedico(nombre, usuario);
        }

        public void ModificarMedico(Medicos med)
        {
            if (med == null) throw new ArgumentNullException(nameof(med), "El medico no puede ser nulo");
            if (!this.Medicos.ModificarMedico(med)) throw new Exception("No se pudo modificar el medico");

        }
    }
}
