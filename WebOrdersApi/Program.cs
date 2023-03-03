using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;
using WebOrdersApi.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// добавление зависимостей

builder.Services.AddScoped<IDao<Client>, DbDao<Client>>();
builder.Services.AddScoped<IDao<Product>, DbDao<Product>>();
builder.Services.AddScoped<IDao<Embroidery>, DbDao<Embroidery>>();
builder.Services.AddScoped<IDao<Order>, DbDao<Order>>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента

//                                         -== CLIENT ==-

app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao)
    => await dao.GetAll());
app.MapGet("/client/get", async (HttpContext context, int id, IDao<Client> dao)
    => await dao.GetById(id));
app.MapPost("/client/update", async (HttpContext context, Client client, IDao<Client> dao)
    => await dao.Update(client));
app.MapPost("/client/add", async (HttpContext context, Client client, IDao<Client> dao)
    => await dao.Add(client));
app.MapPost("/client/delete", async (HttpContext context, int id, IDao<Client> dao)
    => await dao.Delete(id));

//                                         -== PRODUCT ==-

app.MapGet("/product/all", async (HttpContext context, IDao<Product> dao)
    => await dao.GetAll());
app.MapGet("/product/get", async (HttpContext context, int id, IDao<Product> dao)
    => await dao.GetById(id));
app.MapPost("/product/update", async (HttpContext context, Product product, IDao<Product> dao)
    => await dao.Update(product));
app.MapPost("/product/add", async (HttpContext context, Product product, IDao<Product> dao)
    => await dao.Add(product));
app.MapPost("/product/delete", async (HttpContext context, int id, IDao<Product> dao)
    => await dao.Delete(id));

//                                         -== Embroidery ==-

app.MapGet("/embroidery/all", async (HttpContext context, IDao<Embroidery> dao)
    => await dao.GetAll());
app.MapGet("/embroidery/get", async (HttpContext context, int id, IDao<Embroidery> dao)
    => await dao.GetById(id));
app.MapPost("/embroidery/update", async (HttpContext context, Embroidery embroidery, IDao<Embroidery> dao)
    => await dao.Update(embroidery));
app.MapPost("/embroidery/add", async (HttpContext context, Embroidery embroidery, IDao<Embroidery> dao)
    => await dao.Add(embroidery));
app.MapPost("/embroidery/delete", async (HttpContext context, int id, IDao<Embroidery> dao)
    => await dao.Delete(id));

//                                         -== ORDER ==-

app.MapGet("/order/all", async (HttpContext context, IDao<Order> dao)
    => await dao.GetAll());
app.MapGet("/order/get", async (HttpContext context, int id, IDao<Order> dao)
    => await dao.GetById(id));
app.MapPost("/order/update", async (HttpContext context, Order order, IDao<Order> dao)
    => await dao.Update(order));
app.MapPost("/order/add", async (HttpContext context, Order order, IDao<Order> dao)
    => await dao.Add(order));
app.MapPost("/order/delete", async (HttpContext context, int id, IDao<Order> dao)
    => await dao.Delete(id));

app.Run();
