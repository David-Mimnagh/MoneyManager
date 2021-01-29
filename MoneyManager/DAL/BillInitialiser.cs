using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class BillInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<BillContext>
    {
        protected override void Seed(BillContext context)
        {
            var bills = new List<Bill>
            {
                new Bill{
                    BillName = "Mortgage",
                    BillAmount = 40.00,
                    IsSavingsAccount = true,
                    IsMandatoryBill = true,
                    BillInformation = "35 Year Contract.",
                    BillDueDay = 1
                }
            };

            bills.ForEach(b => context.Bills.Add(b));
            context.SaveChanges();
        }
    }
}