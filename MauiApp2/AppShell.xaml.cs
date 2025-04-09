namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(Pages.LoginPage));
            Routing.RegisterRoute("register", typeof(Pages.RegisterPage));
            Routing.RegisterRoute("books", typeof(Pages.BookPage));
            Routing.RegisterRoute("addbook", typeof(Pages.AddBookPage));
        }
    }
}
