using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;

namespace BL.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>
    {
        private DbContext _dbContext;
        public CartItemRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CartItem> GetAllCartItem()
        {
            return GetAll().Include(op => op.product).ToList();
        }

        public bool InsertCartItem(CartItem cartItem)
        {
            return Insert(cartItem);
        }
        public void UpdateCartItem(CartItem cartItem)
        {
            Update(cartItem);
        }
    }
}
