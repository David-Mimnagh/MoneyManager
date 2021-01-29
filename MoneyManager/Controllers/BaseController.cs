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
    public class BaseController : Controller
    {
        public List<DateTime> PublicHolidaysList { get; set; }
        public BaseController()
        {
            PublicHolidaysList = GetBankHolidays().Result.ToList();
        }
        private async Task<IEnumerable<DateTime>> GetBankHolidays()
        {
            List<BankHolidays> Holidays = new List<BankHolidays>();
            string apiEndPoint = "https://www.gov.uk/bank-holidays.json";
            BankHolidays apiHolidays = null;

            using (var wb = new WebClient())
            {
                wb.Encoding = Encoding.UTF8;
                string response = wb.DownloadString(apiEndPoint);

            }

            apiHolidays = JsonConvert.DeserializeObject<BankHolidays>(response);//System.IO.File.ReadAllText(@"C:\Users\David Mimnagh\Documents\test.json"));
            List<DateTime> HolidayDates = new List<DateTime>();

            HolidayDates = apiHolidays.EnglandAndWales.Events.Select(h => h.Date).ToList();
            HolidayDates.AddRange(apiHolidays.NorthernIreland.Events.Select(h => h.Date).ToList());
            HolidayDates.AddRange(apiHolidays.Scotland.Events.Select(h => h.Date).ToList());
            HolidayDates = HolidayDates.Select(date => date).Where(date => date.Year >= DateTime.Now.Year).ToList();
            return HolidayDates;
        }
    }
}