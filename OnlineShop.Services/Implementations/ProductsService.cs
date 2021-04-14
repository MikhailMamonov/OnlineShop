
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlieShop.Domain.Models.Entities;

using OnlineShop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class ProductsService : IProductsService
    {
        ApplicationDbContext _db;

        public ProductsService(ApplicationDbContext db) {
            _db = db;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync() {
            return await  _db.Categories.ToListAsync();
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            if (product.Category == null)
            {
                Category category = _db.Categories.FirstOrDefault(category => category.Name == "Other");
                product.Category = category ?? new Category() { Name = "Other" };
            }

            _db.Products.Add(product);
            int addedRowsCount =await _db.SaveChangesAsync();
            return addedRowsCount>0;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            _db.Categories.Add(category);
            int addedRowsCount = await _db.SaveChangesAsync();
            return addedRowsCount > 0;
        }

        public async Task<bool> UpdateProductAsync(int id, Product product) 
        {
            var entity=await _db.Products.FindAsync(id);
            _db.Entry(entity).CurrentValues.SetValues(product);
            int updatedRowsCount= await _db.SaveChangesAsync();
            return updatedRowsCount > 0;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var entity =await _db.Categories.FindAsync(id);
            _db.Entry(entity).CurrentValues.SetValues(category);
            int updatedRowsCount =await _db.SaveChangesAsync();
            return updatedRowsCount > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id) 
        {
            var category =await _db.Categories.FindAsync(id);
            _db.Categories.Remove(category);
            int deletedRowsCount =await _db.SaveChangesAsync();
            return deletedRowsCount > 0;
        }
        public async Task<bool> DeleteProductAsync(int id) 
        {
            var product =await _db.Products.FindAsync(id);
            _db.Products.Remove(product);
            int deletedRowsCount =await _db.SaveChangesAsync();
            return deletedRowsCount > 0;
        }
    }
}
