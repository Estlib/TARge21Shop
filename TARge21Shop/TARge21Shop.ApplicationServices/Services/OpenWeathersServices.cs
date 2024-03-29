﻿using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class OpenWeathersServices : IOpenWeathersServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            //127964 Tallinna kood
            string IDOWeather = "c836675e8fc0f0ee19630e67b8f0fac3";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&APPID={IDOWeather}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherRootDto weatherResult = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.City = weatherResult.Name;
                dto.Temperature = Math.Round(weatherResult.Main.Temp);
                dto.Feels_like = Math.Round(weatherResult.Main.FeelsLike);
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.Speed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;
            }

            return dto;
        }
    }
}
