using System;
using TestConscensia.Models.Base;

namespace TestConscensia.Models.ViewModels
{
    public class ReportCodeViewModel : BaseDataViewModel
    {
        private string _code;
        private long _id;
        private DateTime? _creationDate;
        private OfficeLocationViewModel _location;

        public ReportCodeViewModel()
        {

        }

        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        public OfficeLocationViewModel Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
    }
}