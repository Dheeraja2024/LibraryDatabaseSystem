using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LibraryDatabaseSystem.Models
{
    public class Customer
    {
        [Key]
        public int MemberId { get; set; }
        [Required(ErrorMessage ="* Enter name")]
        public string Name { get; set; }
        public string? MembershipDate { get; set; }

        [Required(ErrorMessage = "* Enter Email")]
        [EmailAddress(ErrorMessage ="* Enter valid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "* Enter password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "* Enter Usertype")]
        public string? Usertype { get; set; } 
        public string? message { get; set; }


       
    }
}
