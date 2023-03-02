namespace WebOrdersApi.Model.Entity
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int ClientId { get; set; }

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
