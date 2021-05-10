using BL.Bases;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ProductReviewRepository : BaseRepository<ProductReview>
    {
        private DbContext _dbContext;
        public ProductReviewRepository(DbContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }
        public List<ProductReview> GetAllProductReviews()
        {
            return GetAll().ToList();
        }
        public bool InsertReview(ProductReview productReview)
        {
            return Insert(productReview);
        }
        public void UpdateReview(ProductReview productReview)
        {
            Update(productReview);
        }
        public void DeleteReview(int id)
        {
            Delete(id);
        }
        public bool CheckReviewExists(ProductReview productReview)
        {
            return GetAny(l => l.ID == productReview.ID);
        }
        public ProductReview GetReviewById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }

    }
}
