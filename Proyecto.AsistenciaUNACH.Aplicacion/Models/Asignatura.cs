namespace Proyecto.AsistenciaUNACH.Aplicacion.Models
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }

        public string CodigoAsignatura { get; set; } = string.Empty;

        public string NombreAsignatura { get; set; } = string.Empty;

        public int? Semestre { get; set; }
    }
}