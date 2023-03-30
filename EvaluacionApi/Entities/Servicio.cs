using System.ComponentModel.DataAnnotations;

namespace EvaluacionApi.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public int numeroHabitacion { get; set; }
        [Required]
        public string estado { get; set;; }
    }
}
