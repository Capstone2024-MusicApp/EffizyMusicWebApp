﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        public int UserID { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? PaymentMethod { get; set; }

        public double Amount { get; set; }
        public string PaymentStatus {  get; set; }

        public string BillingAddress { get; set; } = "Get Address";

        public string City { get; set; } = "Get City";

        public string Province { get; set; } = "Get Province";

        public string PostalCode { get; set; } = "Get PostalCode";

        public string Country { get; set; } = "Get Country";

        public string PayerID { get; set; } 


    }
}
