namespace WebOrdersApi.Model.Entity
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Article { get; set; }

        public Product(){}
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
