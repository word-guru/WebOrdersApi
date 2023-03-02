namespace WebOrdersApi.Model.Entity
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

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
