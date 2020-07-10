using System;
using System.Threading.Tasks;

using EfCodeFirstExercise.Controllers;
using EfCodeFirstExercise.Models;

namespace EfCodeFirstExercise {
    class Program {

        static async Task Main(string[] args) {
            await TestOrderlines();
            //await TestOrders();
            //await TestProduct();
            //await TestCustomer();
        }
        static async Task TestOrderlines() {
            var lineCtrl = new OrderlinesController();
            var orderline = new Orderline() {
                Id = 1, OrderId = 1, ProductId = 1, Quantity = 1
            };
            await lineCtrl.Change(orderline.Id, orderline);
            orderline = new Orderline() {
                Id = 0, OrderId = 1, ProductId = 3, Quantity = 3
            };
            //await lineCtrl.Create(orderline);
        }
        static async Task TestOrders() {
            var ordCtrl = new OrdersController();
            var orders = await ordCtrl.GetAll();
        }
        static async Task TestProduct() {
            var prodCtrl = new ProductsController();
            var prod = new Product() {
                Id = 0, Name = "Echo Show 5", Price = 129.99m, InStock = true
            };
            prod = await prodCtrl.Create(prod);
            prod.Price = 129.98m;
            await prodCtrl.Change(prod.Id, prod);
            await prodCtrl.Remove(prod.Id);
        }
        static async Task TestCustomer() {
            var custCtrl = new CustomersController();

            //var cust = new Customer() {
            //    Id = 0, Name = "Max Technical Training", State = "OH", 
            //    IsNationalAccount = false, TotalSales = 1000
            //};
            //cust = await custCtrl.Create(cust);

            //var customers = await custCtrl.GetAll();

            //var cust2 = await custCtrl.Get(1);

            await custCtrl.Remove(1);
        }
    }
}
