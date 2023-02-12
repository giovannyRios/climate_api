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
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace climate_API.Controllers
{
    public class valoresDefaultController : ApiController
    {
        [Authorize]
        [HttpGet, Route("~/api/GetAllAlert")]
        [SwaggerOperation("GetAllAlert")]
        public HttpResponseMessage GetAllAlert()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblAlertDTO> readable = new tblAlertActions();
                List<tblAlertDTO> ltsAlert = readable.GETALL();
                if (ltsAlert != null)
                {
                    if (ltsAlert.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltsAlert);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllAlert" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetAlert")]
        [SwaggerOperation("GetAlert")]
        public HttpResponseMessage GetAlert(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblAlertDTO> readable = new tblAlertActions();
                tblAlertDTO Alert = readable.GET(ID);
                if (Alert != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Alert);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllAlert" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetAllClimaticPhenomenon")]
        [SwaggerOperation("GetAllClimaticPhenomenon")]
        public HttpResponseMessage GetAllClimaticPhenomenon()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblClimaticPhenomenonDTO> readable = new tblClimaticPhenomenonActions();
                List<tblClimaticPhenomenonDTO> ltsClimaticPhenomenonDTO = readable.GETALL();
                if (ltsClimaticPhenomenonDTO != null)
                {
                    if (ltsClimaticPhenomenonDTO.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltsClimaticPhenomenonDTO);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllClimaticPhenomenon" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetClimaticPhenomenon")]
        [SwaggerOperation("GetClimaticPhenomenon")]
        public HttpResponseMessage GetClimaticPhenomenon(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblClimaticPhenomenonDTO> readable = new tblClimaticPhenomenonActions();
                tblClimaticPhenomenonDTO ClimaticPhenomenon = readable.GET(ID);
                if (ClimaticPhenomenon != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, ClimaticPhenomenon);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetClimaticPhenomenon" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetAllCountry")]
        [SwaggerOperation("GetAllCountry")]
        public HttpResponseMessage GetAllCountry()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblCountryDTO> readable = new tblCountryActions();
                List<tblCountryDTO> ltstblCountryDTO = readable.GETALL();
                if (ltstblCountryDTO != null)
                {
                    if (ltstblCountryDTO.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltstblCountryDTO);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllCountry" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetCountry")]
        [SwaggerOperation("GetCountry")]
        public HttpResponseMessage GetCountry(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblCountryDTO> readable = new tblCountryActions();
                tblCountryDTO Country = readable.GET(ID);
                if (Country != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Country);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetCountry" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }


        [Authorize]
        [HttpGet, Route("~/api/GetAllTerritory")]
        [SwaggerOperation("GetAllTerritory")]
        public HttpResponseMessage GetAllTerritory()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblTerritoryDTO> readable = new tblTerritoryActions();
                List<tblTerritoryDTO> ltstblTerritoryDTO = readable.GETALL();
                if (ltstblTerritoryDTO != null)
                {
                    if (ltstblTerritoryDTO.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltstblTerritoryDTO);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllTerritory" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetTerritory")]
        [SwaggerOperation("GetTerritory")]
        public HttpResponseMessage GetTerritory(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblTerritoryDTO> readable = new tblTerritoryActions();
                tblTerritoryDTO territory = readable.GET(ID);
                if (territory != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, territory);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetTerritory" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetAllTypeTemperature")]
        [SwaggerOperation("GetAllTypeTemperature")]
        public HttpResponseMessage GetAllTypeTemperature()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblTypeTemperatureDTO> readable = new tblTypeTemperatureActions();
                List<tblTypeTemperatureDTO> ltsTypeTemperatureDTO = readable.GETALL();
                if (ltsTypeTemperatureDTO != null)
                {
                    if (ltsTypeTemperatureDTO.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltsTypeTemperatureDTO);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllTypeTemperature" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetTypeTemperature")]
        [SwaggerOperation("GetTypeTemperature")]
        public HttpResponseMessage GetTypeTemperature(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblTypeTemperatureDTO> readable = new tblTypeTemperatureActions();
                tblTypeTemperatureDTO TypeTemperatureDTO = readable.GET(ID);
                if (TypeTemperatureDTO != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, TypeTemperatureDTO);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetTypeTemperature" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetAllWeatherStation")]
        [SwaggerOperation("GetAllWeatherStation")]
        public HttpResponseMessage GetAllWeatherStation()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblWeatherStationDTO> readable = new tblWeatherStationActions();
                List<tblWeatherStationDTO> ltsWeatherStation = readable.GETALL();
                if (ltsWeatherStation != null)
                {
                    if (ltsWeatherStation.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, ltsWeatherStation);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetAllWeatherStation" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

        [Authorize]
        [HttpGet, Route("~/api/GetWeatherStation")]
        [SwaggerOperation("GetWeatherStation")]
        public HttpResponseMessage GetWeatherStation(int ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            try
            {
                IReadable<tblWeatherStationDTO> readable = new tblWeatherStationActions();
                tblWeatherStationDTO WeatherStation = readable.GET(ID);
                if (WeatherStation != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, WeatherStation);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No existen registros");
                }

                return response;
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo GetWeatherStation" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error, contacte al administrador");
                return response;
            }
        }

    }
}