using BusinessObject;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrdersByMemberID(int memberID) => OrderDAO.Instance.GetOrdersByMemberID(memberID);
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrders();
        public Order GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);  
        public void InsertOrder(Order order) => OrderDAO.Instance.AddOrder(order);
        public void DeleteOrder(int orderID) => OrderDAO.Instance.DeleteOrder(orderID);
        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
        public void DeleteOrderByMemberID(int memberID) => OrderDAO.Instance.DeleteOrderByMemberID(memberID);
        public bool CheckExistMember(int memberID) => OrderDAO.Instance.CheckExistOrder(memberID);
    }
}
