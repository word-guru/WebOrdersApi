using Microsoft.AspNetCore.Builder;
using System.Text.Json.Serialization;
using WebOrdersApi.Data.DB;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Service.Interface;
using WebOrdersApi.Service.IRepository;
using WebOrdersApi.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// добавление зависимостей

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderReceipt, OrderReceipt>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/", () => "Hello World!");


// тестирование операций с таблицей клиента

//тестирование запроса на получение информации о товаре
app.MapGet("order/info", async (HttpContext context, IOrderReceipt dao, int id) =>
{
    return await dao.GetOrderInfo(id);
});
//тестирование запроса на получение чека с заказом
app.MapGet("/order/check", (HttpContext context, IOrderReceipt dao, int id) =>
{
    return dao.GetOrderCheque(id).ToString();
});

//                                         -== CLIENT ==-

app.MapGet("/client/all", async (HttpContext context, IUnitOfWork dao)
    => await dao.Clients.GetAllAsync());
app.MapPost("/client/update", async (HttpContext context, Client client, IUnitOfWork dao)
    => await dao.Clients.UpdateAsync(client));
app.MapPost("/client/add", async (HttpContext context, Client client, IUnitOfWork dao)
    => await dao.Clients.AddAsync(client));
app.MapPost("/client/delete", async (HttpContext context, int id, IUnitOfWork dao)
    => await dao.Clients.DeleteAsync(id));

//                                         -== PRODUCT ==-

app.MapGet("/product/all", async (HttpContext context, IUnitOfWork dao)
    => await dao.Products.GetAllAsync());

app.MapPost("/product/update", async (HttpContext context, Product product, IUnitOfWork dao)
    => await dao.Products.UpdateAsync(product));
app.MapPost("/product/add", async (HttpContext context, Product product, IUnitOfWork dao)
    => await dao.Products.AddAsync(product));
app.MapPost("/product/delete", async (HttpContext context, int id, IUnitOfWork dao)
    => await dao.Products.DeleteAsync(id));

//                                         -== OrderProduct ==-

app.MapGet("/embroidery/all", async (HttpContext context, IUnitOfWork dao)
    => await dao.OrderProducts.GetAllAsync());
app.MapPost("/embroidery/update", async (HttpContext context, OrderProduct embroidery, IUnitOfWork dao)
    => await dao.OrderProducts.UpdateAsync(embroidery));
app.MapPost("/embroidery/add", async (HttpContext context, OrderProduct embroidery, IUnitOfWork dao)
    => await dao.OrderProducts.AddAsync(embroidery));
app.MapPost("/embroidery/delete", async (HttpContext context, int id, IUnitOfWork dao)
    => await dao.OrderProducts.DeleteAsync(id));


//                                         -== ORDER ==-

app.MapGet("/order/all", async (HttpContext context, IUnitOfWork dao)
    => await dao.Orders.GetAllAsync());
app.MapPost("/order/update", async (HttpContext context, Order order, IUnitOfWork dao)
    => await dao.Orders.UpdateAsync(order));
app.MapPost("/order/add", async (HttpContext context, Order order, IUnitOfWork dao)
    => await dao.Orders.AddAsync(order));
app.MapPost("/order/delete", async (HttpContext context, int id, IUnitOfWork dao)
    => await dao.Orders.DeleteAsync(id));



app.Run();
