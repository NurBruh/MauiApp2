
using MauiApp2.Models;
namespace MauiApp2.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void LogInButton_Clicked(object sender, EventArgs e)
	{
		var user = await App.DBService.GetUserByCredentialAsync(usernameEntry.Text, passwordEntry.Text);

		if (user != null)
		{
			await DisplayAlert("Успешно", "Вход выполнено", "ОК");
			await Shell.Current.GoToAsync("//books");
		}
		else {
			await DisplayAlert("Ошибка", "Неверный логин и пароль", "ОК");


		}
	}

	private async void OnRegisterButtonClicked(object sender, EventArgs e) { 
		await Shell.Current.GoToAsync("//register");
    }
}