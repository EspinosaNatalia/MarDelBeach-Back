namespace tesisv2_back.Models
{
    public class HomeSection
    {
        public int Id { get; set; } // Agregué Id para consistencia
        public string Nombre { get; set; } = string.Empty;
        public string Ruta { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
    }
}
