using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class AsignaturaRepositorio : IAsignaturaRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public AsignaturaRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasAsync()
        {
            return await _context.Asignaturas.ToListAsync();
        }

        public async Task<Asignatura?> ObtenerAsignaturaPorIdAsync(int id)
        {
            return await _context.Asignaturas.FindAsync(id);
        }

        public async Task AgregarAsignaturaAsync(Asignatura asignatura)
        {
            _context.Asignaturas.Add(asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsignaturaAsync(Asignatura asignatura)
        {
            _context.Asignaturas.Update(asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsignaturaAsync(int id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura != null)
            {
                _context.Asignaturas.Remove(asignatura);
                await _context.SaveChangesAsync();
            }
        }
    }
}