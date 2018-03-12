using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Index(IsUnique = true)] [Required] [MaxLength(30, ErrorMessage = "Max Length of Username field is 30 characters.")]
        public string UserName { get; set; }
        [Index(IsUnique = true)] [Required] [MaxLength(30, ErrorMessage = "Max Length of Password field is 30 characters.")]
        public string Password { get; set; }
        [Required] [MaxLength(30, ErrorMessage = "Max Length of First Name field is 30 characters.")]
        public string FirstName { get; set; }
        [Required] [MaxLength(30, ErrorMessage = "Max Length of Last Name field is 30 characters.")]
        public string LastName { get; set; }
        [Required] [MaxLength(12, ErrorMessage = "Max Length of Phone field is 12 characters.  Please include '-'.")]
        public string Phone { get; set; }
        [Required] [MaxLength(75, ErrorMessage = "Max Length of Email field is 75 characters.")]
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
        public bool Active { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserId { get; set; }

        public Users()
        {

        }

        public Users(int id, string username, string password, string firstname, string lastname, string phone, string email, bool isreviewer, bool isadmin, bool active, DateTime dateupdated, int? UserId)
        {
            this.Id = id;
            this.UserName = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phone = phone;
            this.Email = email;
            this.IsReviewer = isreviewer;
            this.IsAdmin = isadmin;
            this.Active = active;
            this.DateUpdated = dateupdated;
            this.UserId = UserId;
        }

    }
}