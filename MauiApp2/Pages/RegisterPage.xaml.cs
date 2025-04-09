using MauiApp2.Models;  
namespace MauiApp2.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text,
            
        };
        await App.DBService.AddUserAsync(user);
        await DisplayAlert("Успешно", "Регистрация выполнена", "ОК");
        await Shell.Current.GoToAsync("//login");
    }
}