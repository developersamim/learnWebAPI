using Empower.DTO;
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
        public IEnumerable<Category> getAll()
        {
            return _authContext.Category.ToList();

        }
        public int add(CategoryDTO dto)
        {
            Category category = new Category(dto.name, dto.parentId);
            _authContext.Category.Add(category);
            _authContext.SaveChanges();
            return category.id;
        }
        public Category get(int id)
        {
            Category category = new Category();
            category = _authContext.Category.Find(id);
            return category;
        }
        public void test()
        {
            var lookup = _authContext.Category.ToLookup(x => x.parentId);
        }

    }
}