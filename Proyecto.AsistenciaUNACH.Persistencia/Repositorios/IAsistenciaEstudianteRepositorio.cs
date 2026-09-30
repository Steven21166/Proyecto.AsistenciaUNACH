using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IAsistenciaEstudianteRepositorio
    {
        Task<IEnumerable<AsistenciaEstudiante>> ObtenerAsistenciasAsync();

        Task<IEnumerable<AsistenciaEstudiante>>
            ObtenerAsistenciasPorAsignaturaAsync(int idAsignatura);

        Task<AsistenciaEstudiante?> ObtenerAsistenciaPorIdAsync(int id);

        Task RegistrarAsistenciaAsync(
            AsistenciaEstudiante asistencia);

        Task ActualizarAsistenciaAsync(
            AsistenciaEstudiante asistencia);
    }
}