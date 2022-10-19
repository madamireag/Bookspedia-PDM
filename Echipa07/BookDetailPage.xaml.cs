namespace Echipa07;

public partial class BookDetailPage : ContentPage
{
    BookDetailViewModel viewModel { get; set; }

    public BookDetailPage(Book bookDetails)
    {
        InitializeComponent();
        viewModel = new BookDetailViewModel(bookDetails);
        BindingContext = viewModel;
    }


}