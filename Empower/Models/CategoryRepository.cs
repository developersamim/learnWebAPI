using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empower.Models
{
    public class CategoryRepository
    {
        private AuthContext _authContext;
        private List<Category> categoryList;

        public CategoryRepository()
        {
            _authContext = new AuthContext();
            categoryList = new List<Category>();
            _authContext.Configuration.ProxyCreationEnabled = false;
        }
        public List<Category> getAll()
        {
            categoryList = _authContext.Category.ToList();
            return categoryList;
        }
    }
}