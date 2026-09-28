using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IDocenteAsignaturaRepositorio
    {
        Task<IEnumerable<DocenteAsignatura>> ObtenerAsignacionesAsync();
        Task AsignarMateriaADocenteAsync(DocenteAsignatura docenteAsignatura);
        Task EliminarAsignacionAsync(int id);
    }
}