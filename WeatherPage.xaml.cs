using weather_app.Services;

namespace weather_app;

public partial class weather_app : ContentPage
{
	private double longitude;
	private double latitude;
	private double city;
	public List<Models.List> WeatherList;
	public weather_app()
	{
		InitializeComponent();
		WeatherList = new List<Models.List>();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await GetLocation();
		await GetWeatherDataByLocation(latitude, longitude);
	}

	public async Task GetLocation()
	{
		var location = await Geolocation.Default.GetLocationAsync();
		longitude = location.Longitude;
		latitude = location.Latitude;
	}

	public async Task GetWeatherDataByLocation(double latitude, double longitude)
	{
		var result = await ApiService.GetWeather(latitude, longitude);
		UpdateUI(result);
	}
	public async Task GetWeatherDataByCity(string city)
	{
		var result = await ApiService.GetWeatherByCity(city);
		UpdateUI(result);
	}
	private async void TapLocation_Tapped(object sender, EventArgs e)
	{
		await GetLocation();
		await GetWeatherDataByLocation(latitude, longitude);
	}
	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		var response = await DisplayPromptAsync(title: "", message: "", placeholder: "Type the city you want to search", accept: "Show", cancel: "Cancel");
		if (response != null)
		{
			await GetWeatherDataByCity(response);
		}
	}
	public void UpdateUI(dynamic result)
	{
		foreach (var item in result.list)
		{
			WeatherList.Add(item);
		}
		CvWeather.ItemsSource = WeatherList;

		LblCity.Text = result.city.name;
		LblWeatherDescription.Text = result.list[0].weather[0].description;
		LblTemperature.Text = result.list[0].main.temperature + "°C";
		LblHumidity.Text = "%" + result.list[0].main.humidity;
		LblWind.Text = result.list[0].wind.speed + "km/h";
		ImgWeatherIcon.Source = result.list[0].weather[0].customIcon;
	}

}