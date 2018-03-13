using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class PurchaseRequests
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required] [MaxLength(100, ErrorMessage = "Max Length of Description field is 100 characters.")]
        public string Description { get; set; }
        [Required]
        public string Justification { get; set; }
        [Required] [MaxLength(25, ErrorMessage = "Max Length of Delivery Mode field is 25 characters.")]
        public string DeliveryMode { get; set; }
        [Required] [MaxLength(15, ErrorMessage = "Max Length of Status field is 25 characters.")]        
        public string Status { get; set ; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public bool Active { get; set; }
        [MaxLength(100, ErrorMessage = "Max Length of Reason for Rejection field is 100 characters.")]
        public string ReasonForRejection { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedByUser { get; set; }

        public virtual Users users { get; set; }
        public virtual PurchaseRequests purchaserequests { get; set; }

        public PurchaseRequests()
        {
            
        }

        public PurchaseRequests(int id, int userid, string description, string justification, string deliverymode, string status, decimal total, bool active, string reasonforrejection, DateTime datecreated, DateTime dateupdated, int updatedbyuser)
        {
            this.Id = id;
            this.UserId = userid;
            this.Description = description;
            this.Justification = justification;
            this.DeliveryMode = deliverymode;
            this.Status = status;
            this.Total = total;
            this.Active = active;
            this.ReasonForRejection = reasonforrejection;
            this.DateCreated = datecreated;
            this.DateUpdated = dateupdated;
            this.UpdatedByUser = updatedbyuser;
        }
    }
}