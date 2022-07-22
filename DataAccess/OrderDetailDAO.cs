using BusinessObject;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        FStoreContext FStoreDB;
        public OrderDetailDAO()
        {
            FStoreDB = new FStoreContext();
        }
        public static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<OrderDetail> GetOrderDetails(int orderID)
        {
            var orderDetails = new List<OrderDetail>();
            foreach (var od in FStoreDB.OrderDetails)
            {
                if (od.OrderId.Equals(orderID))
                {
                    orderDetails.Add(od);
                }
            }
            return orderDetails;
        }
    }
}