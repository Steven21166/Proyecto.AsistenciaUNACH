using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class AsistenciaEstudianteRepositorio : IAsistenciaEstudianteRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public AsistenciaEstudianteRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsistenciaEstudiante>> ObtenerAsistenciasAsync()
        {
            return await _context.AsistenciaEstudiantes
                .Include(a => a.IdEstudianteNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .ToListAsync();
        }

        public async Task<AsistenciaEstudiante?> ObtenerAsistenciaPorIdAsync(int id)
        {
            return await _context.AsistenciaEstudiantes.FindAsync(id);
        }

        public async Task RegistrarAsistenciaAsync(AsistenciaEstudiante asistencia)
        {
            _context.AsistenciaEstudiantes.Add(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsistenciaAsync(AsistenciaEstudiante asistencia)
        {
            _context.AsistenciaEstudiantes.Update(asistencia);
            await _context.SaveChangesAsync();
        }
    }
}