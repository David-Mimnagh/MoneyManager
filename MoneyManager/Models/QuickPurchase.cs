using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyManager.Models
{
    public class QuickPurchase
    {
        public int ID { get; set; }

        public string QuickPurchaseName { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuickPurchaseDate { get; set; }

        public double QuickPurchaseAmount { get; set; }

        public string QuickPurchaseOrigin { get; set; }

        public string QuickPurchaseReason { get; set; }
    }
}