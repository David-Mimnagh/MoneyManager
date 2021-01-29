using MoneyManager.DAL;
using MoneyManager.Models;
using MoneyManager.Models.APIs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyManager.Controllers
{
    public class HomeController : BaseController
    {
        private BillContext db = new BillContext();
        private AdministrationContext dbAdmin = new AdministrationContext();
        private QuickPurchaseContext dbQuickPurchases = new QuickPurchaseContext();
        public Tuple<int, double> GetQuickPurchases(int DavidPayDay, DateTime SarahNextPayDay)
        {
            var quickPurchases = dbQuickPurchases.QuickPurchases.ToList();
            var qpCount = 0;
            var qpAmount = 0.0;
            var today = DateTime.Now;
            var lastDavidPay = new DateTime(today.Year, today.Month, DavidPayDay);
            if(lastDavidPay > DateTime.Now)
            {
                lastDavidPay = lastDavidPay.AddMonths(-1);
            }
            foreach (var qP in quickPurchases)
            {
                if(qP.QuickPurchaseDate.Ticks > lastDavidPay.Ticks && qP.QuickPurchaseDate.Ticks < SarahNextPayDay.Ticks)
                {
                    qpCount++;
                    qpAmount += qP.QuickPurchaseAmount;
                }
            }

            return new Tuple<int, double>(qpCount, qpAmount);
        }

        public ActionResult Index()
        {
            var bills = db.Bills.ToList();
            var AdminObj = dbAdmin.Administration.ToList().Last();
            var publicHolidays = PublicHolidaysList;
            AdminObj.CalculateNextPayDates(publicHolidays);
            var amountLeft = bills.Sum(b => b.BillAmount);
            var purchaseCountAndAmount = GetQuickPurchases(AdminObj.DavidPayDay, AdminObj.SarahNextPayDate);
            var adminObject = new Admin
            {
                SavingsAccountBalance = AdminObj.SavingsAmount,
                QuickPurchasesMadeThisMonth = purchaseCountAndAmount.Item1,
                QuickPurchasesMonthlyCost = purchaseCountAndAmount.Item2
                
            };
            adminObject.GetBillInfoObjects(bills, publicHolidays);
            adminObject.CountOfRemainingBills = adminObject.BillInfoObjects.Select(bill => bill).Where(bill => bill.BillDueDate.Month == DateTime.Now.Month).Count();
            adminObject.RemainingBillsCost = adminObject.BillInfoObjects.Select(bill => bill).Where(bill => bill.BillDueDate.Month == DateTime.Now.Month).Sum(bill => bill.BillAmount);
            adminObject.SavingsRemainingAfterBills = Math.Floor((adminObject.SavingsAccountBalance - adminObject.RemainingBillsCost) - adminObject.QuickPurchasesMonthlyCost);
            return View(adminObject);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}