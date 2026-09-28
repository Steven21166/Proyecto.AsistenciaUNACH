using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class CarreraRepositorio : ICarreraRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public CarreraRepositorio(AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carrera>> ObtenerCarrerasAsync()
        {
            return await _context.Carreras.ToListAsync();
        }

        public async Task<Carrera?> ObtenerCarreraPorIdAsync(int id)
        {
            return await _context.Carreras.FindAsync(id);
        }

        public async Task AgregarCarreraAsync(Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCarreraAsync(Carrera carrera)
        {
            _context.Carreras.Update(carrera);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCarreraAsync(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
                await _context.SaveChangesAsync();
            }
        }
    }
}