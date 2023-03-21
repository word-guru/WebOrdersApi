using Microsoft.EntityFrameworkCore;
using WebOrdersApi.Data.Entity;

namespace WebOrdersApi.Data.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<OrderProduct>? OrderProducts { get; set; }
        public DbSet<Order>? Orders { get; set; }



        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            string useConnection = configuration.GetSection("UseConnectionString").Value;
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(useConnection));
        }
    }
}
