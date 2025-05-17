using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models.Product;

namespace WebApplication7.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly ProductServise _productServise;

        #endregion

        #region Constructor

        public ProductController(ProductServise productServise)
        {
            _productServise = productServise;
        }

        #endregion

        #region List

        public IActionResult List()
        {
            List<Product> products = _productServise.GetProducts();
            return View(products);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel createProductViewModel)
        {
            var cleaned = createProductViewModel.Price.Replace(",", "");

            if (!decimal.TryParse(cleaned, out decimal priceDecimal))
            {
                return Content("❌ قیمت وارد شده نامعتبر است.");
            }

            CreateProductViewModel model = new CreateProductViewModel
            {
                Name = createProductViewModel.Name,
                Description = createProductViewModel.Description,
                Price = priceDecimal.ToString(),
            };

            _productServise.AddProduct(model);

            return RedirectToAction("List");
        }

        #endregion

        #region Update

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return BadRequest("آیدی معتبر نیست.");

            Product? product = _productServise.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            UpdateProductViewModel viewModel = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
                
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            var cleaned = updateProductViewModel.Price.Replace(",", "");

            if (!decimal.TryParse(cleaned, out decimal priceDecimal))
            {
                return Content("❌ قیمت وارد شده نامعتبر است.");
            }

            var model = new UpdateProductViewModel
            {
                Id = updateProductViewModel.Id,
                Name = updateProductViewModel.Name,
                Description = updateProductViewModel.Description,
                Price = priceDecimal.ToString(),
            };

            _productServise.UpdateProduct(model);

            return RedirectToAction("List");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _productServise.DeleteProduct(id);
            return RedirectToAction("List");
        }

        #endregion
    }
}
