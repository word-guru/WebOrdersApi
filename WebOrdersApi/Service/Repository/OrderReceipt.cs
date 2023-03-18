using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebOrdersApi.Data.DB;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Models;
using WebOrdersApi.Service.Interface;

namespace WebOrdersApi.Service.Repository
{
    public class OrderReceipt : IOrderReceipt
    {
        private readonly AppDbContext _db;

        public OrderReceipt(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public Cheque GetOrderCheque(int id)
        {
            List<OrderProduct> newCheck = _db.OrderProducts.Where(el => el.OrderId == id).Include(p => p.Product).ToList();

            decimal totalSum = 0;

            foreach (var product in newCheck)
            {
                totalSum += product.Quantity * product.Product!.Price;
            }
            return new Cheque(newCheck, totalSum);
        }

        public async Task<IResult> GetOrderInfo(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(p => p.Id == id);

            if (order is null)
            {
                return Results.NotFound(new { message = $"заказ с ID = {id} отсутствует" });
            }

            // Получение расшивки с заказом и с данными о продукте
            var orderProducts = _db.OrderProducts
                .Where(op => op.OrderId == id)
                .Include(p => p.Product);

            // Информaция о заказе
            var orderInfo = new List<string>();

            // Общее количество товаров в заказе
            int productCounter = 0;

            orderInfo.Add($"Описание заказа: [{order.Description}]");

            foreach (var product in orderProducts)
            {
                orderInfo.Add(
                    $"Наименование товара: /{product.Product?.Name}/ | " +
                    $"Количество: /{product.Quantity} шт./"
                );
                productCounter += product.Quantity;
            }

            orderInfo.Add($"Всего товаров: {productCounter} шт.");

            return Results.Json(orderInfo);
        }
    }
}
