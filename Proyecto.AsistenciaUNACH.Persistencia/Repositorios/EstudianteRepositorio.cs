using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class EstudianteRepositorio : IEstudianteRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public EstudianteRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> ObtenerEstudiantesAsync()
        {
            return await _context.Estudiantes.ToListAsync(); // O Estudiantes según lo que haya generado tu contexto
        }

        public async Task<Estudiante?> ObtenerEstudiantePorIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task AgregarEstudianteAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEstudianteAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEstudianteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }
    }
}