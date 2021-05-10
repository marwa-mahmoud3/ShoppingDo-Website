using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        AccountRepository Account { get; }
        BrandsRepository Brands { get; }
        CartRepository Cart { get; }
        CartItemRepository CartItem { get; }
        CategoryRepository Category { get; }
        OrderRepository Order { get; }
        OrderItemRepository OrderItem { get; }
        ProductRepository Product { get; }
        RoleRepository Role { get; }
        PaymentRepository Payment { get; }
        TestimonialsRepository Review { get; }
        OffersRepository offers { get; }
    }
}
