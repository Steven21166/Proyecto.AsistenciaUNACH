using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Docente/login?correo=...&cedula=...
        [HttpGet("login")]
        public async Task<ActionResult<Docente>> LoginDocente([FromQuery] string correo, [FromQuery] string cedula)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(cedula))
            {
                return BadRequest(new { mensaje = "El correo y la cédula son obligatorios." });
            }

            var docentes = await _docenteRepositorio.ObtenerDocentesAsync();

            var docente = docentes.FirstOrDefault(d =>
                !string.IsNullOrEmpty(d.Correo) &&
                !string.IsNullOrEmpty(d.Cedula) &&
                d.Correo.Trim().ToLower() == correo.Trim().ToLower() &&
                d.Cedula.Trim() == cedula.Trim()
            );

            if (docente == null)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas (Correo o Cédula inválidos)." });
            }

            return Ok(docente);
        }

        // POST: api/Docente
        [HttpPost]
        public async Task<ActionResult<Docente>> Crear(Docente docente)
        {
            await _docenteRepositorio.AgregarDocenteAsync(docente);

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