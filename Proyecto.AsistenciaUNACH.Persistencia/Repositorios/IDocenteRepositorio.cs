using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface IDocenteRepositorio
    {
        Task<List<Docente>> ObtenerTodos();

        Task<Docente?> ObtenerPorId(int id);

        Task<Docente> Crear(Docente docente);

        Task<bool> Actualizar(Docente docente);

        Task<bool> Eliminar(int id);
    }
}