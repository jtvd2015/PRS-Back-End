using PRSWebAppBackEndProject.Models;
using PRSWebAppBackEndProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PRSWebAppBackEndProject.Controllers
{
    public class VendorsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult List()
        {
            return Json(db.Vendors.ToList(), JsonRequestBehavior.AllowGet);
        }

        // /Vendors/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new Utility.JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Vendors vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }

        // /Vendors/Create [POST]
        public ActionResult Create([FromBody] Vendors vendor)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Vendors.Add(vendor);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was created"));
        }

        // /Vendors/Change [POST]
        public ActionResult Change([FromBody] Vendors vendor)
        {
            Vendors vendor2 = db.Vendors.Find(vendor.Id);
            if (vendor2 == null)
            {
                return Json(new JsonMessage("Failure", "Record that needs to be changed has been deleted"), JsonRequestBehavior.AllowGet);
            }
            vendor2.Id = vendor.Id;
            vendor2.Code = vendor.Code;
            vendor2.Name = vendor.Name;
            vendor2.Address = vendor.Address;
            vendor2.City = vendor.City;
            vendor2.State = vendor.State;
            vendor2.PostalCode = vendor.PostalCode;
            vendor2.Phone = vendor.Phone;
            vendor2.Email = vendor.Email;
            vendor2.IsPreApproved = vendor.IsPreApproved;
            vendor2.Active = vendor.Active;
            vendor2.DateCreated = vendor.DateCreated;
            vendor2.DateUpdated = vendor.DateUpdated;
            vendor2.UserId = vendor.UserId;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was updated"));
        }

        // /Vendors/Remove [POST]
        public ActionResult Remove([FromBody] Vendors vendor)
        {
            Vendors vendor2 = db.Vendors.Find(vendor.Id);
            db.Vendors.Remove(vendor2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was removed"));
        }
    }
}