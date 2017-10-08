using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Empower.Models
{
    public class Users
    {
        private AuthRepository _repo;
        private AuthContext _ctx;
        private UserManager<ApplicationUser> _userManager;
        private List<MyUser> myUserList;
        private MyUser myUser;
        private Role role;
        private List<Role> roleList;
        

        public Users()
        {
            _ctx = new AuthContext();
            _repo = new AuthRepository();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
            myUserList = new List<MyUser>();

        }

        public List<MyUser> getUsers(){
            List<ApplicationUser> allUsers = _ctx.Users.ToList();

            foreach (var item in allUsers)
            {
                myUser = new MyUser();
                roleList = new List<Role>();
                
                myUser.id = item.Id;
                myUser.username = item.UserName;
                myUser.email = item.Email;
                myUser.emailConfirmed = item.EmailConfirmed;
                myUser.phoneNumber = item.PhoneNumber;
                myUser.twoFactorEnabled = item.TwoFactorEnabled;

                foreach (var subitem in item.Roles)
                {
                    role = new Role();
                    role.id = subitem.RoleId;
                    role.name = _ctx.Roles.Find(role.id).Name;
                    roleList.Add(role);
                }
                myUser.roleList = roleList;
                
                myUserList.Add(myUser);
            }

            return myUserList;
        }

        public async Task<Boolean> deleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var logins = user.Logins;
            var rolesForUser = await _userManager.GetRolesAsync(id);

            using (var transaction = _ctx.Database.BeginTransaction())
            {
                try
                {
                    foreach (var login in logins.ToList())
                    {
                        await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    await _userManager.DeleteAsync(user);
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                }                
            }
            return false;
        }
        
    }
}