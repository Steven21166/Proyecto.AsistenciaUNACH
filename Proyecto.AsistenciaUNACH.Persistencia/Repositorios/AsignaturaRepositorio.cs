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

        public async Task<List<Asignatura>> ObtenerTodas()
        {
            return await _context.Asignaturas
                .ToListAsync();
        }

        public async Task<Asignatura?> ObtenerPorId(int id)
        {
            return await _context.Asignaturas
                .FirstOrDefaultAsync(a => a.IdAsignatura == id);
        }

        public async Task<Asignatura> Crear(Asignatura asignatura)
        {
            _context.Asignaturas.Add(asignatura);

            await _context.SaveChangesAsync();

            return asignatura;
        }

        public async Task<bool> Actualizar(Asignatura asignatura)
        {
            var existente = await _context.Asignaturas
                .FirstOrDefaultAsync(a => a.IdAsignatura == asignatura.IdAsignatura);

            if (existente == null)
                return false;

            existente.CodigoAsignatura = asignatura.CodigoAsignatura;
            existente.NombreAsignatura = asignatura.NombreAsignatura;
            existente.Semestre = asignatura.Semestre;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var asignatura = await _context.Asignaturas
                .FirstOrDefaultAsync(a => a.IdAsignatura == id);

            if (asignatura == null)
                return false;

            _context.Asignaturas.Remove(asignatura);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}