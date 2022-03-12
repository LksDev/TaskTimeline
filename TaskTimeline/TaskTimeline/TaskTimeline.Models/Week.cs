using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace TaskTimeline.Models {
    public class Week {

		private Guid id;
		public Guid Id {
			get { return this.id; }
		}

		private int kw;
		public int KW {
			get { return this.kw; }
		}

		private DateTime startDate;
		public DateTime StartDate => this.startDate;

		private DateTime endDate;
		public DateTime EndDate => this.endDate;

		private Weekday[] weekdays;

		public Week(DateTime argMondayDate, int argKW) {
			this.id = Guid.NewGuid();
			this.startDate = argMondayDate;
			this.endDate = argMondayDate.AddDays(6);
			this.kw = argKW;

			this.InitWeekdays();
		}

		private void InitWeekdays() {
			weekdays = new Weekday[7];
			DateTime cacheDate = new DateTime(this.startDate.Year, this.startDate.Month, this.startDate.Day);
			for (int i = 0; i < 7; i++) {
				DayName dayName = (DayName)i;
				weekdays[i] = new Weekday(dayName, cacheDate);
				cacheDate.AddDays(1);

			}

			if (cacheDate != EndDate) throw new Exception($"Error to calc date.");
		}

		public Weekday GetWeekday(DayName dayName) {
			foreach (var weekday in this.weekdays) {
				if (weekday.Name == dayName)
					return weekday;
			}

			throw new Exception($"Not found weekday with name {dayName}");
		}

		public Weekday GetWeekday(DateTime date) {
			foreach (var weekday in this.weekdays) {
				if (weekday.Date == date)
					return weekday;
			}

			throw new Exception($"Not found weekday with date {date}");
		}

	}
}
