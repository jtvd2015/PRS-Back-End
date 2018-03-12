using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class Vendors
    {
        public int Id { get; set; }
        [Index(IsUnique = true)] [Required] [MaxLength(10, ErrorMessage = "Max Length of Code field is 10 characters.")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required] [MaxLength(2, ErrorMessage = "Max Length of State field is 2 characters.")]
        public string State { get; set; }    
        [Required]
        public string PostalCode { get; set; }
        [Required] [MaxLength(12, ErrorMessage = "Max Length of Phone field is 12 characters.  Please include '-'.")]
        public string Phone { get; set; }
        [Required] [MaxLength(75, ErrorMessage = "Max Length of Email field is 75 characters.")]
        public string Email { get; set; }
        [Required]
        public bool IsPreApproved { get; set; }
        [Required]
        public bool Active { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserId { get; set; }

        public Vendors()
        {

        }

        public Vendors(int id, string code, string name, string address, string city, string state, string postalcode, string phone, string email, bool ispreapproved, bool active, DateTime datecreated, int userid)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.PostalCode = postalcode;
            this.Phone = phone;
            this.Email = email;
            this.IsPreApproved = ispreapproved;
            this.Active = active;
            this.DateCreated = datecreated;
            this.UserId = userid;
        }

    }
}