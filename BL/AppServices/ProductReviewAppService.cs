using BL.Bases;
using BL.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ProductReviewAppService :AppServiceBase
    {
        public ProductReviewViewModel GetReviewById(int id)
        {
            return Mapper.Map<ProductReviewViewModel>(TheUnitOfWork.Comment.GetReviewById(id));
        }
        public ProductReviewViewModel GetproductReviewsId(int id)
        {
            ProductReviewViewModel review = GetReviewById(id);
            ProductReviewViewModel productReview = new ProductReviewViewModel()
            { };
            return productReview;
        }
        public List<ProductReviewViewModel> GetAllReviews()
        {
            return Mapper.Map<List<ProductReviewViewModel>>(TheUnitOfWork.Comment.GetAllProductReviews());
        }
        public ProductReviewViewModel GetReview(int id)
        {
            return Mapper.Map<ProductReviewViewModel>(TheUnitOfWork.Comment.GetReviewById(id));
        }
        public bool SaveNewReview(ProductReviewViewModel productReview)
        {
            bool result = false;
            var Review = Mapper.Map<ProductReview>(productReview);
            if (TheUnitOfWork.Comment.Insert(Review))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateReview(ProductReviewViewModel productReview)
        { 
            var reviews = Mapper.Map<ProductReview>(productReview);
            TheUnitOfWork.Comment.Update(reviews);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteReview(int id)
        { 
            bool result = false;
            TheUnitOfWork.Comment.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckReviewExists(ProductReview comment)
        {
            ProductReview reviews = Mapper.Map<ProductReview>(comment);
            return TheUnitOfWork.Comment.CheckReviewExists(reviews);
        }

    }
}
