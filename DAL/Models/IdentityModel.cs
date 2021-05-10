using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ApplicationUser : IdentityUser
    {
                      
        public string Address { get; set; }

        public DateTime DateJoined { get; set; }
        
        public string Gender { get; set; }

        public string Country { get; set; }
        [Required]
        public bool isDeleted { get; set; }
        public virtual List<Payment>payments { get; set; }
    }
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore() : base(new ApplicationDbContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {

        }
        public ApplicationRoleManager(DbContext connectionString) :
            base(new RoleStore<IdentityRole>(connectionString))
        {

        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Data Source=DESKTOP-60R5JD3;Initial Catalog=OnlineShopping;Integrated Security=True;")
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> PaymentTypes { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> Cartitems { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Testimonials> Testimonials { get; set; }

    }
}
