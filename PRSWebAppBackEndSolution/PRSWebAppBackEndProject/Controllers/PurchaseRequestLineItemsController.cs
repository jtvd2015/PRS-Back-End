﻿using PRSWebAppBackEndProject.Models;
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
    public class PurchaseRequestLineItemsController : Controller
    {
        private PrsDbContext db = new PrsDbContext();

        struct prliType {
			public PurchaseRequests PurchaseRequest;
			public IEnumerable<PurchaseRequestLineItems> PurchaseRequestLineItems;
		}

        private void UpdatePurchaseRequestTotal(int prodid)
        {
            db = new PrsDbContext();
            
            decimal total = 0;
            var PurchaseRequestLineItems = db.PurchaseRequestLineItems.Where(p => p.PurchaseRequestId == prodid);
            foreach (var PurchaseRequestLineItem in PurchaseRequestLineItems)
            {
                var subTotal = PurchaseRequestLineItem.Quantity * PurchaseRequestLineItem.Products.Price;
                total += subTotal;
            }
            var PurchaseRequest = db.PurchaseRequests.Find(prodid);
            PurchaseRequest.Total = total;
            db.SaveChanges();
        }

        public ActionResult List()
        {
            //return Json(db.PurchaseRequestLineItems.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
        }

        // /PurchaseRequestLineItems/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new Utility.JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequestLineItems PurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (PurchaseRequestLineItem == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            //return Json(PurchaseRequestLineItem, JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
        }

        // /PurchaseRequestLineItems/Create [POST]
        public ActionResult Create([FromBody] PurchaseRequestLineItems purchaseRequestLineItem)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            UpdatePurchaseRequestTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Json(new JsonMessage("Success", "Purchase Request Line Item was created"));
        }

        // /PurchaseRequestLineItems/Change [POST]
        public ActionResult Change([FromBody] PurchaseRequestLineItems purchaseRequestLineItem)
        {
            PurchaseRequestLineItems purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            if (purchaseRequestLineItem2 == null)
            {
                return Json(new JsonMessage("Failure", "Record that needs to be changed has been deleted"), JsonRequestBehavior.AllowGet);
            }
            purchaseRequestLineItem2.Id = purchaseRequestLineItem.Id;
            purchaseRequestLineItem2.PurchaseRequestId = purchaseRequestLineItem.PurchaseRequestId;
            purchaseRequestLineItem2.ProductId = purchaseRequestLineItem.ProductId;
            purchaseRequestLineItem2.Quantity = purchaseRequestLineItem.Quantity;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            UpdatePurchaseRequestTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Json(new JsonMessage("Success", "Purchase Request Line Item was updated"));
        }

        // /PurchaseRequestLineItem/Remove [POST]
        public ActionResult Remove([FromBody] PurchaseRequestLineItems purchaseRequestLineItem)
        {
            PurchaseRequestLineItems purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            UpdatePurchaseRequestTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Json(new JsonMessage("Success", "Purchase Request Line Item was removed"));
        }
    }
}