using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public interface ICarreraRepositorio
    {
        Task<List<Carrera>> ObtenerTodas();

        Task<Carrera?> ObtenerPorId(int id);

        Task<Carrera> Crear(Carrera carrera);

        Task<bool> Actualizar(Carrera carrera);

        Task<bool> Eliminar(int id);
    }
}