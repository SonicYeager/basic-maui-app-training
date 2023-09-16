using Microsoft.Extensions.Logging;

namespace MyMauiApp;

public partial class App : Application
{
    private readonly ILogger<App> _logger;

    public App(ILogger<App> logger)
    {
        _logger = logger;
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        //TODO provide startup code
        _logger.LogInformation("App Startup");
        base.OnStart();
    }

    protected override void OnResume()
    {
        //TODO provide resume code
        _logger.LogInformation("App Resume");
        base.OnResume();
    }

    protected override void OnSleep()
    {
        //TODO provide sleep code
        _logger.LogInformation("App Sleep");
        base.OnSleep();
    }
}