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
   public class CartRepository:BaseRepository<Cart>
    {
        private DbContext _dbContext;
        public CartRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Cart> GetAllCarts()
        {
            return GetAll().ToList();
        }
        public bool InsertCart(Cart cart)
        {
            return Insert(cart);
        }
        public void UpdateCart(Cart cart)
        {
            Update(cart);
        }
        public void DeleteCart(int id)
        {
            Delete(id);
        }
        public bool CheckCartExists(Cart cart)
        {
            return GetAny(l => l.ID == cart.ID);
        }
        public Cart GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
    }
}
