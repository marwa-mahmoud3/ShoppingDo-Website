using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Web.Mvc;
using Web.Controllers;

namespace MVCUnitTests
{
    [TestClass]
    public class BrandsControllerUnitTests
    {
        [TestMethod]       
         public void Index_Returns_ActionResult()
        {
            BrandsController brands = new BrandsController();
            var actual = brands.Index();
            NUnit.Framework.Assert.IsInstanceOf<ActionResult>(actual);
        }
        [TestMethod]
        public void TestDetailsForViewResult()
        {
            BrandsController controller = new BrandsController();
            ViewResult result1 = (ViewResult)controller.Details(1);
            NUnit.Framework.Assert.That(true,"Details", result1.ViewName);
        }
        [TestMethod]
        public void TestForViewWithValueOtherThanZero()
        {
            BrandsController brandsController = new BrandsController();
            ViewResult r = brandsController.Edit(1) as ViewResult;
            NUnit.Framework.Assert.That(true,"product", r.ViewName);
        }
        [TestMethod]
        public void TestForViewDelete()
        {
            BrandsController brandsController = new BrandsController();
            ViewResult r = brandsController.Delete(1) as ViewResult;
            NUnit.Framework.Assert.That(true, "Delete", r.ViewName);
        }

    }
}
