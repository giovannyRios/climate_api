using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace climate_API.Models.DTO
{
    public class tblAlertDTO
    {
        public int ID { get; set; }

        [Required]
        public string NameAlert { get; set; }

        public ICollection<tblWeatherForecastDTO> tblWeatherForecast { get; set; }
    }
}