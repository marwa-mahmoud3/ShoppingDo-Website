using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Controllers;

namespace MVCUnitTests
{
    [TestClass]
    public class CategoryControllerUnitTests
    {
        [TestMethod]
        public void IndexCategory_Return_Actiosult()
        {
            CategoriesController categories = new CategoriesController();
            var actual = categories.Index();
            NUnit.Framework.Assert.IsInstanceOf<ActionResult>(actual);
        }
        [TestMethod]
        public void Category_TestDetailsForViewResult()
        {
            CategoriesController categories = new CategoriesController();
            ViewResult result1 = (ViewResult)categories.Details(2);
            NUnit.Framework.Assert.That(true, "Details", result1.ViewName);
        }
        [TestMethod]
        public void TestForViewWithValueOtherThanZero()
        {
            CategoriesController categories = new CategoriesController();
            ViewResult r = categories.Edit(1) as ViewResult;
            NUnit.Framework.Assert.That(true, "Edit", r.ViewName);
        }
        [TestMethod]
        public void TestForViewDelete()
        {
            CategoriesController categories = new CategoriesController();
            ViewResult r = categories.Delete(3) as ViewResult;
            NUnit.Framework.Assert.That(true, "Delete", r.ViewName);
        }
    }
}
