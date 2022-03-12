using System;
using System.Timers;

namespace TaskTimeline.Models {
    public class MyTask {

		private Guid id;
		public Guid Id => this.id;


		private string name;

		public string Name {
			get { return name; }
		}

		private Timer timer;
		public Timer Timer => this.timer;
		public MyTask(string argName) {
			this.id = Guid.NewGuid();
			this.name = argName;
			this.timer = new Timer();
			this.timer.Stop();
			
		}

        public void Start() {
            this.timer.Start();
        }
        public void Stop() {
            this.timer.Stop();
        }
	}
}
