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

        public async Task<List<Docente>> ObtenerTodos()
        {
            return await _context.Docentes
                .Include(d => d.IdCarreraNavigation)
                .Include(d => d.IdAsignaturaNavigation)
                .ToListAsync();
        }

        public async Task<Docente?> ObtenerPorId(int id)
        {
            return await _context.Docentes
                .Include(d => d.IdCarreraNavigation)
                .Include(d => d.IdAsignaturaNavigation)
                .FirstOrDefaultAsync(d => d.IdDocente == id);
        }

        public async Task<Docente> Crear(Docente docente)
        {
            _context.Docentes.Add(docente);

            await _context.SaveChangesAsync();

            return docente;
        }

        public async Task<bool> Actualizar(Docente docente)
        {
            var existente = await _context.Docentes
                .FirstOrDefaultAsync(d => d.IdDocente == docente.IdDocente);

            if (existente == null)
                return false;

            existente.Nombres = docente.Nombres;
            existente.Apellidos = docente.Apellidos;
            existente.Cedula = docente.Cedula;
            existente.Celular = docente.Celular;
            existente.Correo = docente.Correo;
            existente.IdCarrera = docente.IdCarrera;
            existente.IdAsignatura = docente.IdAsignatura;
            existente.FechaAsistencia = docente.FechaAsistencia;
            existente.HoraEntrada = docente.HoraEntrada;
            existente.HoraSalida = docente.HoraSalida;
            existente.EstadoAsistencia = docente.EstadoAsistencia;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var docente = await _context.Docentes
                .FirstOrDefaultAsync(d => d.IdDocente == id);

            if (docente == null)
                return false;

            _context.Docentes.Remove(docente);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}