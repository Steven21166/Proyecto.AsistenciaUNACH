using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IEstudianteRepositorio
    {
        Task<IEnumerable<Estudiante>> ObtenerEstudiantesAsync();
        Task<Estudiante?> ObtenerEstudiantePorIdAsync(int id);
        Task AgregarEstudianteAsync(Estudiante estudiante);
        Task ActualizarEstudianteAsync(Estudiante estudiante);
        Task EliminarEstudianteAsync(int id);
    }
}