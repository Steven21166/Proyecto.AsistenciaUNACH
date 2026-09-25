using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.AsistenciaUNACH.DemoConsola.DTO
{
    public class CarreraDTO
    {
        public int IdCarrera { get; set; }

        public string CodigoCarrera { get; set; } = string.Empty;

        public string NombreCarrera { get; set; } = string.Empty;

        public string Facultad { get; set; } = string.Empty;

        public string? Modalidad { get; set; }
    }
}