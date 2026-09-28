using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class DocenteAsignaturaRepositorio : IDocenteAsignaturaRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public DocenteAsignaturaRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocenteAsignatura>> ObtenerAsignacionesAsync()
        {
            return await _context.DocenteAsignaturas
                .Include(d => d.IdDocenteNavigation)
                .Include(d => d.IdAsignaturaNavigation)
                .ToListAsync();
        }

        public async Task AsignarMateriaADocenteAsync(DocenteAsignatura docenteAsignatura)
        {
            _context.DocenteAsignaturas.Add(docenteAsignatura);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsignacionAsync(int id)
        {
            var asignacion = await _context.DocenteAsignaturas.FindAsync(id);
            if (asignacion != null)
            {
                _context.DocenteAsignaturas.Remove(asignacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}