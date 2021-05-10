using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class OrderItemAppService : AppServiceBase
    {
        public List<OrderItemViewModel> GetAllOrderProduct()
        {

            return Mapper.Map<List<OrderItemViewModel>>(TheUnitOfWork.OrderItem.GetAllOrderItem());
        }
        public bool SaveNewOrderProduct(OrderItemViewModel orderitemViewModel)
        {

            bool result = false;
            var orderProduct = Mapper.Map<OrderItem>(orderitemViewModel);
            if (TheUnitOfWork.OrderItem.Insert(orderProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

    }
}
