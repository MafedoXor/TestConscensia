using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestConscensia.Models.Base
{
    public class BaseDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}