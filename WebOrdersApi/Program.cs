using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;
using WebOrdersApi.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// добавление зависимостей

builder.Services.AddScoped<IDao<Client>, DbDao<Client>>();
builder.Services.AddScoped<IDao<Product>, DbDao<Product>>();
builder.Services.AddScoped<IDao<OrderProduct>, DbDao<OrderProduct>>();
builder.Services.AddScoped<IDao<Order>, DbDao<Order>>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента

//                                         -== CLIENT ==-

app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao)
    => await dao.GetAllAsync());
app.MapGet("/client/get", async (HttpContext context, int id, IDao<Client> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/client/update", async (HttpContext context, Client client, IDao<Client> dao)
    => await dao.UpdateAsync(client));
app.MapPost("/client/add", async (HttpContext context, Client client, IDao<Client> dao)
    => await dao.AddAsync(client));
app.MapPost("/client/delete", async (HttpContext context, int id, IDao<Client> dao)
    => await dao.DeleteAsync(id));

//                                         -== PRODUCT ==-

app.MapGet("/product/all", async (HttpContext context, IDao<Product> dao)
    => await dao.GetAllAsync());
app.MapGet("/product/get", async (HttpContext context, int id, IDao<Product> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/product/update", async (HttpContext context, Product product, IDao<Product> dao)
    => await dao.UpdateAsync(product));
app.MapPost("/product/add", async (HttpContext context, Product product, IDao<Product> dao)
    => await dao.AddAsync(product));
app.MapPost("/product/delete", async (HttpContext context, int id, IDao<Product> dao)
    => await dao.DeleteAsync(id));

//                                         -== OrderProduct ==-

app.MapGet("/embroidery/all", async (HttpContext context, IDao<OrderProduct> dao)
    => await dao.GetAllAsync());
app.MapGet("/embroidery/get", async (HttpContext context, int id, IDao<OrderProduct> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/embroidery/update", async (HttpContext context, OrderProduct embroidery, IDao<OrderProduct> dao)
    => await dao.UpdateAsync(embroidery));
app.MapPost("/embroidery/add", async (HttpContext context, OrderProduct embroidery, IDao<OrderProduct> dao)
    => await dao.AddAsync(embroidery));
app.MapPost("/embroidery/delete", async (HttpContext context, int id, IDao<OrderProduct> dao)
    => await dao.DeleteAsync(id));

//                                         -== ORDER ==-

app.MapGet("/order/all", async (HttpContext context, IDao<Order> dao)
    => await dao.GetAllAsync());
app.MapGet("/order/get", async (HttpContext context, int id, IDao<Order> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/order/update", async (HttpContext context, Order order, IDao<Order> dao)
    => await dao.UpdateAsync(order));
app.MapPost("/order/add", async (HttpContext context, Order order, IDao<Order> dao)
    => await dao.AddAsync(order));
app.MapPost("/order/delete", async (HttpContext context, int id, IDao<Order> dao)
    => await dao.DeleteAsync(id));

app.Run();
