namespace weather_app;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		VersionTracking.Track();
		if (VersionTracking.IsFirstLaunchEver == true)
		{
			MainPage = new WelcomePage();
		}
		else
		{
			MainPage = new WeatherPage();
		}
	}
}

// http://api.openweathermap.org/data/2.5/forecast?lat=37.065318142159235&lon=37.366743007348084&appid=146ed57c1f86c07d4ba0bac95bf928ac
// 37.065318142159235, 37.366743007348084
// api.openweathermap.org/data/2.5/forecast?lat=37.065318142159235&lon=37.366743007348084&appid=146ed57c1f86c07d4ba0bac95bf928ac

// https://pro.openweathermap.org/data/2.5/forecast/hourly?lat=37.065952&lon=37.378109&appid=146ed57c1f86c07d4ba0bac95bf928ac
