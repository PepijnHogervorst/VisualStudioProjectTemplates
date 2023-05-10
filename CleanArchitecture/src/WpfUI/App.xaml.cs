using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfUI.Services.Initialization;
using WpfUI.Services.Utility;
using WpfUI.Views;

namespace WpfUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    #region Private fields
    private readonly ServiceProvider _serviceProvider;
    #endregion


    #region Constructor
    public App()
    {
        ServiceCollection services = new();
        services.ConfigureServices();

        _serviceProvider = services.BuildServiceProvider();
    }
    #endregion


    #region Override methods
    protected override async void OnStartup(StartupEventArgs e)
    {
        var startup = _serviceProvider.GetRequiredService<Startup>();
        await startup.InitializeAsync();

        Window window = _serviceProvider.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }
    #endregion
}
