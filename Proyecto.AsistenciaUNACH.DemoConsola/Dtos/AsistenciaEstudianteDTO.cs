using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.AsistenciaUNACH.DemoConsola.Dtos
{
    public class AsistenciaEstudianteDTO
    {
        public int IdAsistencia { get; set; }
        public int IdEstudiante { get; set; }
        public int IdAsignatura { get; set; }
        public int IdDocente { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public TimeSpan HoraRegistro { get; set; }
        public string EstadoAsistencia { get; set; } = null!;
    }
}