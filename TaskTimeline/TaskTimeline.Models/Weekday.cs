using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskTimeline.Models
{
    public class Weekday
    {
		private Guid id;
		public Guid Id => this.id;

		private DayName name;

		public DayName Name {
			get { return name; }
		}

		private DateTime date;

		public DateTime Date {
			get { return date; }
		}

		private List<MyTask> myTasks;

		public Weekday(DayName argName, DateTime argDate) {
			this.id = Guid.NewGuid();
			this.name = argName;
			this.date = argDate;
			this.myTasks = new List<MyTask>();
		}

		public void AddTask(MyTask argMyTask) {
			if(myTasks.Any(anyTask => anyTask.Id == argMyTask.Id)) {
				return;
			} else {
				this.myTasks.Add(argMyTask);
			}
		}

		public void RemoveTask(Guid id) {
			var tasks = (from t in this.myTasks
					   where t.Id == id
					   select t).ToList();
			if (tasks.Count != 1)
				throw new Exception("Task id not unique.");

			this.myTasks.Remove(tasks.First());
		}
		public List<MyTask> GetTasks() {
			return this.myTasks;
		}



	}

	public enum DayName {
		Monday =0,
		Tuesday =1,
		Wednesday = 2,
		Thursday = 3,
		Friday = 4,
		Saturday = 5,
		Sunday = 6
	}
}
