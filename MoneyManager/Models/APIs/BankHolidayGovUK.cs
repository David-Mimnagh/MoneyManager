using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManager.Models.APIs
{
	#region "Government UK Bank Holiday API Classes"
	public class BankHolidays
	{
		[JsonProperty("england-and-wales")]
		public BankHolidayDivision EnglandAndWales { get; set; }

		[JsonProperty("scotland")]
		public BankHolidayDivision Scotland { get; set; }

		[JsonProperty("northern-ireland")]
		public BankHolidayDivision NorthernIreland { get; set; }
	}

	public class BankHolidayDivision
	{
		[JsonProperty("division")]
		public string Division { get; set; }

		[JsonProperty("events")]
		public List<Event> Events { get; set; }
	}

	public class Event
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }

		[JsonProperty("bunting")]
		public bool Bunting { get; set; }
	}
	#endregion
}