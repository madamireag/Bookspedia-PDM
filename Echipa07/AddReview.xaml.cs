namespace Echipa07;

public partial class AddReview : ContentPage
{
	MyReview myReview = new MyReview();
	ReviewCarteDao reviewCarteDao = new ReviewCarteDao();
	List<MyReview> reviewList = new List<MyReview>();
	public AddReview(Book b)
	{
		InitializeComponent();
		myReview.BookTitle = b.VolumeInfo.Title;
	}

	private void AddButton_Clicked(object sender, EventArgs e)
	{
		String rev = reviewEntry.Text;
		myReview.ReviewText = rev;
		reviewCarteDao.AdaugaReview(myReview);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		reviewList = reviewCarteDao.ObtineToateInregistrarile();
		lstRev.ItemsSource = reviewList;
	}
}