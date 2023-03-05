using System.Text.Json.Serialization;

namespace WebOrdersApi.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int ClientId { get; set; }
        public Client? Clients { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public Order(){}
        public Order(int id, string? description, int clientId)
        {
            Id = id;
            Description = description;
            ClientId = clientId;
        }

        public override string ToString()
            => $"{Id} - {Description} - {ClientId}";
    }
}
