using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Models
{
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public int PaymentMethod { get; set; }

        public double Amount { get; set; }
        public string PaymentStatus { get; set; }

        public string BillingAddress { get; set; }
    }
}
