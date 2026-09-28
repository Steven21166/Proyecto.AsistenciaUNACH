using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.AsistenciaUNACH.DemoConsola.Dtos
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }
        public string CodigoEstudiante { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Semestre { get; set; }
        public string? Estado { get; set; }
        public int IdCarrera { get; set; }
    }
}