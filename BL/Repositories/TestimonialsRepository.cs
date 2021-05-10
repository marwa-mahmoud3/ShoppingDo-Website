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
    public class TestimonialsRepository : BaseRepository<Testimonials>
    {
        private DbContext EC_DbContext;
        public TestimonialsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        public List<Testimonials> GetAllTestimonials()
        {
            return GetAll().ToList();
        }

        public bool InsertTestimonials(Testimonials testimonials)
        {
            return Insert(testimonials);
        }
        public void UpdateTestimonials(Testimonials testimonials)
        {
            Update(testimonials);
        }
        public void DeleteTestimonials(int id)
        {
            Delete(id);
        }
        public Testimonials GetTestimonialsByID(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }

    }
}
