using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.AppService
{
    public class BrandsAppService : AppServiceBase
    {
        public List<BrandsViewModel> GetAllBrands()
        {
            return Mapper.Map<List<BrandsViewModel>>(TheUnitOfWork.Brands.GetAllBrands());
        }
        public BrandsViewModel GetBrand(int id)
        {
            return Mapper.Map<BrandsViewModel>(TheUnitOfWork.Brands.GetBrandsById(id));
        }
        public bool SaveNewBrand(BrandsViewModel brandViewModel)
        {
            bool result = false;
            var brand = Mapper.Map<Brands>(brandViewModel);
            if (TheUnitOfWork.Brands.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateBrand(BrandsViewModel brandsViewModel)
        {
            var brand = Mapper.Map<Brands>(brandsViewModel);
            TheUnitOfWork.Brands.Update(brand);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteBrand(int id)
        {
            bool result = false;
            TheUnitOfWork.Brands.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckBrandExists(BrandsViewModel brandViewModel)
        {
            Brands brand = Mapper.Map<Brands>(brandViewModel);
            return TheUnitOfWork.Brands.CheckBrandsExists(brand);
        }
    }
}
