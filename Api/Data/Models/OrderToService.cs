namespace NotatnikMechanika.Data.Models
{
    public class OrderToService
    {
        public bool Finished { get; set; }
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
