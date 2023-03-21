using System.Text.Json.Serialization;

namespace WebOrdersApi.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Article { get; set; }
        [JsonIgnore]
        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public Product() { }
        public Product(int id, string? name, int article)
        {
            Id = id;
            Name = name;
            Article = article;
        }

        public override string ToString()
            => $"{Id} - {Name} - {Article}";

    }
}
