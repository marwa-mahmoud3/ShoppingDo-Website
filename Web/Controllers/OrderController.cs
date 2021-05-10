using BL.AppServices;
using BL.AppSevices;
using BL.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        OrderAppService orderAppService = new OrderAppService();
        CartAppService cartAppService = new CartAppService();
        CartItemAppService productCartAppService = new CartItemAppService();
        ProductAppService productAppService = new ProductAppService();
        OrderItemAppService orderProductAppService = new OrderItemAppService();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(orderAppService.GetAllOrder());
        }

        [HttpPost]

        public ActionResult makeOrder(int[] quantities, double totalOrderPrice)
        {
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.UserID == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var prodIds = productCartAppService.GetAllCartItems().Where(pc => pc.CartID == cartID)
                                                                 .Select(pc => pc.productId).ToList();

            OrderViewModel orderViewModel = new OrderViewModel
            {
                OrderDate = DateTime.Now,

                TotalPrice = totalOrderPrice,
                UserID = userID
            };
            orderAppService.SaveNewOrder(orderViewModel);
            var lastOrder = orderAppService.GetAllOrder().Select(o => o.ID).LastOrDefault();
            for (int i = 0; i < prodIds.Count; i++)
            {

                var productViewModel = productAppService.GetPoduct(prodIds[i]);
                double totOrder = productViewModel.price * quantities[i];
                double AfterDiscount = totOrder ;
                OrderItemViewModel orderProductViewModel = new OrderItemViewModel
                {
                    OrderID = lastOrder,
                    ProductID = productViewModel.ID,
                    OrderItemQuantity = quantities[i],
                    productTotal = totOrder,
                    ProductNetPrice = AfterDiscount
                };
                orderProductAppService.SaveNewOrderProduct(orderProductViewModel);
                productAppService.DecreaseQuantity(productViewModel.ID, quantities[i]);


                var productCartID = productCartAppService.GetAllCartItems()
                                                       .Where(prc => prc.CartID == cartID && prc.productId == productViewModel.ID)
                                                       .Select(prc => prc.ID).FirstOrDefault();
                productCartAppService.DeleteCartItem(productCartID);

            }
            return RedirectToAction("index", "home");
        }
        public ActionResult Details(int id)
        {
            return View(orderProductAppService.GetAllOrderProduct().Where(op => op.OrderID == id).ToList());
        }

    }
}