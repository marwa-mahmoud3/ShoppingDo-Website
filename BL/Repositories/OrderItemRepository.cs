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
    public class OrderItemRepository : BaseRepository<OrderItem>
    {
        private DbContext _dbContext;
        public OrderItemRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<OrderItem> GetAllOrderItem()
        {
            return GetAll().Include(op => op.product).ToList();
        }

        public bool InsertOrderItem(OrderItem orderitem)
        {
            return Insert(orderitem);
        }
        public void UpdateOrderItem(OrderItem orderitem)
        {
            Update(orderitem);
        }
    }
}
