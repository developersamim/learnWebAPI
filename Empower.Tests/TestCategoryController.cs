using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Empower.Models;
using Empower.Controllers;

namespace Empower.Tests
{
    [TestClass]
    public class TestCategoryController
    {
        [TestMethod]
        public void Get_AllCategory()
        {
            var controller = new CategoryController();
            var result = controller.Get() as List<Category>;
            Assert.IsNotNull(result);
        }
    }
}
