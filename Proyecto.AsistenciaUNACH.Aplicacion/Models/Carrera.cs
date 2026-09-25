namespace Proyecto.AsistenciaUNACH.Aplicacion.Models
{
    public class Carrera
    {
        public int IdCarrera { get; set; }

        public string CodigoCarrera { get; set; } = string.Empty;

        public string NombreCarrera { get; set; } = string.Empty;

        public string Facultad { get; set; } = string.Empty;

        public string? Modalidad { get; set; }
    }
}