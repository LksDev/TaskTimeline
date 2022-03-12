using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TaskTimeline.Models;
using TaskTimeline.ViewModels.Commands;

namespace TaskTimeline.ViewModels.Utils {
    public class TaskViewModel :ViewModelBase{

        private Guid id;
        public Guid Id => this.id;

        private string taskname; 

        public string Taskname {
            get { return taskname; }
            set { SetProperty(ref this.taskname, value, nameof(Taskname)); }
        }

        private DateTime time;
        public DateTime Time {
            get { return time; }
            private set { SetProperty(ref this.time, value, nameof(Time)); }
        }

        private MyTask myTask;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public CommandBase ControlTimerCommand { get; }
        public TaskViewModel(MyTask argMyTask) {
            this.ControlTimerCommand = new ControlTimerCommand() { ViewModel = this };

            this.myTask = argMyTask;

            this.id = myTask.Id;
            this.Taskname = myTask.Name;
            this.myTask.Timer.Elapsed += OnTimeEvent;

        }

        public void StartTimer() {
            myTask.Start();   
        }

        public void StopTimer() {
            myTask.Stop();
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e) {

            //this.Time = e.SignalTime;
        }

    }
}
