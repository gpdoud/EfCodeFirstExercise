using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EfCodeFirstExercise.Models;

using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstExercise.Controllers {

    public class OrderlinesController {

        private readonly AppDbContext _context = null;

        private async Task CalculateOrderTotal(int orderId) {

            var order = await _context.Orders.FindAsync(orderId);
            if(order == null) throw new Exception("Order not found for calc");
            order.Total = (from l in order.Orderlines
                           select new {
                               Subtotal = l.Quantity * l.Product.Price
                           }).Sum(x => x.Subtotal);
            await _context.SaveChangesAsync();
        }

        public async Task<Orderline> Get(int id) {
            return await _context.Orderlines.FindAsync(id);
        }

        public async Task<Orderline> Create(Orderline orderline) {
            if(orderline == null) throw new Exception();
            await _context.Orderlines.AddAsync(orderline);
            await _context.SaveChangesAsync();
            Refresh(orderline);
            await CalculateOrderTotal(orderline.OrderId);
            return orderline;
        }

        public async Task Change(int id, Orderline orderline) {
            if(orderline == null) throw new Exception();

            _context.Entry(orderline).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Refresh(orderline);
            await CalculateOrderTotal(orderline.OrderId);
        }

        private void Refresh(Orderline orderline) {
            _context.Entry(orderline).State = EntityState.Detached;
            _context.Orderlines.Find(orderline.Id);
        }

        public OrderlinesController() {
            _context = new AppDbContext();
        }
    }
}
