namespace WebApplication7.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public Decimal? Price { get; set; }

        public required DateTime CreatedAt { get; set; }
    }
}
