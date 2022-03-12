using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTimeline.ViewModels.Utils;

namespace TaskTimeline.ViewModels.Commands {
    public class ControlTimerCommand : CommandBase {

        private TaskViewModel taskViewModel;
        private bool run;
        public bool Run {
            get { return this.run; }
            private set { SetProperty(ref this.run, value); }
        }
        public override bool CanExecute(object parameter) {
            if(this.ViewModel is TaskViewModel viewModel) {
                this.taskViewModel = viewModel;
                return true;
            }
            return false;
        }

        public override void Execute(object parameter) {
            if (CanExecute(parameter)) {
                try {
                    if (this.Run) {
                        this.taskViewModel.StopTimer();
                        this.Run = false;

                    }else if (!this.Run) {
                        this.taskViewModel.StartTimer();
                        this.Run = true;
                    }
                } catch (Exception err) {
                    Trace.WriteLine(err);
                }
            }
        }
    }
}
