namespace BackofficeAPI.Entities
{
    public class Recaudo

    {
        public int Id { get; set; }
        public int PaqueteId { get; set; }
        
        public decimal Valor { get; set; }
        public Boolean Pagado { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;




    }
}
