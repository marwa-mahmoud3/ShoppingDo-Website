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
    public class CartController : Controller
    {
        CartItemAppService cartItemAppService = new CartItemAppService();
        ProductAppService productAppService = new ProductAppService();
        PaymentAppService paymentAppService = new PaymentAppService();
        CartAppService cartAppService = new CartAppService();

        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.UserID == userID)
                                                     .Select(c => c.ID).FirstOrDefault();
            var products = cartItemAppService.GetAllCartItems().Where(pc => pc.CartID == cartID).Select(prc => prc.productId);
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (var proID in products)
            {
                var product = productAppService.GetPoduct(proID);
                productViewModels.Add(product);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProductToCart(int id)
        {
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.UserID == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productCartViewModel = new CartItemViewModel { CartID = cartID, productId = id };
            var isExisting = cartItemAppService.GetAllCartItems()
                                                 .FirstOrDefault(c => c.CartID == productCartViewModel.CartID && c.productId == productCartViewModel.productId);

            if (isExisting == null)
                cartItemAppService.SaveNewCartItem(productCartViewModel);
            else
            {
                productCartViewModel.Quantity++;
            }
            return RedirectToAction("Index");

        }
     

    }
}