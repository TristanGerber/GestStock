/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestStock.ViewModels
{
    /// <summary>
    /// Base ViewModel. Contains multiple methods for all ViewModels. Created from the app template.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy = false;
        /// <summary>
        /// Management of the multitasking in the application
        /// </summary>
        public bool IsBusy
        {
            get => isBusy;
            set { SetProperty(ref isBusy, value); }
        }
        string title = string.Empty;
        /// <summary>
        /// Title of a page
        /// </summary>
        public string Title
        {
            get => title;
            set { SetProperty(ref title, value); }
        }
        /// <summary>
        /// Custom setter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
