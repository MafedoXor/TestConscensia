using System;
using TestConscensia.Models.Base;

namespace TestConscensia.Models.ViewModels
{
    public class ReportCodeViewModel : BaseDataViewModel
    {
        private long _id;
        private DateTime? _creationDate;
        private OfficeLocationViewModel _officeLocation;

        public ReportCodeViewModel()
        {

        }

        public override string ToString()
        {
            var year = (CreationDate.HasValue ? CreationDate.Value.Year : new DateTime().Year).ToString().Substring(2, 2);

            return OfficeLocation.ToString() + year;
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

        public DateTime? CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        public OfficeLocationViewModel OfficeLocation
        {
            get => _officeLocation;
            set
            {
                _officeLocation = value;
                OnPropertyChanged();
            }
        }
    }
}
