namespace BackofficeAPI.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
 
        public decimal Precio { get; set; }
        public int ClienteId { get; set; }
        public int MensajeroId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
