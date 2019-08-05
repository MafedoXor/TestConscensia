using Microsoft.Xaml.Behaviors.Core;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Abstractions.Network;
using TestConscensia.Models.Domain;
using TestConscensia.Models.ViewModels;

namespace TestConscensia.Module.Main.ViewModels
{
    public class ReportViewerViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<ReportCodeViewModel> _sortedReportCodes = new ObservableCollection<ReportCodeViewModel>();
        private ObservableCollection<OfficeLocationViewModel> _officeLocations = new ObservableCollection<OfficeLocationViewModel>();

        private OfficeLocationViewModel _selectedLocation;

        private bool _isLoading;

        private readonly ObservableCollection<ReportCodeViewModel> _reportCodes = new ObservableCollection<ReportCodeViewModel>();
        private readonly INetworkService _networkService;
        private readonly IAppMapper _appMapper;

        public ReportViewerViewModel(INetworkService networkService, IAppMapper appMapper)
        {
            _networkService = networkService;
            _appMapper = appMapper;
        }

        public ObservableCollection<ReportCodeViewModel> ReportCodes
        {
            get => _sortedReportCodes;
            set
            {
                _sortedReportCodes = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OfficeLocationViewModel> OfficeLocations
        {
            get => _officeLocations;
            set
            {
                _officeLocations = value;
                RaisePropertyChanged();
            }
        }

        public OfficeLocationViewModel SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                RaisePropertyChanged();

                LoadReportCodes();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                RaisePropertyChanged();
            }
        }

        public ICommand GenerateCodeCommand => new ActionCommand(GenerateCode);
        public ICommand ViewLoadedCommand => new ActionCommand(LoadData);

        private async void LoadData()
        {
            IsLoading = true;

            var cancellation = new CancellationTokenSource();

            var locations = await _networkService.GetAllOfficeLocations(cancellation.Token);

            var mapped = _appMapper.Map<IEnumerable<OfficeLocationViewModel>>(locations);

            OfficeLocations.Clear();
            OfficeLocations.AddRange(mapped);

            IsLoading = false;
        }

        private async void GenerateCode()
        {
            IsLoading = true;

            var cancellation = new CancellationTokenSource();

            var code = await _networkService.CreateNewReportCode(_appMapper.Map<OfficeLocation>(SelectedLocation), cancellation.Token);

            if (code != null)
            {
                ReportCodes.Add(_appMapper.Map<ReportCodeViewModel>(code));
            }

            IsLoading = false;
        }

        private async void LoadReportCodes()
        {
            IsLoading = true;

            ReportCodes.Clear();

            var cancellation = new CancellationTokenSource();

            var codes = await _networkService.GetReportCodesByLocation(SelectedLocation.CountryCode, cancellation.Token);

            if (codes.Count() != 0)
            {
                ReportCodes.AddRange(_appMapper.Map<IEnumerable<ReportCodeViewModel>>(codes));
            }

            IsLoading = false;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}