using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IDocenteRepositorio
    {
        Task<IEnumerable<Docente>> ObtenerDocentesAsync();
        Task<Docente?> ObtenerDocentePorIdAsync(int id);
        Task AgregarDocenteAsync(Docente docente);
        Task ActualizarDocenteAsync(Docente docente);
        Task EliminarDocenteAsync(int id);
    }
}