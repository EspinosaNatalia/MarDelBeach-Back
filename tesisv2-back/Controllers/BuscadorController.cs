using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Text;
using tesisv2_back.Data;

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuscadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BuscadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Buscar(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("El término de búsqueda no puede estar vacío.");

            // Normalizamos el término de búsqueda
            var queryNormalizado = QuitarTildes(q.ToLower().Trim());

            // Obtener y normalizar todas las playas
            var resultadosPlayas = _context.Playa // Cambiado a singular y minúscula
                .AsEnumerable()
                .Where(p =>
                    !string.IsNullOrEmpty(p.Nombre) && QuitarTildes(p.Nombre.ToLower()).Contains(queryNormalizado) ||
                    !string.IsNullOrEmpty(p.Zona) && QuitarTildes(p.Zona.ToLower()).Contains(queryNormalizado))
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Zona,
                    Imagen = p.Imagenes ?? "default.jpg",
                    p.PromedioValoracion,
                    Tipo = "Playa"
                })
                .ToList();

            // Obtener y normalizar todas las actividades
            var resultadosActividades = _context.Actividad // Cambiado a singular y minúscula
                .AsEnumerable()
                .Where(a =>
                    !string.IsNullOrEmpty(a.Nombre) && QuitarTildes(a.Nombre.ToLower()).Contains(queryNormalizado) ||
                    !string.IsNullOrEmpty(a.Descripcion) && QuitarTildes(a.Descripcion.ToLower()).Contains(queryNormalizado) ||
                    !string.IsNullOrEmpty(a.Zona) && QuitarTildes(a.Zona.ToLower()).Contains(queryNormalizado))
                .Select(a => new
                {
                    a.Id,
                    a.Nombre,
                    a.Zona,
                    Imagen = a.Imagen ?? "default.jpg",
                    a.PromedioValoracion,
                    Tipo = "Actividad"
                })
                .ToList();

            // Combinar resultados
            var resultados = resultadosPlayas.Union(resultadosActividades).ToList();

            if (!resultados.Any())
                return NotFound("No se encontraron resultados para tu búsqueda.");

            return Ok(resultados);
        }

        // Método para eliminar tildes y normalizar texto
        private string QuitarTildes(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;

            return string.Concat(
                texto.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            ).Normalize(NormalizationForm.FormC);
        }
    }
}
