using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using TestConscensia.Common.Navigation.NavigationNames;
using TestConscensia.Module.Main.Views;

namespace TestConscensia.Module.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>().RequestNavigate(RegionNames.MainContentRegion, ViewNames.ReportViewerView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReportViewerView>(ViewNames.ReportViewerView);
        }
    }
}