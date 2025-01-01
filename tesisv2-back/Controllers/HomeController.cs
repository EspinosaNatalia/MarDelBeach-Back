using Microsoft.AspNetCore.Mvc;
using tesisv2_back.Models; 

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        // Método para obtener las secciones de la Home
        [HttpGet]
        public IActionResult GetSections()
        {
            // Datos estáticos por ahora
            var sections = new List<HomeSection>
            {
                new HomeSection
                {
                    Nombre = "Playas",
                    Ruta = "/playas",
                    Imagen = "assets/img/mar.jpg"
                },
                new HomeSection
                {
                    Nombre = "Actividades",
                    Ruta = "/actividades",
                    Imagen = "assets/img/actividades.jpg"
                },
                new HomeSection
                {
                    Nombre = "Recomendaciones",
                    Ruta = "/recomendaciones",
                    Imagen = "assets/img/recomendaciones.jpeg"
                }
            };

            return Ok(sections);
        }
    }
}
