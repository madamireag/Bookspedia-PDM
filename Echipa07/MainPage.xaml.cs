namespace Echipa07;

public partial class MainPage : ContentPage
{
	Book books = new Book();
    public List<Book> booksList { get; set; }

    public MainPage()
	{
		InitializeComponent();
        Task.Run(async () => { await InitializeBookList(); }).Wait();
    }

    public async Task InitializeBookList()
    {
        booksList = await GetBooksFromService();
    }

    public async Task<List<Book>> GetBooksFromService()
    {

        booksList = new List<Book>();
        var booksArray = await GoogleBooksService.getAllBooks();
        foreach (var book in booksArray.Itemss)
        {
            SearchBookViewModel.CheckBook(book);
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

