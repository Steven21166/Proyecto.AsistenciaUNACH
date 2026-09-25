using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarreraController : ControllerBase
    {
        private readonly ICarreraRepositorio _carreraRepositorio;

        public CarreraController(ICarreraRepositorio carreraRepositorio)
        {
            _carreraRepositorio = carreraRepositorio;
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<ActionResult<List<Carrera>>> ObtenerTodas()
        {
            var carreras = await _carreraRepositorio.ObtenerTodas();

            return Ok(carreras);
        }

        // GET: api/Carrera/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> ObtenerPorId(int id)
        {
            var carrera = await _carreraRepositorio.ObtenerPorId(id);

            if (carrera == null)
                return NotFound();

            return Ok(carrera);
        }

        // POST: api/Carrera
        [HttpPost]
        public async Task<ActionResult<Carrera>> Crear(Carrera carrera)
        {
            var nuevaCarrera = await _carreraRepositorio.Crear(carrera);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = nuevaCarrera.IdCarrera },
                nuevaCarrera
            );
        }

        // PUT: api/Carrera/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Carrera carrera)
        {
            if (id != carrera.IdCarrera)
                return BadRequest();

            var actualizado = await _carreraRepositorio.Actualizar(carrera);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Carrera/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _carreraRepositorio.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}