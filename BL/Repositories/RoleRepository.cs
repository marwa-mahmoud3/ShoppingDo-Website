using BL.Bases;
using BL.ViewModel;
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
    public class RoleRepository : BaseRepository<IdentityRole>
    {
        ApplicationRoleManager manager;

        public RoleRepository(DbContext db) : base(db)
        {
            manager = new ApplicationRoleManager(db);

        }
        public IdentityRole GetRoleByID(string id)
        {
            return GetFirstOrDefault(r => r.Id == id);
        }

        public IdentityResult Create(string role)
        {
            return manager.CreateAsync(new IdentityRole(role)).Result;

        }
        public IdentityResult UpdateRole(IdentityRole role)
        {
            var identityRole = manager.FindById(role.Id);
            identityRole.Name = role.Name;
            return manager.Update(identityRole);
        }
        public void DeleteRole(string id)
        {
            var identityRole = manager.FindById(id);

            manager.Delete(identityRole);
        }
        public List<IdentityRole> getAllRoles()
        {
            return GetAll().Include(r => r.Users).ToList();
        }
    }
}
