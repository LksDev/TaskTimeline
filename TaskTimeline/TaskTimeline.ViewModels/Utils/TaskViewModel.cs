using System;
using System.Diagnostics;
using System.Threading;
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

        private string currentTime;

        public string CurrentTime {
            get { return this.currentTime; }
            set { SetProperty(ref this.currentTime, value); }
        }

        public Timer timer;

        private MyTask myTask;
        public CommandBase ControlTimerCommand { get; }
        public TaskViewModel(MyTask argMyTask) {
            this.ControlTimerCommand = new ControlTimerCommand() { ViewModel = this };

            this.myTask = argMyTask;

            this.id = myTask.Id;
            this.Taskname = myTask.Name;

            timer = new Timer(Callback, new AutoResetEvent(false), 100,250);
            
        }

        public void StartTimer() {
            myTask.Start();   
        }

        public void StopTimer() {
            myTask.Stop();
        }
        int i = 0;
        private void Callback(object stateInfo) {
            CurrentTime = i.ToString();
            i++;
        }
    }
}
