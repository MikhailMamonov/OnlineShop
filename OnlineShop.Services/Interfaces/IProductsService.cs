using OnlieShop.Domain.Models.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services
{
    public interface IProductsService
    {
        public IEnumerable<Product> GetProducts();
        public Product AddProduct(Product product);
        public void AddCategory(Category category);
        public IEnumerable<Category> GetCategories();
        public void UpdateProduct(int id, Product product);
        public void UpdateCategory(int id, Category category);
        public void DeleteCategory(int id);
        public void DeleteProduct(int id);
    }
}
