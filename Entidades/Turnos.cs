using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        public int NroTurno { get; set; }
        public string DNI_Pac_turn { get; set; }
        public int ID_DxH_turn { get; set; }
        public DateTime Fecha_turn { get; set; }
        public int Estado_turn { get; set; }
        public string LegajoMed_turn { get; set; }
        public string Observacion_turn { get; set; }


        public static Turnos AgregarTurno(string dniPacTurn, int idDxHTurn, string fechaTurn, string legajoMed)
        {
            Turnos turno = new Turnos();

            turno.DNI_Pac_turn = dniPacTurn;
            turno.ID_DxH_turn = idDxHTurn;
            turno.LegajoMed_turn = legajoMed;

            // Convertir la fecha de string a DateTime
            if (DateTime.TryParse(fechaTurn, out DateTime fechaConvertida))
            {
                turno.Fecha_turn = fechaConvertida;
            }
            else
            {
                throw new FormatException("El formato de la fecha es inválido.");
            }

            return turno;
        }
    }

    

}
