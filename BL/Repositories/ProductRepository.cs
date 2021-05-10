using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
   public class ProductRepository:BaseRepository<Product>
    {
        private DbContext _dbContext;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }
        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }
        public bool CheckProductExists(Product product)
        {
            return GetAny(l => l.ID == product.ID);
        }
        public Product GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
    }
}
