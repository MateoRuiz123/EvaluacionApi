namespace EvaluacionApi.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? correo { get; set; }
        public string? contrasena { get; set; }
        public string? rol { get; set; }
        public int servicioId { get; set; }
        public Servicio? servicio { get; set; }
    }
}
