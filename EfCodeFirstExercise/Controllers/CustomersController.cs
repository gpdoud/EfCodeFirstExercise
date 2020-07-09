using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EfCodeFirstExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstExercise.Controllers {
    
    public class CustomersController {

        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Customer>> GetAll() {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id) {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> Create(Customer customer) {
            if(customer == null) throw new Exception("Customer cannot be null");
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Change(int id, Customer customer) {
            if(customer == null) throw new Exception("Customer cannot be null");
            if(id != customer.Id) throw new Exception("Customer id does not match");

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Customer customer) {
            if(customer == null) throw new Exception("Customer cannot be null");
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var cust = Get(id);
            if(cust == null) throw new Exception("Customer does not exist");
            await Remove(cust.Result);
        }

        public CustomersController() {
            _context = new AppDbContext();
        }
    }
}
