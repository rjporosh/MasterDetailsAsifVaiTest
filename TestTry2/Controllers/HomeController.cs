using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTry2.Models;

namespace TestTry2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult GetProductCategories()
        {
            List<Category> categories;
            using (DbEntities dc = new DbEntities())
            {
                categories = dc.Categories.OrderBy(a => a.CategortyName).ToList();
            }
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetProducts(int categoryID)
        {
            List<Product> products = new List<Product>();
            using (DbEntities dc = new DbEntities())
            {
                products = dc.Products.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
            }
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult Save(OrderMaster order)
        {
            bool status = false;
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(order.OrderDate.ToString(), "mm-dd-yyyy", null,
                System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate)
            {
                order.OrderDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(order);
            if (isValidModel)
            {
                using (DbEntities dc = new DbEntities())
                {
                    dc.OrderMasters.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}