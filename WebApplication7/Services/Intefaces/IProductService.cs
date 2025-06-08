using WebApplication7.ViewModels.Product;

namespace WebApplication7.Services.Intefaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();

        ProductViewModel? GetProductById(int id);

        bool CreateProduct(CreateProductViewModel model);

        UpdateProductViewModel? GetProductForEdit(int id);

        bool UpdateProduct(UpdateProductViewModel model);
    }
}
