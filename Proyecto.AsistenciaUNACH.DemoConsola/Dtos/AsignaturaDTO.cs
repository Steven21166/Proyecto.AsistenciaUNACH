using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.AsistenciaUNACH.DemoConsola.Dtos
{
    public class AsignaturaDTO
    {
        public int IdAsignatura { get; set; }
        public string CodigoAsignatura { get; set; } = null!;
        public string NombreAsignatura { get; set; } = null!;
        public int? Semestre { get; set; }
        public string DiasSemana { get; set; } = null!;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}