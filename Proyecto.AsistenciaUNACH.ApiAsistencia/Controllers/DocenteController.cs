using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocenteController : ControllerBase
    {
        private readonly IDocenteRepositorio _docenteRepositorio;

        public DocenteController(IDocenteRepositorio docenteRepositorio)
        {
            _docenteRepositorio = docenteRepositorio;
        }

        // GET: api/Docente
        [HttpGet]
        public async Task<ActionResult<List<Docente>>> ObtenerTodos()
        {
            var docentes = await _docenteRepositorio.ObtenerTodos();

            return Ok(docentes);
        }

        // GET: api/Docente/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> ObtenerPorId(int id)
        {
            var docente = await _docenteRepositorio.ObtenerPorId(id);

            if (docente == null)
                return NotFound();

            return Ok(docente);
        }

        // POST: api/Docente
        [HttpPost]
        public async Task<ActionResult<Docente>> Crear(Docente docente)
        {
            var nuevoDocente =
                await _docenteRepositorio.Crear(docente);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = nuevoDocente.IdDocente },
                nuevoDocente
            );
        }

        // PUT: api/Docente/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(
            int id,
            Docente docente)
        {
            if (id != docente.IdDocente)
                return BadRequest();

            var actualizado =
                await _docenteRepositorio.Actualizar(docente);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Docente/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado =
                await _docenteRepositorio.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}