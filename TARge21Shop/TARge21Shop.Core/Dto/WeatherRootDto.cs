using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARge21Shop.Core.Dto.DailyForecastDto;

namespace TARge21Shop.Core.Dto
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<HeadlineDto> DailyForecasts { get; set; }
    }
}
