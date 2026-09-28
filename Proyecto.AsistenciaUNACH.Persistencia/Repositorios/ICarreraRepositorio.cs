using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface ICarreraRepositorio
    {
        Task<IEnumerable<Carrera>> ObtenerCarrerasAsync();
        Task<Carrera?> ObtenerCarreraPorIdAsync(int id);
        Task AgregarCarreraAsync(Carrera carrera);
        Task ActualizarCarreraAsync(Carrera carrera);
        Task EliminarCarreraAsync(int id);
    }
}