﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using climate_API.Classes.Util;

namespace climate_API.Classes.JWT
{
    internal class TokenValidatorHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            if (!request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorizeHeader) || authorizeHeader.Count() > 1)
            {
                return false;
            }

            var bearerToken = authorizeHeader.ElementAt(0);

            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;

            return true;
        }

        /// <summary>
        /// Sobrecarga del metodo SendAsync que permite validar el JWT en la cabecera de la peticion http
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;


            if (!TryRetrieveToken(request, out string token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                var key = ConfigurationManager.AppSettings["JWT_SECRET-KEY"];
                var audience = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
                var IssuerKey = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(key));

                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                TokenValidationParameters parametersToken = new TokenValidationParameters()
                {
                    ValidAudience = audience,
                    ValidIssuer = IssuerKey,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, parametersToken, out SecurityToken securityToken);
                HttpContext.Current.User = tokenHandler.ValidateToken(token, parametersToken, out securityToken);

                return base.SendAsync(request, cancellationToken);

            }
            catch (SecurityTokenValidationException se)
            {
                statusCode = HttpStatusCode.Unauthorized;
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo SendAsync " + se.ToString());
            }
            catch (Exception ex)
            {
                consumirLog.crearRegistroLog("climate_API" + DateTime.Now.ToShortDateString(), "Ha ocurrido un error en el metodo SendAsync " + ex.ToString());
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {

            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }

            return false;
        }

    }
}