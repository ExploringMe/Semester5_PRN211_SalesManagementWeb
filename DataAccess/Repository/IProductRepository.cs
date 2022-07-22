using BusinessObject;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Search(Expression<Func<Product, bool>> ex);
            IEnumerable<Product> GetProducts();
            Product GetProductByID(int productID);
            void InsertProduct(Product product);
            void DeleteProduct(int productID);
            void UpdateProduct(Product product);
    }
}
