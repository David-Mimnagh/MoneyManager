using MoneyManager.Models.APIs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoneyManager.Models
{
    public class Admin
    {
        public double SavingsAccountBalance { get; set; }
        public double RemainingBillsCost { get; set; }
        public double SavingsRemainingAfterBills { get; set; }
        public int CountOfRemainingBills { get; set; }
        /// <summary>
        /// Date between last two paydays and next two paydays
        /// </summary>
        public int QuickPurchasesMadeThisMonth { get; set; }
        public double QuickPurchasesMonthlyCost { get; set; }
        public List<BillQuickInfo> BillInfoObjects{ get; set; }
 
        public void GetBillInfoObjects(List<Bill> bills, List<DateTime> bankHolidays)
        {
            var billQuickInfos = bills.Select(b => new BillQuickInfo(b.BillName, b.BillAmount, b.BillDueDay, b.BillPaid, bankHolidays)).ToList();
            BillInfoObjects = billQuickInfos.OrderBy(bQO => bQO.BillDueDate).ToList();

        }
    }
}