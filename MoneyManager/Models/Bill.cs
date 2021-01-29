using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManager.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public double BillAmount { get; set; }
        public string BillName { get; set; }
        public string BillInformation { get; set; }
        public int BillDueDay { get; set; }
        public bool IsMandatoryBill { get; set; }
        public bool IsSavingsAccount { get; set; }
        public bool BillPaid { get; set; }
    }
}