using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManager.Models
{
    public class Administration
    {
        public int ID { get; set; }
        public double SavingsAmount { get; set; }
        public double DavidPayAmount { get; set; }
        public int DavidPayDay { get; set; }
        
        [NotMapped]
        public DateTime DavidNextPayDate { get; set; }
        public double SarahPayAmount { get; set; }
        public int SarahPayDay { get; set; }

        [NotMapped]
        public DateTime SarahNextPayDate { get; set; }

        [NotMapped]
        public double IncomeTotal { get { return DavidPayAmount + SarahPayAmount; }}

        private DateTime GetNextPossiblePayDate(int payDay, List<DateTime> publicHolidays)
        {
            var today = DateTime.Now;
            var dateToCheck = new DateTime(today.Year, today.Month, payDay);

            if (publicHolidays.Contains(dateToCheck))
            {
                //02/01/21
                dateToCheck = dateToCheck.AddDays(1);
            }
            //04/01/21
            dateToCheck = (dateToCheck.DayOfWeek == DayOfWeek.Saturday) ? dateToCheck.AddDays(2) : (dateToCheck.DayOfWeek == DayOfWeek.Sunday) ? dateToCheck.AddDays(1) : dateToCheck;
            if (dateToCheck < today)
            {
                dateToCheck = dateToCheck.AddMonths(1);
            }
            return dateToCheck;
        }
        public void CalculateNextPayDates(List<DateTime> publicHolidays)
        {
            DavidNextPayDate = GetNextPossiblePayDate(DavidPayDay, publicHolidays);
            SarahNextPayDate = GetNextPossiblePayDate(SarahPayDay, publicHolidays);
        }

    }
}