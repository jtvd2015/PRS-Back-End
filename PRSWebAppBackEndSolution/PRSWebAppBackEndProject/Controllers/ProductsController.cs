using PRSWebAppBackEndProject.Models;
using PRSWebAppBackEndProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Utility;

namespace PRSWebAppBackEndProject.Controllers
{
    public class ProductsController : Controller
    {
        private PrsDbContext db = new PrsDbContext();

        public ActionResult List()
        {
            //return Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.Products.ToList() };
        }

        // /Products/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new Utility.JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            //return Json(product, JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.Products.ToList() };
        }

        // /Products/Create [POST]
        public ActionResult Create([FromBody] Products product)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Products.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was added"));
        }

        // /Products/Change [POST]
        public ActionResult Change([FromBody] Products product)
        {
            Products product2 = db.Products.Find(product.Id);
            if (product2 == null)
            {
                return Json(new JsonMessage("Failure", "Record that needs to be changed has been deleted"), JsonRequestBehavior.AllowGet);
            }
            product2.Id = product.Id;
            product2.VendorId = product.VendorId;
            product2.VendorPartNumber = product.VendorPartNumber;
            product2.Name = product.Name;
            product2.Price = product.Price;
            product2.Unit = product.Unit;
            product2.Photopath = product.Photopath;
            product2.Active = product.Active;
            product2.DateCreated = product.DateCreated;
            product2.DateUpdated = product.DateUpdated;
            product2.UserId = product.UserId;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was updated"));
        }

        // /Products/Remove [POST]
        public ActionResult Remove([FromBody] Products product)
        {
            Products product2 = db.Products.Find(product.Id);
            db.Products.Remove(product2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was removed"));
        }
    }
}