using BusinessObject;

namespace DataAccess
{
    public class OrderDAO
    {
        FStoreContext FStoreDB;
        public OrderDAO()
        {
            FStoreDB = new FStoreContext();
        }

        public static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public dynamic GetMemberID()
        {
            var memberIDList = FStoreDB.Members.Select(m => new
            {
                m.MemberId
            }).ToList();
            return memberIDList;
        }

        public Order GetOrderByID(int OrderID)
        {
            Order order = null;
            foreach (Order o in FStoreDB.Orders)
            {
                if (o.OrderId == OrderID)
                    order = o;
            }
            return order;
        }
        public IEnumerable<Order> GetOrdersByMemberID(int memberID)
        {
            try
            {
                var orders = new List<Order>();
                foreach (var o in FStoreDB.Orders)
                {
                    if (memberID == o.MemberId)
                    {
                        orders.Add(o);
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();
            foreach (var o in FStoreDB.Orders)
            {
                orders.Add(o);
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            try
            {
                order.OrderId = 0;
                FStoreDB.Orders.Add(order);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateOrder(Order order)
        {
            try
            {
                var o = GetOrderByID(order.OrderId);
                o.MemberId = order.MemberId;
                o.OrderDate = order.OrderDate;
                o.RequiredDate = order.RequiredDate;
                o.ShippedDate = order.ShippedDate;
                o.Freight = order.Freight;
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrder(int orderID)
        {
            try
            {
                DeleteOrderDetailByOrderID(orderID);
                Order order = GetOrderByID(orderID);
                FStoreDB.Orders.Remove(order);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrderDetailByOrderID(int orderID)
        {
            try
            {
                foreach (var od in FStoreDB.OrderDetails)
                {
                    if (od.OrderId == orderID)
                    {
                        FStoreDB.OrderDetails.Remove(od);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrderByMemberID(int memberID)
        {
            try
            {
                var orderIDList = FStoreDB.Orders.Select(o => new
                {
                    o.OrderId,
                    o.MemberId
                }).ToList();
                orderIDList.ForEach(o =>
                {
                    if (o.MemberId == memberID)
                    {
                        DeleteOrder(o.OrderId);
                        FStoreDB.SaveChanges();
                    }
                });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
