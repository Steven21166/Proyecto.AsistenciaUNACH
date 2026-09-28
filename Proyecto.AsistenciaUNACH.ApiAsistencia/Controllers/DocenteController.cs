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
        private readonly IDocenteAsignaturaRepositorio _docenteAsignaturaRepositorio;

        public DocenteController(
            IDocenteRepositorio docenteRepositorio,
            IDocenteAsignaturaRepositorio docenteAsignaturaRepositorio)
        {
            _docenteRepositorio = docenteRepositorio;
            _docenteAsignaturaRepositorio = docenteAsignaturaRepositorio;
        }

        // GET: api/Docente
        [HttpGet]
        public async Task<ActionResult<List<Docente>>> ObtenerTodos()
        {
            var docentes = await _docenteRepositorio.ObtenerDocentesAsync();
            return Ok(docentes);
        }

        // GET: api/Docente/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> ObtenerPorId(int id)
        {
            var docente = await _docenteRepositorio.ObtenerDocentePorIdAsync(id);

            if (docente == null)
                return NotFound();

            return Ok(docente);
        }

        // POST: api/Docente
        [HttpPost]
        public async Task<ActionResult<Docente>> Crear(Docente docente)
        {
            // 1. Guardamos primero el docente para obtener su IdDocente generado
            await _docenteRepositorio.AgregarDocenteAsync(docente);

            // 2. Si vienen asignaturas asociadas en la colección, las registramos
            if (docente.DocenteAsignaturas != null && docente.DocenteAsignaturas.Any())
            {
                foreach (var asignacion in docente.DocenteAsignaturas)
                {
                    asignacion.IdDocente = docente.IdDocente;
                    await _docenteAsignaturaRepositorio.AsignarMateriaADocenteAsync(asignacion);
                }
            }

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = docente.IdDocente },
                docente
            );
        }

        // PUT: api/Docente/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Docente docente)
        {
            if (id != docente.IdDocente)
                return BadRequest();

            try
            {
                await _docenteRepositorio.ActualizarDocenteAsync(docente);

                // Opcional si en tu actualización de Blazor manejas también la lista de asignaturas:
                // Puedes limpiar las anteriores y volver a registrar las nuevas si tu lógica lo requiere.
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Docente/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _docenteRepositorio.EliminarDocenteAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}