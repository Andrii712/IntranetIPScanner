using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntranetIPScanner.Models
{
    public class BindableBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        /// <summary>
        /// Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparamref name="T">Type of the property.</typeparamref>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. 
        ///     This value is optional and can be provided automatically when 
        ///     invoked from compilers that support CallerMemberName.
        /// </param>
        /// <returns>
        /// True if the value was changed, false if the existing value matched the 
        /// desired value.
        /// </returns>
        protected bool SetProperty<T, V>(ref T src, V value, [CallerMemberName] String propertyName = null)
        {
            PropertyInfo storage = src.GetType().GetProperty(propertyName);
            if (object.Equals(storage.GetValue(src, null), value)) return false;

            storage.SetValue(src, value);
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        ///
        ///Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
