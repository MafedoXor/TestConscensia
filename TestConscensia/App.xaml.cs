using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Abstractions.Network;
using TestConscensia.Module.Main;
using TestConscensia.Services.Mapper;
using TestConscensia.Services.Network;

namespace TestConscensia
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppMapper, AppMapper>();
            containerRegistry.RegisterSingleton<IConnectionHelper, ConnectionHelper>();
            containerRegistry.RegisterSingleton<INetworkService, NetworkService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
        }
    }
}