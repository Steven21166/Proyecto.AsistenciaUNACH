using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;

        public EstudianteController(IEstudianteRepositorio estudianteRepositorio)
        {
            _estudianteRepositorio = estudianteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> ObtenerTodas()
        {
            var estudiantes = await _estudianteRepositorio.ObtenerEstudiantesAsync();
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> ObtenerPorId(int id)
        {
            var estudiante = await _estudianteRepositorio.ObtenerEstudiantePorIdAsync(id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> Crear(Estudiante estudiante)
        {
            await _estudianteRepositorio.AgregarEstudianteAsync(estudiante);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = estudiante.IdEstudiante },
                estudiante
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
                return BadRequest();

            try
            {
                await _estudianteRepositorio.ActualizarEstudianteAsync(estudiante);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _estudianteRepositorio.EliminarEstudianteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}