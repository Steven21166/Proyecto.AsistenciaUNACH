using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaEstudianteController : ControllerBase
    {
        private readonly IAsistenciaEstudianteRepositorio _asistenciaRepositorio;

        public AsistenciaEstudianteController(
            IAsistenciaEstudianteRepositorio asistenciaRepositorio)
        {
            _asistenciaRepositorio = asistenciaRepositorio;
        }

        // ============================================================
        // OBTENER TODAS LAS ASISTENCIAS
        // GET: api/AsistenciaEstudiante
        // ============================================================

        [HttpGet]
        public async Task<ActionResult<List<AsistenciaEstudiante>>> ObtenerTodas()
        {
            var asistencias =
                await _asistenciaRepositorio.ObtenerAsistenciasAsync();

            return Ok(asistencias);
        }

        // ============================================================
        // OBTENER ASISTENCIA POR ID
        // GET: api/AsistenciaEstudiante/{id}
        // ============================================================

        [HttpGet("{id}")]
        public async Task<ActionResult<AsistenciaEstudiante>> ObtenerPorId(int id)
        {
            var asistencia =
                await _asistenciaRepositorio.ObtenerAsistenciaPorIdAsync(id);

            if (asistencia == null)
                return NotFound();

            return Ok(asistencia);
        }

        // ============================================================
        // OBTENER HISTORIAL POR ASIGNATURA
        // GET: api/AsistenciaEstudiante/asignatura/{idAsignatura}
        // ============================================================

        [HttpGet("asignatura/{idAsignatura}")]
            public async Task<ActionResult<IEnumerable<AsistenciaEstudiante>>>
            ObtenerPorAsignatura(int idAsignatura)
             {
            var asistencias =
                await _asistenciaRepositorio
                    .ObtenerAsistenciasPorAsignaturaAsync(
                        idAsignatura);

            return Ok(asistencias);
        }

        // ============================================================
        // CREAR ASISTENCIA
        // POST: api/AsistenciaEstudiante
        // ============================================================

        [HttpPost]
        public async Task<ActionResult<AsistenciaEstudiante>> Crear(
            AsistenciaEstudiante asistencia)
        {
            await _asistenciaRepositorio
                .RegistrarAsistenciaAsync(asistencia);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = asistencia.IdAsistencia },
                asistencia
            );
        }

        // ============================================================
        // ACTUALIZAR ASISTENCIA
        // PUT: api/AsistenciaEstudiante/{id}
        // ============================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(
            int id,
            AsistenciaEstudiante asistencia)
        {
            if (id != asistencia.IdAsistencia)
                return BadRequest();

            try
            {
                await _asistenciaRepositorio
                    .ActualizarAsistenciaAsync(asistencia);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}