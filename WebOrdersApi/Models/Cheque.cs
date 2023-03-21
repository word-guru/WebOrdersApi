using WebOrdersApi.Data.Entity;

namespace WebOrdersApi.Models
{
    public class Cheque
    {
        public List<OrderProduct> OrderProducts;
        public decimal Price;

        public Cheque(List<OrderProduct> _OrderProducts, decimal _Price)
        {
            OrderProducts = _OrderProducts;
            Price = _Price;
        }

        public override string ToString()
        {
            string text = "";
            foreach (var product in OrderProducts)
            {
                text += " " + product.Product!.Name + "\t\t" + product.Product.Price + "*" + product.Quantity + " = " +
                    product.Product.Price * product.Quantity + " руб." + "\n";
            }

            return $"{text} \n\n итого: {Price} рублей.";
        }
    }
}
