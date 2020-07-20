namespace NotatnikMechanika.Shared.Models.Commodity
{
    public class CommodityModel : ValidateModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
