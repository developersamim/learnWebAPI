using Empower.Entities;
using Empower.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Empower
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));

            // the below code is to allow spaces in username
            _userManager.UserValidator = new UserValidator<ApplicationUser>(_userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
            };
        }

        public async Task<IdentityResult> RegisterUser(User user)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = user.username
            };

            var result = await _userManager.CreateAsync(applicationUser, user.password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(username, password);

            return user;
        }

        

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);

            return client;
        }


        // external authentication starts here
        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            ApplicationUser user = await _userManager.FindAsync(loginInfo);
            
            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }
        // external authentication ends here

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<Boolean> checkUserInRoleAsync(string userid, string role)
        {
            return await _userManager.IsInRoleAsync(userid, role);
        }

        public async Task<IdentityResult> addToRoleAsync(string userid, string role)
        {
            var result = await _userManager.AddToRoleAsync(userid, role);

            return result;
        }

        public MyUser getMyUser(string username){
            //return (List<string>)_userManager.GetRoles(userid);
            MyUser myUser = new MyUser();
            List<Role> roleList = new List<Role>();
            var user = _userManager.FindByName(username);
            myUser.id = user.Id;
            myUser.username = user.UserName;
            myUser.email = user.Email;
            myUser.emailConfirmed = user.EmailConfirmed;
            myUser.phoneNumber = user.PhoneNumber;

            var roles = _userManager.GetRoles(user.Id);
            if (roles.Count > 0)
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    Role role = new Role();
                    role.name = roles[i];
                    roleList.Add(role);
                }
            }
            myUser.roleList = roleList;
            return myUser;
        }
    }
}