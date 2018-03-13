using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class Products
    {
        public int Id { get; set; }        
        public int VendorId { get; set; }
        [Required] [MaxLength(50, ErrorMessage = "Max Length of Vendor Part Number field is 50 characters.")]
        public string VendorPartNumber { get; set; }
        [Required] [MaxLength(150, ErrorMessage = "Max Length of Name field is 150 characters.")]
        public string Name  { get; set; }
        [Required] [DecimalPrecision(10, 2)] [MinLength(0)]
        public decimal Price { get; set; }
        [Required]
        public string Unit { get; set; }
        public string Photopath { get; set; }
        [Required]
        public bool Active { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserId { get; set; }

        public virtual Vendors Vendors { get; set; }

        public Products()
        {

        }

        public Products (int id, int vendorid, string vendorpartnumber, string name, decimal price, string unit, string photopath, bool active, DateTime datecreated, DateTime dateupdated, int userid)
        {
            this.Id = id;
            this.VendorId = vendorid;
            this.VendorPartNumber = vendorpartnumber;
            this.Name = name;
            this.Price = price;
            this.Unit = unit;
            this.Photopath = photopath;
            this.Active = active;
            this.DateCreated = datecreated;
            this.DateUpdated = dateupdated;
            this.UserId = userid;
        }

        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class DecimalPrecisionAttribute : Attribute
        {
            public DecimalPrecisionAttribute(byte precision, byte scale)
            {
                Precision = precision;
                Scale = scale;

            }

            public byte Precision { get; set; }
            public byte Scale { get; set; }

        }
    }
}