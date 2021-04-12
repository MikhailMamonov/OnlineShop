
using AutoMapper;

using OnlieShop.Domain.Models.Entities;

using OnlineShop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Services
{
    public class ProductsService : IProductsService
    {
        ApplicationDbContext _db;
        public ProductsService(ApplicationDbContext db, IMapper mapper) {
            _db = db;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products;
        }

        public IEnumerable<Category> GetCategories() {
            return _db.Categories;
        }

        public Product AddProduct(Product product)
        {
            if (product.Category == null)
            {
                Category category = _db.Categories.FirstOrDefault(category => category.Name == "Other");
                product.Category = category ?? new Category() { Name = "Other" };
            }

            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void UpdateProduct(int id, Product product) 
        {
            var entity=_db.Products.Find(id);
            _db.Entry(entity).CurrentValues.SetValues(product);
            _db.SaveChanges();
        }

        public void UpdateCategory(int id, Category category)
        {
            var entity = _db.Categories.Find(id);
            _db.Entry(entity).CurrentValues.SetValues(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id) 
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
        public void DeleteProduct(int id) 
        {
            var product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
