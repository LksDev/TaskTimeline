using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeline.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string title;

        public string Title {
            get { return title; }
            set { SetProperty(ref this.title, value, nameof(Title)); }
        }


        private ViewModelBase page;
        public ViewModelBase Page {
            get { return this.page; }
            private set { SetProperty(ref this.page, value, nameof(Page)); }
        }

        public MainViewModel() {
            this.Title = "Hallo!";
            this.Page = new TasksViewModel();
        }


    }
}
