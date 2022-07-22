using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class OrdersController : Controller
    {
        IOrderRepository orderRepository = null;
        IOrderDetailRepository orderDetailRepository = null;
        public OrdersController()
        {
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            var orderList = orderRepository.GetOrders();
            return View(orderList);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderDetail = orderDetailRepository.GetOrderDetails(id.Value);
            return View(orderDetail);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            ViewBag.OrderCount = orderRepository.GetOrders().Last().OrderId + 1;
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (orderRepository.CheckExistMember(order.MemberId))
                {
                    orderRepository.InsertOrder(order);
                }
                else
                {
                    throw new Exception("The memberID does not exist, check member list for correct input and try again.");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return NotFound();
                }
                orderRepository.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                orderRepository.DeleteOrder(id);
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
