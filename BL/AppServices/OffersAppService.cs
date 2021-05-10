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
    public class OffersAppService : AppServiceBase
    {

        public List<OffersViewModel> GetAllOffers()
        {
            return Mapper.Map<List<OffersViewModel>>(TheUnitOfWork.offers.GetAllOffers());
        }
        public OffersViewModel GetOffer(int id)
        {
            return Mapper.Map<OffersViewModel>(TheUnitOfWork.offers.GetById(id));
        }

        public bool InserOffer(OffersViewModel offersViewModel)
        {
            bool result = false;
            var offer = Mapper.Map<Offers>(offersViewModel);
            if (TheUnitOfWork.offers.Insert(offer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateOffers(OffersViewModel offersViewModel)
        {
            var offer = Mapper.Map<Offers>(offersViewModel);
            TheUnitOfWork.offers.Update(offer);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteOrder(int id)
        {
            bool result = false;

            TheUnitOfWork.Order.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(OrderViewModel orderViewModel)
        {
            Order order = Mapper.Map<Order>(orderViewModel);
            return TheUnitOfWork.Order.CheckOrderExists(order);
        }
    }
}
