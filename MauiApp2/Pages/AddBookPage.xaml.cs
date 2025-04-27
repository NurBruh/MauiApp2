using MauiApp2.Models;
using MauiApp2.Pages;
using MauiApp2.Services	;
namespace MauiApp2.Pages;

public partial class AddBookPage : ContentPage
{
    public AddBookPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        
        var book = new Book
        {
            Title = titleEntry.Text,
            Author = authorEntry.Text,
            Genre = genreEntry.Text,
            Description = descriptionEditor.Text,
            UserId = 0
        };

        await App.DBService.AddBookAsync(book);
        await DisplayAlert("Готово", "Книга добавлена", "ОК");
        await Shell.Current.GoToAsync("//books");
    }
}
