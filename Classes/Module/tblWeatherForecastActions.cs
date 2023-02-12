using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using climate_API.Models.DTO;
using climate_API.Models.entityFramework;
using climate_API.Classes.Interface;
using climate_API.Classes.Util;


namespace climate_API.Classes.Module
{
    public class tblWeatherForecastActions : IReadable<tblWeatherForecastDTO>, IWriteable<WeatherForecastInsert>, IRemovable<WeatherForecastInsert>, IConvertDTO<WeatherForecastInsert, tblWeatherForecast>
    {
        public tblWeatherForecast CONVERT_DTO(WeatherForecastInsert OBJ)
        {
            tblWeatherForecast Entidad = new tblWeatherForecast();
            Entidad.ID = OBJ.ID;
            Entidad.ClimaticDescription = OBJ.ClimaticDescription;
            Entidad.DateRegister = OBJ.DateRegister;
            Entidad.IdAlert = OBJ.IdAlert == null ? null : OBJ.IdAlert;
            Entidad.IdClimaticPhenomenon = OBJ.IdClimaticPhenomenon == null ? null : OBJ.IdClimaticPhenomenon;
            Entidad.IdTypeTemperature = OBJ.IdTypeTemperature;
            Entidad.IdWeatherStation = OBJ.IdWeatherStation;
            Entidad.Temperature = OBJ.Temperature;
            Entidad.StateRegister = OBJ.StateRegister;
            return Entidad;
        }

        public void DELETE(long ID)
        {
            try 
            {
                using (climateEntities entidad = new climateEntities())
                {
                    tblWeatherForecast Objeto = entidad.tblWeatherForecast
                        .Where(p => p.ID == ID)
                        .Select(s => s)
                        .FirstOrDefault();

                    Objeto.StateRegister = 0;
                    entidad.Entry(Objeto).State = System.Data.Entity.EntityState.Modified;
                    entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo DELETE " + ex.ToString());
            }
        }

        public tblWeatherForecastDTO GET(int ID)
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    tblWeatherForecast Obj = entidad.tblWeatherForecast
                        .Where(i => i.ID == ID && i.StateRegister == 1)
                        .Select(p => p)
                        .FirstOrDefault();

                    if (Obj != null)
                    {
                        return Mapper.Map<tblWeatherForecastDTO>(Obj);
                    }
                    else
                    {
                        return Mapper.Map<tblWeatherForecastDTO>(null);
                    }
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GET " + ex.ToString());
                throw ex;
            }
        }

        public List<tblWeatherForecastDTO> GETALL()
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<List<tblWeatherForecastDTO>>(entidad.tblWeatherForecast.Where(p => p.StateRegister == 1).ToList());
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GETALL " + ex.ToString());
                throw ex;
            } 
        }

        public void INSERT(WeatherForecastInsert OBJ)
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    entidad.tblWeatherForecast.Add(CONVERT_DTO(OBJ));
                    entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo INSERT " + ex.ToString());
            }
        }

        public void UPDATE(WeatherForecastInsert OBJ)
        {
            try
            {
                
                using (climateEntities entidad = new climateEntities())
                {
                    var entity = entidad.tblWeatherForecast.Where(p => p.ID == OBJ.ID).Select(x => x).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.IdClimaticPhenomenon = OBJ.IdClimaticPhenomenon;
                        entity.IdTypeTemperature = OBJ.IdTypeTemperature;
                        entity.IdWeatherStation = OBJ.IdWeatherStation;
                        entity.IdAlert = OBJ.IdAlert;
                        entity.StateRegister = OBJ.StateRegister;
                        entity.Temperature = OBJ.Temperature;
                        entity.DateRegister = OBJ.DateRegister;
                        entity.ClimaticDescription = OBJ.ClimaticDescription;
                        entidad.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        entidad.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo UPDATE " + ex.ToString());
            }
        }
    }
}