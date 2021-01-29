using MoneyManager.Models.APIs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoneyManager.Models
{
    public class BillQuickInfo
    {
        public string BillName { get; set; }
        public double BillAmount { get; set; }
        public int BillDueDay { get; set; }
        public bool BillPaid { get; set; }

        public DateTime BillDueDate { get; set; }
        private List<DateTime> publicHolidays { get; set; }
        public string BillInfoString { get; set; }
        public BillQuickInfo(string billName, double billAmount, int billDueDay, bool billPaid, List<DateTime> holidayDates)
        {
            publicHolidays = holidayDates;
            BillName = billName;
            BillAmount = billAmount;
            BillDueDay = billDueDay;
            BillPaid = billPaid;
            BillDueDate = CalculateNextBillDate();
            BillInfoString = $"{BillName}: £{BillAmount} - {BillDueDate.ToShortDateString()}";
        }
        private DateTime CalculateNextBillDate()
        {
            //TEST FOR 31/12/20 with BANK HOLIDAY

            //02/01/21
            var today = DateTime.Now;
            BillDueDay = (BillDueDay == 0) ? 1 : BillDueDay;
            //28/12/20 - BANK HOLIDAY SO BILL SHOULD BE 04/01/21
            var billDate = new DateTime(today.Year, today.Month, BillDueDay);
            if (BillPaid)
            {
                billDate = billDate.AddMonths(1);
            }

            if (publicHolidays.Contains(billDate))
            {
                //02/01/21
                billDate = billDate.AddDays(1);
            }
            //04/01/21
            billDate = (billDate.DayOfWeek == DayOfWeek.Saturday) ? billDate.AddDays(2) : (billDate.DayOfWeek == DayOfWeek.Sunday) ? billDate.AddDays(1) : billDate;
            if(billDate < today)
            {
                billDate = billDate.AddMonths(1);
            }
            return billDate;
        }
    }
}