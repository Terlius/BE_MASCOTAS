using System.ComponentModel.DataAnnotations;

namespace BE_Mascotas.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Raza { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public float Peso { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }


    }
}
