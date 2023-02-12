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
    public class tblClimaticPhenomenonActions : IReadable<tblClimaticPhenomenonDTO>
    {

        public tblClimaticPhenomenonDTO GET(int ID)
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<tblClimaticPhenomenonDTO>(entidad.tblClimaticPhenomenon.Where(p => p.ID == ID).Select(p => p).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GET " + ex.ToString());
                throw ex;
            }
        }

        public List<tblClimaticPhenomenonDTO> GETALL()
        {
            try
            {
                using (climateEntities entidad = new climateEntities())
                {
                    return Mapper.Map<List<tblClimaticPhenomenonDTO>>(entidad.tblClimaticPhenomenon.Select(p => p));
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