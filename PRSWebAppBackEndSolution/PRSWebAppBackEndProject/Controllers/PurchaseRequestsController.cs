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
    public class PurchaseRequestsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult GetForReview()
        {
            return new JsonNetResult { Data = db.PurchaseRequests.Where(pr => pr.Status.ToUpper().Equals("REVIEW")).ToList() };
        }

        public ActionResult List()
        {
            //return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequests.ToList() };
        }

        // /PurchaseRequests/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new Utility.JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequests purchaseRequests = db.PurchaseRequests.Find(id);
            if (purchaseRequests == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            //return Json(purchaseRequest, JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = purchaseRequests };
        }

        // /PurchaseRequests/Create [POST]
        public ActionResult Create([FromBody] PurchaseRequests purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequests.Add(purchaseRequest);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Purchase Request was created"));
        }

        // /PurchaseRequests/Change [POST]
        public ActionResult Change([FromBody] PurchaseRequests purchaseRequest)
        {
            PurchaseRequests purchaseRequests2 = db.PurchaseRequests.Find(purchaseRequest.Id);
            if (purchaseRequests2 == null)
            {
                return Json(new JsonMessage("Failure", "Record that needs to be changed has been deleted"), JsonRequestBehavior.AllowGet);
            }
            purchaseRequests2.Id = purchaseRequest.Id;
            purchaseRequests2.UserId = purchaseRequest.UserId;
            purchaseRequests2.Description = purchaseRequest.Description;
            purchaseRequests2.Justification = purchaseRequest.Justification;
            purchaseRequests2.DeliveryMode = purchaseRequest.DeliveryMode;
            purchaseRequests2.Status = purchaseRequest.Status;
            purchaseRequests2.Total = purchaseRequest.Total;
            purchaseRequests2.Active = purchaseRequest.Active;
            purchaseRequests2.ReasonForRejection = purchaseRequest.ReasonForRejection;
            purchaseRequests2.DateCreated = purchaseRequest.DateCreated;
            purchaseRequests2.DateUpdated = purchaseRequest.DateUpdated;
            purchaseRequests2.UpdatedByUser = purchaseRequest.UpdatedByUser;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Purchase Request was updated"));
        }

        // /PurchaseRequest/Remove [POST]
        public ActionResult Remove([FromBody] PurchaseRequests purchaseRequest)
        {
            PurchaseRequests purchaseRequests2 = db.PurchaseRequests.Find(purchaseRequest.Id);
            db.PurchaseRequests.Remove(purchaseRequests2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Purchase Request was removed"));
        }
    }
}