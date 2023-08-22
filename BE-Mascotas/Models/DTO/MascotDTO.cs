using System.ComponentModel.DataAnnotations;

namespace BE_Mascotas.Models.DTO
{
    public class MascotDTO
    {
        public int Id { get; set; }
      
        public string Nombre { get; set; }

        
        public string Raza { get; set; }
       
        public string Color { get; set; }
      
        public int Edad { get; set; }
      
        public float Peso { get; set; }


    }
}
