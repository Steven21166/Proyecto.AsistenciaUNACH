using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class DetalleMatriculaRepositorio : IDetalleMatriculaRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public DetalleMatriculaRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleMatricula>> ObtenerMatriculasAsync()
        {
            return await _context.DetalleMatriculas
                .Include(d => d.IdEstudianteNavigation)
                .Include(d => d.IdAsignaturaNavigation)
                .ToListAsync();
        }

        public async Task<DetalleMatricula?> ObtenerMatriculaPorIdAsync(int id)
        {
            return await _context.DetalleMatriculas.FindAsync(id);
        }

        public async Task MatricularEstudianteAsync(DetalleMatricula detalleMatricula)
        {
            _context.DetalleMatriculas.Add(detalleMatricula);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarMatriculaAsync(int id)
        {
            var matricula = await _context.DetalleMatriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.DetalleMatriculas.Remove(matricula);
                await _context.SaveChangesAsync();
            }
        }
    }
}