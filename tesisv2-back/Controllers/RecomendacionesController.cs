using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendacionesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCarrusel()
        {
            // Datos del carrusel dinámico
            var carruselItems = new List<object>
            {
                new { imagenUrl = "assets/img/carr1.jpg", Titulo = "Cuidar las playas", Descripcion = "Siempre recoge tus desechos y ayuda a mantener la playa limpia." },
                new { imagenUrl = "assets/img/carr2.jpg", Titulo = "Proteger la fauna", Descripcion = "No toques ni alimentes a los animales marinos." },
                new { imagenUrl = "assets/img/carr3.jpg", Titulo = "Evitar accidentes", Descripcion = "Presta atención a las señales y sigue las recomendaciones de los guardavidas." }
            };

            return Ok(carruselItems);
        }
    }
}