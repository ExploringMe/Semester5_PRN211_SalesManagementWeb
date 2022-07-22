using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStore
{
    public class ProductsController : Controller
    {
        IProductRepository productRepository = null;
        public ProductsController() => productRepository = new ProductRepository();
        // GET: ProductsController
        public ActionResult Index()
        {
            var productList = productRepository.GetProducts();
            return View(productList);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id.Value);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.ProductCount = productRepository.GetProducts().Last().ProductId + 1;
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.InsertProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    productRepository.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
