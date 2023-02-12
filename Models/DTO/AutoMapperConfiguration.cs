using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using climate_API.Models.entityFramework;
using climate_API.Models.DTO;
using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace climate_API.Models.DTO
{
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddCollectionMappers();

                cfg.CreateMap<tblAlert, tblAlertDTO>()
                .ForMember(p => p.tblWeatherForecast, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblClimaticPhenomenon, tblClimaticPhenomenonDTO>()
                .ForMember(p => p.tblWeatherForecast, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblCountry, tblCountryDTO>()
                .ForMember(p => p.tblTerritory, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblTerritory, tblTerritoryDTO>()
                .ForMember(p => p.tblCountry, s => s.Ignore())
                .ForMember(p => p.tblWeatherStation, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblWeatherStation, tblWeatherStationDTO>()
                .ForMember(p => p.tblTerritory, s => s.Ignore())
                .ForMember(p => p.tblWeatherForecast, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblTypeTemperature, tblTypeTemperatureDTO>()
                .ForMember(p => p.tblWeatherForecast, s => s.Ignore())
                .ReverseMap();

                cfg.CreateMap<tblUsers, tblUsersDTO>()
                .ReverseMap();

                cfg.CreateMap<tblWeatherForecast, tblWeatherForecastDTO>()
                .ForMember(p => p.tblAlert, s => s.Ignore())
                .ForMember(p => p.tblClimaticPhenomenon, s => s.Ignore())
                .ForMember(p => p.tblTypeTemperature, s => s.Ignore())
                .ForMember(p => p.tblWeatherStation, s => s.Ignore())
                .ReverseMap();

            });
        }
    }
}