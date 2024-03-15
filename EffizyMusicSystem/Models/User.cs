using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        
       // [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
        
        //[ForeignKey("UserTypes")]
        public int UserTypeID { get; set; }

        public List<UserType> UserType { get; set; }

        public UserType UType { get; set; }

    }
}
