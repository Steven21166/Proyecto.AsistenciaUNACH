using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class DocenteRepositorio : IDocenteRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public DocenteRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Docente>> ObtenerDocentesAsync()
        {
            return await _context.Docentes
                .Include(d => d.IdCarreraNavigation)
                .ToListAsync();
        }

        public async Task<Docente?> ObtenerDocentePorIdAsync(int id)
        {
            return await _context.Docentes
                .Include(d => d.IdCarreraNavigation)
                .FirstOrDefaultAsync(d => d.IdDocente == id);
        }

        public async Task AgregarDocenteAsync(Docente docente)
        {
            _context.Docentes.Add(docente);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarDocenteAsync(Docente docente)
        {
            _context.Docentes.Update(docente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarDocenteAsync(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            if (docente != null)
            {
                _context.Docentes.Remove(docente);
                await _context.SaveChangesAsync();
            }
        }
    }
}