﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class AmountWithBreakdown
    {
        public string CurrencyCode { get; set; }
        public string Value { get; set; }
      
    }

    public class PurchaseUnitRequest
    {
        public AmountWithBreakdown Amount { get; set; }
    }
}
