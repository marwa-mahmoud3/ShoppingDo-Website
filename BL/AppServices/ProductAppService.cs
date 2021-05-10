using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using BL.ViewModel;
using DAL;

namespace BL.AppServices
{
    public class ProductAppService : AppServiceBase
    {
        public List<ProductViewModel> GetAllProduct()
        {
            var products = TheUnitOfWork.Product.GetAllProducts();
            return Mapper.Map<List<ProductViewModel>>(products);
        }
        public List<ProductViewModel> GetAllProductWhere(int categoryID)
        {
            var searchRes = TheUnitOfWork.Product.GetWhere(p => p.CategoryID == categoryID, "Reviews");
            return Mapper.Map<List<ProductViewModel>>(searchRes);
        }
        public List<ProductViewModel> GetAllProductWhere(string productToSearch)
        {
            var searchRes = TheUnitOfWork.Product.GetWhere(p => p.ProductName.Contains(productToSearch), "Reviews");

            return Mapper.Map<List<ProductViewModel>>(searchRes);
        }
        public ProductViewModel GetPoduct(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetProductById(id));
        }
        public bool SaveNewProduct(ProductViewModel productViewModel)
        {
            bool result = false;
            var product = Mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateProduct(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool DecreaseQuantity(int prodID, int decresedQuantity)
        {
            var product = TheUnitOfWork.Product.GetById(prodID);
            product.Quantity -= decresedQuantity;
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();
            return true;
        }
        public List<ProductViewModel> SearchFor(string productToSearch)
        {
            return GetAllProductWhere(productToSearch);
        }
        public bool DeleteProduct(int id)
        {
            bool result = false;
            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckProductExists(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return TheUnitOfWork.Product.CheckProductExists(product);
        }

    }
}
