using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EfCodeFirstExercise.Models;

using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstExercise.Controllers {
    
    public class OrdersController {

        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Order>> GetAll() {
            return await _context.Orders.ToListAsync();
        }

        public OrdersController() {
            _context = new AppDbContext();
        }
    }
}
