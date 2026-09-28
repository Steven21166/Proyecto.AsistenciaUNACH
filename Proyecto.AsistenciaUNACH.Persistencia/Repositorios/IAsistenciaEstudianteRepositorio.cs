using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IAsistenciaEstudianteRepositorio
    {
        Task<IEnumerable<AsistenciaEstudiante>> ObtenerAsistenciasAsync();
        Task<AsistenciaEstudiante?> ObtenerAsistenciaPorIdAsync(int id);
        Task RegistrarAsistenciaAsync(AsistenciaEstudiante asistencia);
        Task ActualizarAsistenciaAsync(AsistenciaEstudiante asistencia);
    }
}