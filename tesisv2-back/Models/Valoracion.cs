using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesisv2_back.Models
{
    public class Valoracion
    {
        public int Id { get; set; }  // ID de la valoración
        public string Usuario { get; set; }  // Usuario que hizo la valoración
        public DateTime Fecha { get; set; }  // Fecha de la valoración
        public string Texto { get; set; }  // Comentarios del usuario (opcional)
        public int Estrellas { get; set; } // En vez de 'Valoracion', usa 'Estrellas'



        // Relaciones con Playa o Actividad
        public int? PlayaId { get; set; }  // Relación con Playa
        public Playa? Playa { get; set; }  // Relación con el modelo Playa

        public int? ActividadId { get; set; }  // Relación con Actividad
        public Actividad? Actividad { get; set; }  // Relación con el modelo Actividad
    }
}
