

namespace Echipa07;

public partial class Favourites : ContentPage
{
    FavouriteBooksViewModel viewModel;
	public Favourites()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        viewModel = new FavouriteBooksViewModel();
        BindingContext = viewModel;
    }
}