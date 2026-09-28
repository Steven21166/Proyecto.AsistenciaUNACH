using Microsoft.AspNetCore.Mvc;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

namespace Proyecto.AsistenciaUNACH.ApiAsistencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocenteAsignaturaController : ControllerBase
    {
        private readonly IDocenteAsignaturaRepositorio _docenteAsignaturaRepositorio;

        public DocenteAsignaturaController(IDocenteAsignaturaRepositorio docenteAsignaturaRepositorio)
        {
            _docenteAsignaturaRepositorio = docenteAsignaturaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocenteAsignatura>>> ObtenerTodas()
        {
            var asignaciones = await _docenteAsignaturaRepositorio.ObtenerAsignacionesAsync();
            return Ok(asignaciones);
        }

        [HttpPost]
        public async Task<ActionResult<DocenteAsignatura>> Crear(DocenteAsignatura docenteAsignatura)
        {
            await _docenteAsignaturaRepositorio.AsignarMateriaADocenteAsync(docenteAsignatura);
            return Ok(docenteAsignatura);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _docenteAsignaturaRepositorio.EliminarAsignacionAsync(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}