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
    public class OffersRepository : BaseRepository<Offers>
    {
        private DbContext _dbContext;
        public OffersRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Offers> GetAllOffers()
        {
            return GetAll().Include(op => op.Product).ToList();
        }

        public bool InsertOffer(Offers offers)
        {
            return Insert(offers);
        }
        public void UpdateOffer(Offers offers)
        {
            Update(offers);
        }
    }
}
