using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.AppServices
{ 

    public class RoleAppService : AppServiceBase
    { 
        public IdentityResult Create(string rolename)
        { 
            return TheUnitOfWork.Role.Create(rolename);
        }
        public RoleViewModel GetRoleById(string id)
        { 
            return Mapper.Map<RoleViewModel>(TheUnitOfWork.Role.GetRoleByID(id));
        }
        public IdentityResult Update(RoleViewModel roleViewModel)
        { 
            var role = Mapper.Map<IdentityRole>(roleViewModel);
            return TheUnitOfWork.Role.UpdateRole(role);
        }
        public bool DeleteRole(string id)
        { 
            bool result = false;
            TheUnitOfWork.Role.DeleteRole(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public List<RoleViewModel> GetAllRoles()
        {
            return Mapper.Map<List<RoleViewModel>>(TheUnitOfWork.Role.getAllRoles());
        }
        public List<RegisterViewModel> getAllUsers(string id)
        { 
            List<ApplicationUser> users = new List<ApplicationUser>();
            var role = TheUnitOfWork.Role.getAllRoles().FirstOrDefault(r => r.Id == id);
            foreach (var userRole in role.Users)
            { 
                var user = TheUnitOfWork.Account.GetAccountById(userRole.UserId);
                if (user.isDeleted == false)
                    users.Add(user);
            }
            return Mapper.Map<List<RegisterViewModel>>(users);
        }
    }
}



