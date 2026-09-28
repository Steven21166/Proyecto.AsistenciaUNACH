using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleMatriculaController : ControllerBase
    {
        private readonly IDetalleMatriculaRepositorio _detalleMatriculaRepositorio;

        public DetalleMatriculaController(IDetalleMatriculaRepositorio detalleMatriculaRepositorio)
        {
            _detalleMatriculaRepositorio = detalleMatriculaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleMatricula>>> ObtenerTodas()
        {
            var matriculas = await _detalleMatriculaRepositorio.ObtenerMatriculasAsync();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleMatricula>> ObtenerPorId(int id)
        {
            var matricula = await _detalleMatriculaRepositorio.ObtenerMatriculaPorIdAsync(id);

            if (matricula == null)
                return NotFound();

            return Ok(matricula);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleMatricula>> Crear(DetalleMatricula detalleMatricula)
        {
            await _detalleMatriculaRepositorio.MatricularEstudianteAsync(detalleMatricula);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = detalleMatricula.IdMatricula }, // Corregido a IdMatricula
                detalleMatricula
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _detalleMatriculaRepositorio.EliminarMatriculaAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}