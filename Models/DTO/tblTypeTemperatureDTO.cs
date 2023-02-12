using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace climate_API.Models.DTO
{
    public class tblTypeTemperatureDTO
    {
        public int ID { get; set; }

        [Required]
        public string NameTypeTemp { get; set; }

        public ICollection<tblWeatherForecastDTO> tblWeatherForecast { get; set; }
    }
}