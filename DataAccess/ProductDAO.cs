using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        FStoreContext FStoreDB;
        public ProductDAO()
        {
            FStoreDB = new FStoreContext();
        }
        public static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public Product GetProductByID(int ProductID)
        {
            Product product = null;
            foreach (Product p in FStoreDB.Products)
            {
                if(p.ProductId == ProductID)
                    product = p;
            }
            return product;
        }
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            foreach (var p in FStoreDB.Products)
            {
                products.Add(p);
            }
            return products;
        }
        public void AddProduct(Product product)
        {
            try
            {
                product.ProductId = 0;
                FStoreDB.Products.Add(product);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                var p = GetProductByID(product.ProductId);
                p.CategoryId = product.CategoryId;
                p.ProductName = product.ProductName;
                p.Weight = product.Weight;
                p.UnitPrice = product.UnitPrice;
                p.UnitInStock = product.UnitInStock;
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteProduct(int productID)
        {
            try
            {
                DeleteOrderDetailByProductID(productID);
                Product product = GetProductByID(productID);
                FStoreDB.Products.Remove(product);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrderDetailByProductID(int productID)
        {
            try
            {
                foreach (var od in FStoreDB.OrderDetails)
                {
                    if (od.ProductId == productID)
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
    }
}
