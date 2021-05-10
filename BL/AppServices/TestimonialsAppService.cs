using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class TestimonialsAppService : AppServiceBase
    {
        public List<TestimonialsViewModel> GetAllTestimonials()
        {
            return Mapper.Map<List<TestimonialsViewModel>>(TheUnitOfWork.Review.GetAllTestimonials());
        }
        public TestimonialsViewModel GetTestimonial(int id)
        {
            return Mapper.Map<TestimonialsViewModel>(TheUnitOfWork.Review.GetById(id));
        }

        public bool insertTestimonial(TestimonialsViewModel testimonialsViewModel)
        {
            bool result = false;
            var testimonials = Mapper.Map<Testimonials>(testimonialsViewModel);
            if (TheUnitOfWork.Review.Insert(testimonials))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateTestimonials(TestimonialsViewModel testimonialsViewModel)
        {
            var testimonials = Mapper.Map<Testimonials>(testimonialsViewModel);
            TheUnitOfWork.Review.Update(testimonials);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteTestimonials(int id)
        {
            bool result = false;
            TheUnitOfWork.Review.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
