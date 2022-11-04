namespace Echipa07;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

	private async void buttonContact_Clicked(object sender, EventArgs e)
	{
        await DisplayAlert("Message sent", "Thank you for your message! Have a nice day! :D", "OK");
		editorEmail.Text = "";
		entryName.Text = "";
		editorMessage.Text = "";
    }
}