using Microsoft.EntityFrameworkCore;
using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Embroidery>? Embroideries { get; set; }
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
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
