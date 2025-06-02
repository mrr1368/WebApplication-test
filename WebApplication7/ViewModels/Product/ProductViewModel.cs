namespace WebApplication7.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public required string Price { get; set; }
        public string? CreatedAt { get; set; }
    }
}
