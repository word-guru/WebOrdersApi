using System.Text.Json.Serialization;
using WebOrdersApi.Data.DB;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Service.IRepository;
using WebOrdersApi.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// добавление зависимостей

/*builder.Services.AddScoped<IGRepository<Client>, GRepository<Client>>();
builder.Services.AddScoped<IGRepository<Product>, GRepository<Product>>();
builder.Services.AddScoped<IGRepository<OrderProduct>, GRepository<OrderProduct>>();
builder.Services.AddScoped<IGRepository<Order>, GRepository<Order>>();*/

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента

//                                         -== CLIENT ==-

app.MapGet("/client/all", async (HttpContext context, IGRepository<Client> dao)
    => await dao.GetAllAsync());
app.MapGet("/client/get", async (HttpContext context, int id, IGRepository<Client> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/client/update", async (HttpContext context, Client client, IGRepository<Client> dao)
    => await dao.UpdateAsync(client));
app.MapPost("/client/add", async (HttpContext context, Client client, IGRepository<Client> dao)
    => await dao.AddAsync(client));
app.MapPost("/client/delete", async (HttpContext context, int id, IGRepository<Client> dao)
    => await dao.DeleteAsync(id));

//                                         -== PRODUCT ==-

app.MapGet("/product/all", async (HttpContext context, IGRepository<Product> dao)
    => await dao.GetAllAsync());
app.MapGet("/product/get", async (HttpContext context, int id, IGRepository<Product> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/product/update", async (HttpContext context, Product product, IGRepository<Product> dao)
    => await dao.UpdateAsync(product));
app.MapPost("/product/add", async (HttpContext context, Product product, IGRepository<Product> dao)
    => await dao.AddAsync(product));
app.MapPost("/product/delete", async (HttpContext context, int id, IGRepository<Product> dao)
    => await dao.DeleteAsync(id));

//                                         -== OrderProduct ==-

app.MapGet("/embroidery/all", async (HttpContext context, IGRepository<OrderProduct> dao)
    => await dao.GetAllAsync());
app.MapGet("/embroidery/get", async (HttpContext context, int id, IGRepository<OrderProduct> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/embroidery/update", async (HttpContext context, OrderProduct embroidery, IGRepository<OrderProduct> dao)
    => await dao.UpdateAsync(embroidery));
app.MapPost("/embroidery/add", async (HttpContext context, OrderProduct embroidery, IGRepository<OrderProduct> dao)
    => await dao.AddAsync(embroidery));
app.MapPost("/embroidery/delete", async (HttpContext context, int id, IGRepository<OrderProduct> dao)
    => await dao.DeleteAsync(id));


//                                         -== ORDER ==-

app.MapGet("/order/all", async (HttpContext context, IGRepository<Order> dao)
    => await dao.GetAllAsync());
app.MapGet("/order/get", async (HttpContext context, int id, IGRepository<Order> dao)
    => await dao.GetByIdAsync(id));
app.MapPost("/order/update", async (HttpContext context, Order order, IGRepository<Order> dao)
    => await dao.UpdateAsync(order));
app.MapPost("/order/add", async (HttpContext context, Order order, IGRepository<Order> dao)
    => await dao.AddAsync(order));
app.MapPost("/order/delete", async (HttpContext context, int id, IGRepository<Order> dao)
    => await dao.DeleteAsync(id));
app.MapGet("/order/get_include", async (HttpContext context, IGRepository<Order> dao)
    => await dao.GetWithIncludeAsync(u => u.Clients));


app.Run();
