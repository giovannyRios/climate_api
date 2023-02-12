using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;
using AutoMapper;
using climate_API.Classes.Interface;
using climate_API.Models.DTO;
using climate_API.Models.entityFramework;
using climate_API.Classes.Util;
using climate_API.Classes.Module;
using System.Collections;

namespace climate_API.Controllers
{
    public class weatherForecastController : ApiController
    {
        [Authorize]
        [HttpGet,Route("~/api/GetAllweatherForecast")]
        [SwaggerOperation("GetAllweatherForecast")]
        public HttpResponseMessage GetAllweatherForecast()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            
            try
            {
                IReadable<tblWeatherForecastDTO> readable = new tblWeatherForecastActions();
                List<tblWeatherForecastDTO> ltsWeatherForecastDTOs = readable.GETALL();

                if (ltsWeatherForecastDTOs.Count > 0)
                {
                    response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, ltsWeatherForecastDTOs);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros en el sistema");
                }

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAll" + ex.ToString());
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetweatherForecast")]
        [SwaggerOperation("GetweatherForecast")]
        public HttpResponseMessage GetweatherForecast(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblWeatherForecastDTO> readable = new tblWeatherForecastActions();
                tblWeatherForecastDTO WeatherForecastDTOs = readable.GET(ID);

                if (WeatherForecastDTOs != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, WeatherForecastDTOs);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros en el sistema");
                }

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAll" + ex.ToString());
                return response;
            }
        }

        [Authorize]
        [HttpPost, Route("~/api/RegisterWeatherForecast")]
        [SwaggerOperation("RegisterWeatherForecast")]
        public HttpResponseMessage RegisterWeatherForecast(WeatherForecastInsert obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IWriteable<WeatherForecastInsert> writeable = new tblWeatherForecastActions();
                writeable.INSERT(obj);
                response = Request.CreateResponse(HttpStatusCode.OK, "Insercion exitosa");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo Register" + ex.ToString());
                return response;
            }
        }

        [Authorize]
        [HttpPost, Route("~/api/DeleteWeatherForecast")]
        [SwaggerOperation("DeleteWeatherForecast")]
        public HttpResponseMessage DeleteWeatherForecast(long ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IRemovable<WeatherForecastInsert> writeable = new tblWeatherForecastActions();
                writeable.DELETE(ID);
                response = Request.CreateResponse(HttpStatusCode.OK, "borrado exitoso");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo Delete" + ex.ToString());
                return response;
            }
        }

        [Authorize]
        [HttpPost, Route("~/api/UpdateWeatherForecast")]
        [SwaggerOperation("UpdateWeatherForecast")]
        public HttpResponseMessage UpdateWeatherForecast(WeatherForecastInsert obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IWriteable<WeatherForecastInsert> writeable = new tblWeatherForecastActions();
                writeable.UPDATE(obj);
                response = Request.CreateResponse(HttpStatusCode.OK, "Actualizacion exitosa");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo Delete" + ex.ToString());
                return response;
            }
        }

    }
}
