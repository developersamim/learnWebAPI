using Empower.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public bool update(int id, Category category)
        {            
            _authContext.Entry(category).State = EntityState.Modified;

            try
            {
                _authContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return true;
        }
        public bool delete(int id)
        {
            Category category = new Category();
            category = _authContext.Category.Where(x => x.id == id).Single();
            _authContext.Category.Remove(category);
            _authContext.SaveChanges();
            return true;
        }
        public void test()
        {
            var lookup = _authContext.Category.ToLookup(x => x.parentId);
        }
        public bool keyExists(int id)
        {
            return _authContext.Category.Count(e => e.id == id) > 0;
        }  
    }
}