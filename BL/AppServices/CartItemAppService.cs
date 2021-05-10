using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModel;
using DAL;

namespace BL.AppServices
{
    public class CartItemAppService : AppServiceBase
    {
        public List<CartItemViewModel> GetAllCartItems()
        {
            return Mapper.Map<List<CartItemViewModel>>(TheUnitOfWork.CartItem.GetAllCartItem());
        }
        public bool SaveNewCartItem(CartItemViewModel cartItemViewModel)
        {
            bool result = false;
            var Cartitem = Mapper.Map<CartItem>(cartItemViewModel);
            if (TheUnitOfWork.CartItem.Insert(Cartitem))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteCartItem(int id)
        {
            bool result = false;
            TheUnitOfWork.CartItem.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
