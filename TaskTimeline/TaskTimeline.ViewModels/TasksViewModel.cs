using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTimeline.Models;
using TaskTimeline.ViewModels.Utils;

namespace TaskTimeline.ViewModels {
    public class TasksViewModel : ViewModelBase {

        private string name;
        public string Name {
            get { return this.name; }
            private set { SetProperty(ref this.name, value); }
        }

        public ObservableCollection<TaskViewModel> TaskItems { get; }

        public TasksViewModel() {
            this.TaskItems = new ObservableCollection<TaskViewModel>();
            FillTaskItems();
            var task = new MyTask($"Task 123333");
            this.TaskItems.Add(new TaskViewModel(task));

            this.Name = "Peng!";
        }

        public void Add(TaskViewModel taskItem) {
            this.TaskItems.Add(taskItem);
        }

        public bool Remove(TaskViewModel taskItem) {
            return this.TaskItems.Remove(taskItem);
        }


        private void FillTaskItems() {
            for (int i = 0; i < 102; i++) {
                var task = new MyTask($"Task {i}");
                this.TaskItems.Add(new TaskViewModel(task));
            }
            Console.WriteLine("FillTaskItems");
        }
    }
}
