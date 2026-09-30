using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;

namespace Proyecto.AsistenciaUNACH.Persistencia.Repositorios
{
    public class AsistenciaEstudianteRepositorio
        : IAsistenciaEstudianteRepositorio
    {
        private readonly AsistenciaUNACHContext _context;

        public AsistenciaEstudianteRepositorio(
            AsistenciaUNACHContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsistenciaEstudiante>>
            ObtenerAsistenciasAsync()
        {
            return await _context.AsistenciaEstudiantes
                .Include(a => a.IdEstudianteNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .ToListAsync();
        }

        // ============================================================
        // OBTENER ASISTENCIAS POR ASIGNATURA
        // ============================================================

        public async Task<IEnumerable<AsistenciaEstudiante>>
            ObtenerAsistenciasPorAsignaturaAsync(
                int idAsignatura)
        {
            var asistencias =
                await _context.AsistenciaEstudiantes
                    .Where(a =>
                        a.IdAsignatura == idAsignatura)
                    .Include(a =>
                        a.IdEstudianteNavigation)
                    .Include(a =>
                        a.IdAsignaturaNavigation)
                    .OrderByDescending(a =>
                        a.FechaAsistencia)
                    .ThenByDescending(a =>
                        a.HoraRegistro)
                    .ToListAsync();

            Console.WriteLine(
                "====================================");

            Console.WriteLine(
                $"HISTORIAL ASIGNATURA: {idAsignatura}");

            Console.WriteLine(
                $"REGISTROS ENCONTRADOS: {asistencias.Count}");

            foreach (var asistencia in asistencias)
            {
                Console.WriteLine(
                    $"Asistencia: "
                    + $"ID={asistencia.IdAsistencia} | "
                    + $"Estudiante={asistencia.IdEstudiante} | "
                    + $"Asignatura={asistencia.IdAsignatura} | "
                    + $"Estado={asistencia.EstadoAsistencia} | "
                    + $"Fecha={asistencia.FechaAsistencia} | "
                    + $"Hora={asistencia.HoraRegistro}");
            }

            Console.WriteLine(
                "====================================");

            return asistencias;
        }

        public async Task<AsistenciaEstudiante?>
            ObtenerAsistenciaPorIdAsync(int id)
        {
            return await _context.AsistenciaEstudiantes
                .FindAsync(id);
        }

        public async Task RegistrarAsistenciaAsync(
            AsistenciaEstudiante asistencia)
        {
            Console.WriteLine(
                "====================================");

            Console.WriteLine(
                "REGISTRANDO ASISTENCIA");

            Console.WriteLine(
                $"IdEstudiante: {asistencia.IdEstudiante}");

            Console.WriteLine(
                $"IdAsignatura: {asistencia.IdAsignatura}");

            Console.WriteLine(
                $"IdDocente: {asistencia.IdDocente}");

            Console.WriteLine(
                $"Fecha: {asistencia.FechaAsistencia}");

            Console.WriteLine(
                $"Hora: {asistencia.HoraRegistro}");

            Console.WriteLine(
                $"ESTADO: [{asistencia.EstadoAsistencia}]");

            Console.WriteLine(
                "====================================");

            _context.AsistenciaEstudiantes.Add(
                asistencia);

            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsistenciaAsync(
            AsistenciaEstudiante asistencia)
        {
            _context.AsistenciaEstudiantes.Update(
                asistencia);

            await _context.SaveChangesAsync();
        }
    }
}