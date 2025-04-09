namespace MauiApp2.Pages;

public partial class BookPage : ContentPage
{
	public BookPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadBooks();
    }

    private async void LoadBooks()
    {
        var books = await App.DBService.GetBooksAsync();
        booksCollection.ItemsSource = books;
    }
}