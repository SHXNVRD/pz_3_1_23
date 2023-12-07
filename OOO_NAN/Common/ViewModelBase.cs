using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOO_NAN.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged, ICloseWindow
    {
        public Action Close { get; set; }
        public bool CanClose()
        {
            return true;
        }

        public void CloseWindow()
        {
            Close?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
