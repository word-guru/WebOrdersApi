using System.Linq.Expressions;
using WebOrdersApi.Models;

namespace WebOrdersApi.Service.Interface
{
    public interface IOrderReceipt
    {
        public IResult GetOrderCheque(int id);
        public Task<IResult> GetOrderInfo(int id);

    }
}
