using BusinessObject;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public Product GetProductByID(int productID) => ProductDAO.Instance.GetProductByID(productID);
        public void InsertProduct(Product product) => ProductDAO.Instance.AddProduct(product);
        public void DeleteProduct(int productID) => ProductDAO.Instance.DeleteProduct(productID);
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
