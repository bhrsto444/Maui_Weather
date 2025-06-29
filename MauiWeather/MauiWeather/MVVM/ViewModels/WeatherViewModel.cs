using MauiWeather.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiWeather.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {
        public WeatherData WeatherData { get; set; }
        public string PlaceName { get; set; }

        public DateTime Date { get; set; }= DateTime.Now;

        public bool IsVisible { get; set; }

        public bool IsLoading  { get; set; }

        private HttpClient client;

        public WeatherViewModel()
        {
            client = new HttpClient();
        }
        public ICommand SearchCommand =>
            new Command(async (searcText) =>
            {
                PlaceName = searcText.ToString();
                var location=
                    await GetCoordinatesAsync(searcText.ToString());
                await GetWeather(location);
            });

        // NOVA METODA MAKON DDOAVANJA JSON WEATHER

        private async Task GetWeather(Location location)
        {
            var url =
                $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,weather_code,wind_speed_10m,wind_direction_10m&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=Europe%2FBerlin";

            IsLoading=true;

            var response =
                 await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                         .DeserializeAsync<WeatherData>(responseStream);

                    WeatherData = data;

                    // VRIJEME ZA SVAKI DAN
                    for (int i = 0; i < WeatherData.daily.time.Length; i++) 
                    {
                        var daily2 = new Daily2 
                        {
                            time = WeatherData.daily.time[i],
                            temperature_2m_max = WeatherData.daily.temperature_2m_max[i],
                            temperature_2m_min = WeatherData.daily.temperature_2m_min[i],
                            weather_code = WeatherData.daily.weather_code[i]
                        };
                        WeatherData.daily2.Add(daily2);
                    }

                    IsVisible = true;

                }
            }
            IsLoading = false;

        }
        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding
                 .Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null)
                Console
                     .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            return location;
        }

    }
}
