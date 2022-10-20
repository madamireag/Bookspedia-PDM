namespace Echipa07;

public partial class SearchBookPage : ContentPage
{
    SearchBookViewModel viewModel1 { get; set; }
    public SearchBookPage()
	{
		InitializeComponent();
        viewModel1 = new SearchBookViewModel();
        BindingContext = viewModel1;

    }
}