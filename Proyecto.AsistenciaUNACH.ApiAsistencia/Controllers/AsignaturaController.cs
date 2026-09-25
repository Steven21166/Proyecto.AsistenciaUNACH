using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignaturaController : ControllerBase
    {
        private readonly IAsignaturaRepositorio _asignaturaRepositorio;

        public AsignaturaController(IAsignaturaRepositorio asignaturaRepositorio)
        {
            _asignaturaRepositorio = asignaturaRepositorio;
        }

        // GET: api/Asignatura
        [HttpGet]
        public async Task<ActionResult<List<Asignatura>>> ObtenerTodas()
        {
            var asignaturas = await _asignaturaRepositorio.ObtenerTodas();

            return Ok(asignaturas);
        }

        // GET: api/Asignatura/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> ObtenerPorId(int id)
        {
            var asignatura = await _asignaturaRepositorio.ObtenerPorId(id);

            if (asignatura == null)
                return NotFound();

            return Ok(asignatura);
        }

        // POST: api/Asignatura
        [HttpPost]
        public async Task<ActionResult<Asignatura>> Crear(Asignatura asignatura)
        {
            var nuevaAsignatura =
                await _asignaturaRepositorio.Crear(asignatura);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = nuevaAsignatura.IdAsignatura },
                nuevaAsignatura
            );
        }

        // PUT: api/Asignatura/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(
            int id,
            Asignatura asignatura)
        {
            if (id != asignatura.IdAsignatura)
                return BadRequest();

            var actualizado =
                await _asignaturaRepositorio.Actualizar(asignatura);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Asignatura/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado =
                await _asignaturaRepositorio.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}