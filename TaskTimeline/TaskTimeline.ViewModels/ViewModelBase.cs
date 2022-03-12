using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeline.ViewModels {
    public class ViewModelBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the given property.
        /// </summary>
        /// <param name="propertyName">Property name to use when raising the <see cref="PropertyChanged"/> event.</param>
        internal void OnPropertyChanged(String propertyName) {
            if (propertyName is null)
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the value of a property's backing field and raises the <see cref="PropertyChanged"/> event for that property.
        /// </summary>
        /// <typeparam name="T">Backing field type</typeparam>
        /// <param name="field">Backing field reference</param>
        /// <param name="value">Backing field value</param>
        /// <param name="propertyName">Property name is set automatically via <see cref="CallerMemberNameAttribute"/>.</param>
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] String propertyName = null) {
            field = value;
            this.OnPropertyChanged(propertyName);
        }
    }
}
