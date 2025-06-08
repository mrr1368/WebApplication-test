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
            List<ProductViewModel> model = _productService.GetAllProducts();
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
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _productService.CreateProduct(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }

            var priceErrors = ModelState["Price"]?.Errors;
            if (priceErrors != null && priceErrors.Any(e => e.ErrorMessage.Contains("not valid")))
            {
                ModelState["Price"]!.Errors.Clear();
                ModelState["Price"]!.Errors.Add("قیمت باید فقط عدد باشد، بدون حروف یا کاراکتر فارسی.");
            }

            return View(model);
        }

        #endregion

        #region Update

        [HttpGet("/product-update/{productId?}")]
        public IActionResult Update(int productId)
        {
            if (productId <= 0)
                BadRequest("آیدی معتبر نیست.");

            UpdateProductViewModel? model = _productService.GetProductForEdit(productId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost("/product-update/{productId?}")]
        public IActionResult Update(UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _productService.UpdateProduct(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }

            var priceErrors = ModelState["Price"]?.Errors;
            if (priceErrors != null && priceErrors.Any(e => e.ErrorMessage.Contains("not valid")))
            {
                ModelState["Price"]!.Errors.Clear();
                ModelState["Price"]!.Errors.Add("قیمت باید فقط عدد باشد، بدون حروف یا کاراکتر فارسی.");
            }

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet("/product-delete/{id?}")]
        public IActionResult Delete(int id)
        {
            bool result = _productService.DeleteProduct(id);
            if (result)
            {
                return RedirectToAction("List");
            }
            return NotFound("محصول مورد نظر یافت نشد.");
        }

        #endregion
    }
}
