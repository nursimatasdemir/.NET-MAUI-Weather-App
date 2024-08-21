using weather_app.Services;

namespace weather_app;

public partial class weather_app : ContentPage
{
	public weather_app()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		var result = await ApiService.GetWeather(37.065318142159235, 37.366743007348084);
		LblCity.Text = result.city.name;
		LblWeatherDescription.Text = result.list[0].weather[0].description;
		LblTemperature.Text = result.list[0].main.temperatute + "°C";
		LblHumidity.Text = "%" + result.list[0].main.humidity;
		LblWind.Text = result.list[0].wind.speed + "km/h";
		ImgWeatherIcon.Source = result.list[0].weather[0].customIcon;
	}
}