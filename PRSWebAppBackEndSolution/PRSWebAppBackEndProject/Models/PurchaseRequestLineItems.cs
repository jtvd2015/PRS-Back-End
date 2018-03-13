using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class PurchaseRequestLineItems
    {
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Active { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserId { get; set; }


        [JsonIgnore]
        public virtual PurchaseRequests PurchaseRequests { get; set; }
        public virtual Products Products { get; set; }

        public PurchaseRequestLineItems()
        {

        }

        public PurchaseRequestLineItems(int id, int purchaserequestid, int productid, int quantity)
        {
            this.Id = id;
            this.PurchaseRequestId = purchaserequestid;
            this.ProductId = productid;
            this.Quantity = quantity;
        }
    }
}