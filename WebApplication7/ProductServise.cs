using WebApplication7.Models.Product;
using WebApplication7.Services.Intefaces;

namespace WebApplication7
{
    public class ProductServise : IProductService
    {
        #region Fields

        private static readonly List<Product> _products = [
            new() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.0m.ToString(), CreatedAt = DateTime.Now.ToString() },
            new() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.0m.ToString(), CreatedAt = DateTime.Now.ToString() },
            new() { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30.0m.ToString(), CreatedAt = DateTime.Now.ToString() }
        ];

        private static int currentId = 4;
        #endregion

        #region Read

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        #endregion

        #region Create

        public void AddProduct(CreateProductViewModel createProductViewModel)
        {
            Product product = new()
            {
                Id = currentId,
                Name = createProductViewModel.Name,
                Description = createProductViewModel.Description,
                Price = createProductViewModel.Price,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };

            _products.Add(product);

            currentId++;
        }

        #endregion

        #region Update

        public void UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            var existingProduct = GetProductById(updateProductViewModel.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = updateProductViewModel.Name;
            existingProduct.Description = updateProductViewModel.Description;
            existingProduct.Price = updateProductViewModel.Price;
        }

        #endregion

        #region Delete

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);

            if (product == null)
            {
                return;
            }

            _products.Remove(product);
        }

        #endregion
    }
}
