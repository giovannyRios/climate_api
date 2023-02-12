using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using climate_API.Classes.Interface;
using climate_API.Models.DTO;
using climate_API.Models.entityFramework;
using climate_API.Classes.Util;

namespace climate_API.Classes.Module
{
    public class tblWeatherStationActions:IReadable<tblWeatherStationDTO>
    {
        public tblWeatherStationDTO GET(int ID)
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<tblWeatherStationDTO>(entidad.tblWeatherStation.Where(p => p.ID == ID).Select(p => p).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GET " + ex.ToString());
                throw ex;
            }
        }

        public List<tblWeatherStationDTO> GETALL()
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<List<tblWeatherStationDTO>>(entidad.tblWeatherStation.Select(p => p));
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GETALL " + ex.ToString());
                throw ex;
            }
        }
    }
}