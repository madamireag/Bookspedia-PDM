using Microcharts;

namespace Echipa07;

public partial class BooksCategoriesPage : ContentPage
{
    public List<Book> booksList { get; set; }
    public BooksCategoriesPage()
	{
		InitializeComponent();
        var categoriesList = new List<string>();
        categoriesList.Add("business");
        categoriesList.Add("art");
        categoriesList.Add("economy"); 
        categoriesList.Add("finance");
        categoriesList.Add("philosophy");
        categoriesList.Add("biography");
        categoriesList.Add("technology");
        categoriesList.Add("history");

        categoriesPicker.ItemsSource = categoriesList;
    }

    private void categoriesPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string categoryName;
        categoryName = (string)categoriesPicker.ItemsSource[categoriesPicker.SelectedIndex];
        Task.Run(async () => { await InitializeBookList(categoryName); }).Wait();
    }

    public async Task InitializeBookList(string categoryName)
    {
        await getBookCategoriesFromService(categoryName);
    }

    public async Task getBookCategoriesFromService(string categoryName)
    {
        booksList = new List<Book>();
        
        var booksArray = await GoogleBooksService.getBooksCategories(categoryName);
        foreach (var book in booksArray.Itemss)
        {
            if (book.VolumeInfo.AverageRating != null)
            {
                booksList.Add(book);
                
            } 
        } 
        fillChart(booksList);  
    }

    public void fillChart(List<Book> bookList)
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>();
        Random random = new Random();

        foreach (var book in booksList) {
            chartEntries.Add(new ChartEntry(float.Parse(book.VolumeInfo.AverageRating))
                {
                    Label = book.VolumeInfo.Title,
                    ValueLabel = book.VolumeInfo.AverageRating.ToString(),
                    Color = new SkiaSharp.SKColor((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256))
                });
            }
       
        chartView.Chart = new BarChart()
        {
            Entries = chartEntries
        };
    }

}