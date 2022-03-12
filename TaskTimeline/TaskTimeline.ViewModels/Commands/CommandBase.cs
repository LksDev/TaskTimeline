using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskTimeline.ViewModels.Commands {
    public abstract class CommandBase : ViewModelBase, ICommand {
        public event EventHandler CanExecuteChanged;

        private ViewModelBase viewModel;
        /// <summary>
        /// Gets or sets the <see cref="ViewModel"/> instance which uses this command.
        /// </summary>
        internal ViewModelBase ViewModel {
            get => this.viewModel;
            set {
                if (!(this.viewModel is null))
                    this.viewModel.PropertyChanged -= this.OnCanExecuteChanged;

                this.SetProperty(ref this.viewModel, value);
                this.OnCanExecuteChanged();

                if (!(this.viewModel is null))
                    this.viewModel.PropertyChanged += this.OnCanExecuteChanged;
            }
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        internal void OnCanExecuteChanged() {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        private void OnCanExecuteChanged(Object sender, PropertyChangedEventArgs e) {
            this.OnCanExecuteChanged();
        }

        /// <inheritdoc/>
        public abstract Boolean CanExecute(Object parameter);

        /// <inheritdoc/>
        public abstract void Execute(Object parameter);
    }
}
