using Microsoft.Maui.Controls;

namespace Echipa07;

public partial class SearchBookPage : ContentPage
{
    SearchBookViewModel viewModel1 { get; set; }
    List<Book> favouriteBooks = new List<Book>();

    
    public SearchBookPage()
	{
		InitializeComponent();
        viewModel1 = new SearchBookViewModel();
        BindingContext = viewModel1;
     

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        MenuItem menuItem = sender as MenuItem;
        var contextItem = menuItem.BindingContext;
        favouriteBooks.Add(contextItem as Book);
        SearchBookViewModel.Books.Add(contextItem as Book);



    }

    private void Review_Clicked(object sender, EventArgs e)
    {
        MenuItem menuItem = sender as MenuItem;
        var contextItem = menuItem.BindingContext;
        AddReview addReviewPage = new AddReview(contextItem as Book);
        Navigation.PushAsync(addReviewPage);
    }
}