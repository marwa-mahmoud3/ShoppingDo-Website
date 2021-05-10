using BL.Interfaces;
using BL.Repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork :IUnitOfWork
    {
        private DbContext EC_DbContext { get; set; }
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDbContext();
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }

        public OrderRepository orderRepository;
        public OrderRepository Order
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(EC_DbContext);
                return orderRepository;
            }
        }
        public BrandsRepository brandsRepository;
        public BrandsRepository Brands
        {
            get
            {
                if (brandsRepository == null)
                    brandsRepository = new BrandsRepository(EC_DbContext);
                return brandsRepository;
            }
        }
        public OffersRepository offersRepository;
        public OffersRepository offers
        {
            get
            {
                if (offersRepository == null)
                    offersRepository = new OffersRepository(EC_DbContext);
                return offersRepository;
            }
        }
        public OrderItemRepository orderItemRepository;
        public OrderItemRepository OrderItem
        {
            get
            {
                if (orderItemRepository == null)
                    orderItemRepository = new OrderItemRepository(EC_DbContext);
                return orderItemRepository;
            }
        }
        public ProductRepository productRepository;
        public ProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(EC_DbContext);
                return productRepository;
            }
        }
       
        public CategoryRepository categoryRepository;
        public CategoryRepository Category
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(EC_DbContext);
                return categoryRepository;
            }
        }

        public CartItemRepository CartItemRepository;
        public CartItemRepository CartItem
        {
            get
            {
                if (CartItemRepository == null)
                    CartItemRepository = new CartItemRepository(EC_DbContext);
                return CartItemRepository;
            }
        }

       
        public PaymentRepository paymentRepository;
        public PaymentRepository Payment
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(EC_DbContext);
                return paymentRepository;
            }
        }

        public CartRepository cartRepository;
        public CartRepository Cart
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new CartRepository(EC_DbContext);
                return cartRepository;
            }
        }

      
        public AccountRepository accountRepository;
        public AccountRepository Account
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(EC_DbContext);
                return accountRepository;
            }
        }

        public RoleRepository roleRepository;
        public RoleRepository Role
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(EC_DbContext);
                return roleRepository;
            }
        }

        public TestimonialsRepository testimonialsRepository;
        public TestimonialsRepository Review
        {
            get
            {
                if (testimonialsRepository == null)
                    testimonialsRepository = new TestimonialsRepository(EC_DbContext);
                return testimonialsRepository;
            }
        }
        

    }
}
