using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio

{
    public class NegocioPacientes
    {
        DaoPacientes dao = new DaoPacientes();
        public bool validarDniPaciente(string dniPaciente)
        {
            return dao.validarDniPaciente(dniPaciente);
        }

        public bool ExistePaciente(string dni)
        {
            return dao.ExistePaciente(dni);
        }
        public bool BajaPaciente(string dni)
        {
            return dao.BajaPaciente(dni);
        }
        public void AltaPaciente(Pacientes pac)
        {
            if (pac == null) throw new ArgumentNullException(nameof(pac), "El paciente no puede ser nulo");
            if (!this.dao.AgregarPaciente(pac)) throw new Exception("No se pudo agregar el paciente a la base de datos");

        }
        public DataTable GetPacientes()
        {
            return dao.ObtenerPacientes();
        }

        public DataTable GetPacientePorDniLike(string dni)
        {
            return dao.ObtenerPacientePorDniLike(dni);
        }

        public DataTable ObtenerPacientesPorDni(string dni)
        {
            return dao.ObtenerPacientesPorDni(dni);
        }

        public void ModificarPaciente(Pacientes pac)
        {
            if (pac == null) throw new ArgumentNullException(nameof(pac), "El paciente no puede ser nulo");
            if (!this.dao.ModificarPaciente(pac)) throw new Exception("No se pudo agregar el paciente a la base de datos");

        }
    }
}
