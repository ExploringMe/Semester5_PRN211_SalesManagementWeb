using BusinessObject;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Search(Expression<Func<Order, bool>> ex);
        IEnumerable<Order> GetOrdersByMemberID(int memberID);
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderID);
        void InsertOrder(Order order);
        void DeleteOrder(int orderID);
        void UpdateOrder(Order order);
        void DeleteOrderByMemberID(int memberID);
        dynamic GetMemberID();
    }
}
