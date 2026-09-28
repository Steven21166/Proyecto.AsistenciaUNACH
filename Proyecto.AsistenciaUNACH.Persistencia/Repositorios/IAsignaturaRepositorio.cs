using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IAsignaturaRepositorio
    {
        Task<IEnumerable<Asignatura>> ObtenerAsignaturasAsync();
        Task<Asignatura?> ObtenerAsignaturaPorIdAsync(int id);
        Task AgregarAsignaturaAsync(Asignatura asignatura);
        Task ActualizarAsignaturaAsync(Asignatura asignatura);
        Task EliminarAsignaturaAsync(int id);
    }
}