namespace Echipa07;

public partial class MainPage : ContentPage
{
	Book books = new Book();
    public List<Book> booksList { get; set; }

    public MainPage()
	{
		InitializeComponent();
        Task.Run(async () => { await InitializeazaListaCarti(); }).Wait();
    }

    public async Task InitializeazaListaCarti()
    {
        booksList = await ObtineCartiDinServiciu();
    }

    public async Task<List<Book>> ObtineCartiDinServiciu()
    {

        booksList = new List<Book>();
        var booksArray = await GoogleBooksService.getAllBooks();
        foreach (var book in booksArray.Itemss)
        {
            booksList.Add(book);
        }
        listViewBooks.ItemsSource = booksList;
        return booksList;
    }

    private void listViewBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var detailBookPage = new BookDetailPage(e.SelectedItem as Book);
        Navigation.PushAsync(detailBookPage);
    }
}

