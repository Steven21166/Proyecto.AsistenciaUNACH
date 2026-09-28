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
            var asignaturas = await _asignaturaRepositorio.ObtenerAsignaturasAsync();
            return Ok(asignaturas);
        }

        // GET: api/Asignatura/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> ObtenerPorId(int id)
        {
            var asignatura = await _asignaturaRepositorio.ObtenerAsignaturaPorIdAsync(id);

            if (asignatura == null)
                return NotFound();

            return Ok(asignatura);
        }

        // POST: api/Asignatura
        [HttpPost]
        public async Task<ActionResult<Asignatura>> Crear(Asignatura asignatura)
        {
            await _asignaturaRepositorio.AgregarAsignaturaAsync(asignatura);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = asignatura.IdAsignatura },
                asignatura
            );
        }

        // PUT: api/Asignatura/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Asignatura asignatura)
        {
            if (id != asignatura.IdAsignatura)
                return BadRequest();

            try
            {
                await _asignaturaRepositorio.ActualizarAsignaturaAsync(asignatura);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Asignatura/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _asignaturaRepositorio.EliminarAsignaturaAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}