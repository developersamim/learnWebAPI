using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Empower.Models
{
    public class RolesRepository: IDisposable
    {
        private AuthContext _authContext;
        private RoleManager<IdentityRole> _roleManager;

        public RolesRepository()
        {
            _authContext = new AuthContext();
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_authContext));
        }

        public Task<IdentityRole> findByIdAsync(string id)
        {
            return _roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> Create(string name)
        {

            var role = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public IEnumerable<IdentityRole> getListRole()
        {
            return _roleManager.Roles.ToList();
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _roleManager.Dispose();

        }
    }
}