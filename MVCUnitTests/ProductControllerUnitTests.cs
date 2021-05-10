using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ProductControllerUnitTests
    {
        [TestMethod]
        public void IndexCategory_Return_Actiosult()
        {
            ProductsController products = new ProductsController();
            var actual = products.Index();
            NUnit.Framework.Assert.IsInstanceOf<ActionResult>(actual);
        }
        [TestMethod]
        public void Category_TestDetailsForViewResult()
        {
            ProductsController products = new ProductsController();
            ViewResult result1 = (ViewResult)products.Details(6);
            NUnit.Framework.Assert.That(true, "Details", result1.ViewName);
        }
        [TestMethod]
        public void TestForViewWithValueOtherThanZero()
        {
            ProductsController products = new ProductsController();
            ViewResult r = products.Edit(1) as ViewResult;
            NUnit.Framework.Assert.That(true, "Edit", r.ViewName);
        }
        [TestMethod]
        public void TestForViewDelete()
        {
            ProductsController products = new ProductsController();
            ViewResult r = products.Delete(2) as ViewResult;
            NUnit.Framework.Assert.That(true, "Delete", r.ViewName);
        }
    }
}
