using System.Collections.ObjectModel;
using TestConscensia.Models.Base;

namespace TestConscensia.Models.ViewModels
{
    public class OfficeLocationViewModel : BaseDataViewModel
    {
        private long _id;
        private string _countryCode;
        private int _officeNumber;

        private ObservableCollection<ReportCodeViewModel> _reportCodes = new ObservableCollection<ReportCodeViewModel>();

        public OfficeLocationViewModel()
        {

        }

        public override string ToString()
        {
            return CountryCode + OfficeNumber;
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

        public string CountryCode
        {
            get => _countryCode;
            set
            {
                _countryCode = value;
                OnPropertyChanged();
            }
        }

        public int OfficeNumber
        {
            get => _officeNumber;
            set
            {
                _officeNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReportCodeViewModel> ReportCodes
        {
            get => _reportCodes;
            set
            {
                _reportCodes = value;
                OnPropertyChanged();
            }
        }
    }
}
