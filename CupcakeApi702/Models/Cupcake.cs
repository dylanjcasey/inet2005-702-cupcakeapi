namespace CupcakeApi702.Models
{
    public class Cupcake
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
