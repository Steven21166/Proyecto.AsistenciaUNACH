using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.AsistenciaUNACH.DemoConsola.DTO
{
    public class AsignaturaDTO
    {
        public int IdAsignatura { get; set; }

        public string CodigoAsignatura { get; set; } = string.Empty;

        public string NombreAsignatura { get; set; } = string.Empty;

        public int? Semestre { get; set; }
    }
}