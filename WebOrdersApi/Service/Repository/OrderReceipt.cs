using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebOrdersApi.Data.DB;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Models;
using WebOrdersApi.Service.Interface;
using WebOrdersApi.Service.IRepository;

namespace WebOrdersApi.Service.Repository
{
    public class OrderReceipt : IOrderReceipt
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unit;

        public OrderReceipt(AppDbContext appDbContext, IUnitOfWork unit)
        {
            _db = appDbContext;
            _unit = unit;
        }

        public IResult GetOrderCheque(int id)
        {
            var newCheck = _db.OrderProducts.Where(el => el.OrderId == id).Include(p => p.Product).ToList();
            

            decimal totalSum = 0;

            foreach (var product in newCheck)
            {
                totalSum += product.Quantity * product.Product!.Price;
            }

            var responce = new 
            { 
              Check = newCheck,
              FullSum = newCheck.Sum(c => c.Quantity * c.Product!.Price),
            };
            //return new Cheque(newCheck, totalSum);
            return Results.Json(responce);
        }

        public async Task<IResult> GetOrderInfo(int id)
        {
            //var order = await _db.Orders.FirstOrDefaultAsync(p => p.Id == id);
            var order = await _unit.Orders.GetByIdAsync(p => p.Id == id);

            if (order is null)
            {
                return Results.NotFound(new { message = $"заказ с ID = {id} отсутствует" });
            }

            // Получение расшивки с заказом и с данными о продукте
            var orderProducts = _db.OrderProducts
                .Where(op => op.OrderId == id)
                .Include(p => p.Product);

            //var orderProducts = await _unit.OrderProducts.GetByIdAsync(op => op.OrderId == id, new List<string> { "Products" });

            var response = new 
            { 
                Description = order.Description,
                Name = orderProducts.Select(p => p.Product.Name).ToList(),
                Count = orderProducts.Sum(p => p.Quantity)
            
            };

            return Results.Json(response);
        }
    }
}
