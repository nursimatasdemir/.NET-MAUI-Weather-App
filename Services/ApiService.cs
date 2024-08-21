using System;
using Newtonsoft.Json;
using weather_app.Models;

namespace weather_app.Services;

public static class ApiService
{
    public static async Task<WeatherRoot> GetWeather(double latitude, double longitude)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=146ed57c1f86c07d4ba0bac95bf928ac", latitude, longitude));
        return JsonConvert.DeserializeObject<WeatherRoot>(response);

    }
    public static async Task<WeatherRoot> GetWeatherByCity(string city)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=146ed57c1f86c07d4ba0bac95bf928ac", city));
        return JsonConvert.DeserializeObject<WeatherRoot>(response);

    }
}
