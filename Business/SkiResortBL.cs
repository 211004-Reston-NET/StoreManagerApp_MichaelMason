using Data;
using Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SkiResortBL
    {
        readonly SkiResortRepository repository;
        public string baseUrl = "https://api.weather.gov/";
        public string points = "points/";

        public SkiResortBL(SkiResortRepository context)
        {
            repository = context;
        }

        public IEnumerable<SkiResort> GetAllResorts()
        {
            return repository.GetAll();
        }

        public IEnumerable<SkiResort> SearchByName(string query)
        {
            return GetAllResorts().Where(r => r.Name.ToLower().Contains(query.ToLower()));
        }

        public SkiResort GetByPrimaryKey(int skiId)
        {
            var resort =  repository.GetByPrimaryKey(skiId);
            var url = GetForcastUrl(resort.Latitude, resort.Longitude);
            var forecast = GetForecast(url);
            resort.Forecasts = forecast.Properties.Periods;
            return resort;
        }

        public string GetForcastUrl(decimal latitude, decimal longitude)
        {
            var client = new RestClient($"{baseUrl}{points}{latitude},{longitude}");
            var response = client.Execute(new RestRequest());
            var url = WeatherUrlApi.FromJson(response.Content);
            return url.Properties.Forecast.ToString();
        }

        public ForecastApi GetForecast(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());
            var forecast = ForecastApi.FromJson(response.Content);
            return forecast;
        }
    }
}
