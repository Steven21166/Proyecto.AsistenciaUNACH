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

        public AsistenciaEstudianteController(IAsistenciaEstudianteRepositorio asistenciaRepositorio)
        {
            _asistenciaRepositorio = asistenciaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsistenciaEstudiante>>> ObtenerTodas()
        {
            var asistencias = await _asistenciaRepositorio.ObtenerAsistenciasAsync();
            return Ok(asistencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsistenciaEstudiante>> ObtenerPorId(int id)
        {
            var asistencia = await _asistenciaRepositorio.ObtenerAsistenciaPorIdAsync(id);

            if (asistencia == null)
                return NotFound();

            return Ok(asistencia);
        }

        [HttpPost]
        public async Task<ActionResult<AsistenciaEstudiante>> Crear(AsistenciaEstudiante asistencia)
        {
            await _asistenciaRepositorio.RegistrarAsistenciaAsync(asistencia);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = asistencia.IdAsistencia },
                asistencia
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, AsistenciaEstudiante asistencia)
        {
            if (id != asistencia.IdAsistencia)
                return BadRequest();

            try
            {
                await _asistenciaRepositorio.ActualizarAsistenciaAsync(asistencia);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}