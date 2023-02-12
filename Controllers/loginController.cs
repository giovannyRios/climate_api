using System.Net;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;
using AutoMapper;
using climate_API.Classes.Interface;
using climate_API.Models.DTO;
using climate_API.Models.entityFramework;
using climate_API.Classes.Util;
using climate_API.Classes.Module;
using climate_API.Classes.JWT;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Text.RegularExpressions;

namespace climate_API.Controllers
{
    public class loginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost,Route("~/api/LoginUser")]
        [SwaggerOperation("LoginUser")]
        public HttpResponseMessage LoginUser(tblUsersInsert user)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            try
            {
                tblUsersActions readable = new tblUsersActions();

                //Security
                string cadena = @"/[\t\r\n]|(--[^\r\n]*)|(\/\*[\w\W]*?(?=\*)\*\/)/gi";
                bool validacionUsuario = Regex.IsMatch(user.userName, cadena);
                bool validacionClave = Regex.IsMatch(user.userPassword, cadena);


                if (!validacionUsuario && !validacionClave)
                {
                    tblUsersDTO tblUser = readable.GET(user.userPassword,user.userName);
                    if (tblUser != null)
                    {
                        var token = TokenGenerator.tokenGeneratorJWT(tblUser.userName);
                        validacionToken validacion = new validacionToken();
                        if (validacion.Validation(token))
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, tblUser);
                            response.Headers.Add("token", token);
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error en el inicio de sesion, valide con el administrador");
                            consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en la validacion del token generado: " + token + ". verifique el metodo 'Validation' de la clase 'validacionToken'");
                        }
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "Verifique usuario o contraseña");
                    }
                }
                else
                {
                    consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), string.Format("Error en la autenticacion, se intento ingresar una cadena de datos insegura al sistema en usuario={0} o contraseña={1}", user.userName,user.userPassword));
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Verifique usuario o contraseña");
                }

                return response;

            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo LoginUser" + ex.ToString());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error al iniciar sesion, valide con el administrador");
                return response;
            }
        }
    }
}