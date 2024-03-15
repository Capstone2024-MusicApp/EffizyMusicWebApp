using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class LoginAuthentication
    {
        [Required(ErrorMessage = "User ID is required.")]
        public string UserID { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }




    }
}
