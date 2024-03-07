using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        [Required (ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
   
        [Required(ErrorMessage = "Phone Number is required")]
        public int? Phone { get; set; }
        
        [ForeignKey("UserTypeID")]
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }

    }

}
