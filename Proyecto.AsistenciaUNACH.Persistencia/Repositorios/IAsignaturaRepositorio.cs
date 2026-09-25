using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IAsignaturaRepositorio
    {
        Task<List<Asignatura>> ObtenerTodas();

        Task<Asignatura?> ObtenerPorId(int id);

        Task<Asignatura> Crear(Asignatura asignatura);

        Task<bool> Actualizar(Asignatura asignatura);

        Task<bool> Eliminar(int id);
    }
}