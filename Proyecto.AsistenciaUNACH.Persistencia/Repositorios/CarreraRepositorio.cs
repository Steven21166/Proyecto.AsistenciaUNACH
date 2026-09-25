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

        public async Task<List<Carrera>> ObtenerTodas()
        {
            return await _context.Carreras
                .ToListAsync();
        }

        public async Task<Carrera?> ObtenerPorId(int id)
        {
            return await _context.Carreras
                .FirstOrDefaultAsync(c => c.IdCarrera == id);
        }

        public async Task<Carrera> Crear(Carrera carrera)
        {
            _context.Carreras.Add(carrera);

            await _context.SaveChangesAsync();

            return carrera;
        }

        public async Task<bool> Actualizar(Carrera carrera)
        {
            var existente = await _context.Carreras
                .FirstOrDefaultAsync(c => c.IdCarrera == carrera.IdCarrera);

            if (existente == null)
                return false;

            existente.CodigoCarrera = carrera.CodigoCarrera;
            existente.NombreCarrera = carrera.NombreCarrera;
            existente.Facultad = carrera.Facultad;
            existente.Modalidad = carrera.Modalidad;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var carrera = await _context.Carreras
                .FirstOrDefaultAsync(c => c.IdCarrera == id);

            if (carrera == null)
                return false;

            _context.Carreras.Remove(carrera);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}