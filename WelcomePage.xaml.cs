namespace weather_app;
public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}
	private void ButtonGetStarted_Clicked(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new WeatherPage());
	}
}