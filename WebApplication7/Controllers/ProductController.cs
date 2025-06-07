using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models.Product;
using WebApplication7.Services.Intefaces;
using WebApplication7.ViewModels.Product;

namespace WebApplication7.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductController(IProductService productServise)
        {
            _productService = productServise;
        }

        #endregion

        #region List

        [HttpGet("/product-list")]
        public IActionResult List()
        {
            List<ProductViewModel> model = _productService.GetAll();
            return View(model);
        }

        #endregion

        #region Create

        [HttpGet("/product-Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/product-Create")]
        public IActionResult Create(CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createProductViewModel);
            }

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

            bool result = _productService.Create(model);

            if (result)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(createProductViewModel);
            }

        }

        #endregion

        #region Update

        [HttpGet("product-update/{productId?}")]
        public IActionResult Update(int productId)
        {
            if (productId <= 0)  
                BadRequest("آیدی معتبر نیست.");

            UpdateProductViewModel? model = _productService.GetForEdit(productId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet("product-update/{productId?}")]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProductViewModel);
            }

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

            bool result = _productService.Update(model);

            if (result)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }

        #endregion

        #region Delete

        //[HttpGet("/product-delete/{id?}")]
        //public IActionResult Delete(int id)
        //{
        //    _productServise.DeleteProduct(id);
        //    return RedirectToAction("List");
        //}

        #endregion
    }
}
