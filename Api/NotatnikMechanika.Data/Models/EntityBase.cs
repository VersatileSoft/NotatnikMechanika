namespace NotatnikMechanika.Data.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
