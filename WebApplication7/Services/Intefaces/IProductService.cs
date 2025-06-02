using WebApplication7.ViewModels.Product;

namespace WebApplication7.Services.Intefaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();

        ProductViewModel? GetById(int id);

        bool Create(CreateProductViewModel model);

        UpdateProductViewModel? GetForEdit(int id);

        bool Update(UpdateProductViewModel model);
    }
}
