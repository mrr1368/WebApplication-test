namespace WebApplication7.Models.Product
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Price { get; set; }

        public string? CreatedAt { get; set; }  
    }
}
