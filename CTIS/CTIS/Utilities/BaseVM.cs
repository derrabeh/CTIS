using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CTIS.Utilities
{
    public class BaseVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var change = PropertyChanged;
            if (change != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //to deselect an item in listview after returning from update page
        public bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
