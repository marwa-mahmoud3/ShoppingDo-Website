using BL.Bases;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Repositories
{
    public class AccountRepository : BaseRepository<ApplicationUser>
    {
        ApplicationUserManager manager;

        public AccountRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(db);
        }
        public ApplicationUser GetAccountById(string id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        public List<ApplicationUser> GetAllAccounts()
        {
            return GetAll().ToList();
        }
        public ApplicationUser FindById(string id)
        {
            ApplicationUser result = manager.FindById(id);
            return result;
        }
        public ApplicationUser Find(string username, string password)
        {
            ApplicationUser result = manager.Find(username, password);
            return result;
        }
        public IdentityResult Register(ApplicationUser user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;
        }
        public bool updatePassword(ApplicationUser user)
        {
            user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            IdentityResult result = manager.Update(user);
            return true;
        }

        public bool UpdateAccount(ApplicationUser user)
        {
            IdentityResult result = manager.Update(user);
            return true;
        }

        public ApplicationUser FindAccountByName(string userName)
        {
            return manager.FindByName(userName);
        }

    }
}
