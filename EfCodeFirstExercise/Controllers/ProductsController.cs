using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EfCodeFirstExercise.Models;

using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstExercise.Controllers {
    
    public class ProductsController {

        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Product>> GetAll() {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id) {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product product) {
            if(product == null) throw new Exception("Product cannot be null");
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Change(int id, Product product) {
            if(product == null) throw new Exception("Product cannot be null");
            if(id != product.Id) throw new Exception("Product id does not match");

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Product product) {
            if(product == null) throw new Exception("Product cannot be null");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var cust = Get(id);
            if(cust == null) throw new Exception("Product does not exist");
            await Remove(cust.Result);
        }
        public ProductsController() {
            _context = new AppDbContext();
        }
    }
}
