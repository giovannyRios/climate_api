using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace climate_API.Models.DTO
{
    public class tblClimaticPhenomenonDTO
    {
        public int ID { get; set; }

        [Required]
        public string DescriptionClimaticPhenomenon { get; set; }

        public ICollection<tblWeatherForecastDTO> tblWeatherForecast { get; set; }
    }
}