using System.Text.Json.Serialization;

namespace WebOrdersApi.Data.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        public Client() { }
        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
