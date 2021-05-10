using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using BL.ViewModel;
using DAL;
namespace BL.AppSevices
{
    public class CartAppService : AppServiceBase
    {
        public List<CartViewModel> GetAllCarts()
        {
            return Mapper.Map<List<CartViewModel>>(TheUnitOfWork.Cart.GetAllCarts());
        }
        public bool InsertCart(CartViewModel cartViewModel)
        {
            bool result = false;
            var cart = Mapper.Map<Cart>(cartViewModel);
            if (TheUnitOfWork.Cart.Insert(cart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateCart(CartViewModel cartViewModel)
        {
            var cart = Mapper.Map<Cart>(cartViewModel);
            TheUnitOfWork.Cart.Update(cart);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteCart(int id)
        {
            bool result = false;
            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckCartExists(CartViewModel cartViewModel)
        {
            Cart cart = Mapper.Map<Cart>(cartViewModel);
            return TheUnitOfWork.Cart.CheckCartExists(cart);
        }
        public CartViewModel GetProduct(int id)
        {
            return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetProductById(id));
        }
    }
}
