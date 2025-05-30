﻿using System.Xml.Linq;
using WebApplication7.Context;
using WebApplication7.Models.Product;
using WebApplication7.Services.Intefaces;
using WebApplication7.ViewModels.Product;

namespace WebApplication7.Services.Implementations
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly ProductDbContext _context;

        #endregion

        #region Constructor

        public ProductService(ProductDbContext cnotext)
        {
            _context = cnotext;
        }

        #endregion

        #region Read

        public List<ProductViewModel> GetAll()
        {
            var products = _context.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CreatedAt = p.CreatedAt
                }
                ).ToList();
            return products;
        }

        public ProductViewModel? GetById(int id)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedAt = product.CreatedAt
            };
        }

        #endregion

        #region Create

        public bool Create(CreateProductViewModel model)
        {
            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };

            _context.Add(product);
            _context.SaveChanges();

            return true;

        }

        #endregion

        #region Update

        //public void UpdateProduct(UpdateProductViewModel updateProductViewModel)
        //{
        //    var existingProduct = GetProductById(updateProductViewModel.Id);

        //    if (existingProduct == null)
        //    {
        //        return;
        //    }

        //    existingProduct.Name = updateProductViewModel.Name;
        //    existingProduct.Description = updateProductViewModel.Description;
        //    existingProduct.Price = updateProductViewModel.Price;
        //}

        #endregion

        #region Delete

        //public void DeleteProduct(int id)
        //{
        //    var product = GetProductById(id);

        //    if (product == null)
        //    {
        //        return;
        //    }

        //    _products.Remove(product);
        //}

        #endregion
    }
}
