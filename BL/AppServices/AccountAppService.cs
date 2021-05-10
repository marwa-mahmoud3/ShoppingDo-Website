using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        //Login
        public List<RegisterViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterViewModel>>(TheUnitOfWork.Account.GetAllAccounts().Where(ac => ac.isDeleted == false));
        }
        public RegisterViewModel GetAccountById(string id)
        {
            return Mapper.Map<RegisterViewModel>(TheUnitOfWork.Account.GetAccountById(id));
        }
        public bool DeleteAccount(string id)
        {
            bool result = false;
            ApplicationUser user = TheUnitOfWork.Account.GetAccountById(id);
            user.isDeleted = true;
            TheUnitOfWork.Account.Update(user);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public ApplicationUser Find(string name, string passworg)
        {
            var user = TheUnitOfWork.Account.Find(name, passworg);

            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public IdentityResult Register(RegisterViewModel user)
        {
            ApplicationUser identityUser =
                Mapper.Map<RegisterViewModel, ApplicationUser>(user);
            return TheUnitOfWork.Account.Register(identityUser);
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
        public bool UpdatePassword(string userID, string newPassword)
        {
            ApplicationUser identityUser = TheUnitOfWork.Account.FindById(userID);
            identityUser.PasswordHash = newPassword;
            return TheUnitOfWork.Account.updatePassword(identityUser);
        }

        public string GetIDByName(string name)
        {
            return TheUnitOfWork.Account.FindAccountByName(name).Id;
        }

    }
}
