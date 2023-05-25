﻿using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //127964
            string apikey = "nyL9MUNiaOt7Gx8G5RSJd6dhVu6crdKt";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=nyL9MUNiaOt7Gx8G5RSJd6dhVu6crdKt&metric=true";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.DailyForecastsDay = weatherInfo.DailyForecasts[0].Date;
                dto.DailyForecastsEpochDate = weatherInfo.DailyForecasts[0].EpochDate;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;
            }
            return dto;
        }

        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string IDOWeather = "fbfb382bf741b9d5b6dbf1f0a2a2f496";

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={IDOWeather}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.City = weatherInfo.Name;
                dto.Temperature = weatherInfo.Main.Temp;
                dto.Pressure = weatherInfo.Main.Pressure;
                dto.Feels_like = weatherInfo.Main.FeelsLike;
                dto.Timezone = weatherInfo.Timezone;
                dto.Lat = weatherInfo.Coord.Lat;
                dto.Lon = weatherInfo.Coord.Lon;
                dto.Description = weatherInfo.Weather[0].Description;
                dto.Humidity = weatherInfo.Main.Humidity;
                dto.Speed = weatherInfo.Wind.Speed;

            }
            return dto;
        }
    }
}
