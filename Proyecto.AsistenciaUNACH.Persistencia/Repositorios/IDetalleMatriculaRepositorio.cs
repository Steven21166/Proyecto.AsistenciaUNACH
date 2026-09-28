using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IDetalleMatriculaRepositorio
    {
        Task<IEnumerable<DetalleMatricula>> ObtenerMatriculasAsync();
        Task<DetalleMatricula?> ObtenerMatriculaPorIdAsync(int id);
        Task MatricularEstudianteAsync(DetalleMatricula detalleMatricula);
        Task EliminarMatriculaAsync(int id);
    }
}