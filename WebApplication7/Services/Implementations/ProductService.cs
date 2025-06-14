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

        public List<ProductViewModel> GetAllProducts()
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

        public ProductViewModel? GetProductById(int id)
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

        public bool CreateProduct(CreateProductViewModel model)
        {
            _context.Products.Add(new()
            {
                Name = model.Name!,
                Description = model.Description,
                Price = model.Price,
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
            return true;

        }

        #endregion

        #region Update

        public UpdateProductViewModel? GetProductForEdit(int id)
        {
            return _context.Products
                .Select(p => new UpdateProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(UpdateProductViewModel model)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.Id == model.Id);

            if (product == null) { return false; }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;

            _context.Products.Update(product);
            _context.SaveChanges();

            return true;
        }

        #endregion

        #region Delete

        public bool DeleteProduct(int id)
        {
            Product? product = _context.Products
               .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }

        #endregion
    }
}
