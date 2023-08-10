namespace AppliedActivity5;

public partial class App : Application
{

    public static DatabaseContext DatabaseContext { get; private set; }

    public App()
    {
        InitializeComponent();
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db");
        DatabaseContext = new DatabaseContext(dbPath);
        InitializeSampleData();
        MainPage = new AppShell();
    }

    protected async void InitializeSampleData()
    {
        await DatabaseContext.InitializeSampleData();
        var titleBarBackgroundColor = (Color)Resources["TitleBarBackgroundColor"];
        if (MainPage is NavigationPage navigationPage)
        {
            navigationPage.BarBackgroundColor = titleBarBackgroundColor;
        }

    }
}
