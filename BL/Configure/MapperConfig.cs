using AutoMapper;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configur
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                    cfg.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
                    cfg.CreateMap<Cart, CartViewModel>().ReverseMap();
                    cfg.CreateMap<CartItem, CartItemViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Payment, PaymentViewModel>().ReverseMap();
                    cfg.CreateMap<Testimonials, TestimonialsViewModel>().ReverseMap();
                    cfg.CreateMap<Offers, OffersViewModel>().ReverseMap();
                    cfg.CreateMap<Brands, BrandsViewModel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
                    cfg.CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
                    cfg.CreateMap<IdentityUserRole, UserRolesViewModel>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
