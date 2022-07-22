using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetails(int orderID) => OrderDetailDAO.Instance.GetOrderDetails(orderID);
    }
}
