using MauiApp2.Services;

namespace MauiApp2
{
    public partial class App : Application
    {
        public static DatabaseService DBService { get; private set; }
        public App()
        {
            InitializeComponent();
            DBService = new DatabaseService();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            
            await DBService.InitAsync();
        }
        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}