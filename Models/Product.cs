namespace NextGenInventories_2._0.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Measurement { get; set; }
        public string? MeasurementType { get; set; }
        public string? ProductType { get; set; }
    }
}
