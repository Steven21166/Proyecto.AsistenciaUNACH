namespace Proyecto.AsistenciaUNACH.Aplicacion.Models
{
    public class Docente
    {
        public int IdDocente { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

        public string? Celular { get; set; }

        public string Correo { get; set; } = string.Empty;

        public int IdCarrera { get; set; }

        public int IdAsignatura { get; set; }

        public DateOnly? FechaAsistencia { get; set; }

        public TimeOnly? HoraEntrada { get; set; }

        public TimeOnly? HoraSalida { get; set; }

        public string? EstadoAsistencia { get; set; }
    }
}