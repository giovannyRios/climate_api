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
    public class tblAlertActions : IReadable<tblAlertDTO>
    {
        public tblAlertDTO GET(int ID)
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<tblAlertDTO>(entidad.tblAlert.Where(p => p.ID == ID).Select(p => p).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GET " + ex.ToString());
                throw ex;
            }
        }

        public List<tblAlertDTO> GETALL()
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<List<tblAlertDTO>>(entidad.tblAlert.Select(p => p).ToList());
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GET " + ex.ToString());
                throw ex;
            }
        }
    }
}