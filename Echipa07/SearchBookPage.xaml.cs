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
        // ma gandeam aici sa salvam cartea in BD (sa avem cartile favorite stocate) si sa facem o pagina unde le afisam din BD pe cele favorite

    }
}