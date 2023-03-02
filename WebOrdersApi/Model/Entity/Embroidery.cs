namespace WebOrdersApi.Model.Entity
{
    public class Embroidery : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrdersId { get; set; }
        public int ProductId { get; set; }

        public Embroidery() { }
        public Embroidery(int id, int quantity, int ordersId, int productId)
        {
            Id = id;
            Quantity = quantity;
            OrdersId = ordersId;
            ProductId = productId;
        }

        public override string ToString() 
            => $"{Id} - {Quantity} - {OrdersId} - {ProductId}";
    }
}
