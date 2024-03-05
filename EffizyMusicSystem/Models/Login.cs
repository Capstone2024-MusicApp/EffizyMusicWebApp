using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Module
    {
        [Key]
        public string UserID { get; set; }
        public string Password { get; set; }
        public string UserTypeID { get; set; }
    }
}
