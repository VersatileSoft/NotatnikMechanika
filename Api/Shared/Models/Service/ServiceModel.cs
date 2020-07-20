namespace NotatnikMechanika.Shared.Models.Service
{
    public class ServiceModel : ValidateModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
