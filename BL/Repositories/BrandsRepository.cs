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
   public class BrandsRepository:BaseRepository<Brands>
    {
        private DbContext _dbContext;
        public BrandsRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Brands> GetAllBrands()
        {
            return GetAll().ToList();
        }
        public bool InsertBrands(Brands brands)
        {
            return Insert(brands);
        }
        public void UpdateBrands(Brands brands)
        {
            Update(brands);
        }
        public void DeleteBrands(int id)
        {
            Delete(id);
        }
        public bool CheckBrandsExists(Brands brands)
        {
            return GetAny(l => l.ID == brands.ID);
        }
        public Brands GetBrandsById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
    }
}
