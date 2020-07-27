using RuletaAPI.Bussines;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RuletaAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
        // GET: Apuesta
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("generaApuesta")]
        public IHttpActionResult generaApuesta(Apuesta_Model datosApuesta)
        {
            Apuesta_Model respuesta = new Apuesta_Model();
            if (datosApuesta != null)
            {
                HttpRequestHeaders headers = this.Request.Headers;
                string idUsuario = string.Empty;
                if (headers.Contains("Id_Usuario"))
                {
                    idUsuario = headers.GetValues("Id_Usuario").First();
                }
                if (!new Apuesta_Bussines().Autenticado(idUsuario, datosApuesta.ValorApuesta))
                    return Unauthorized();

                if (new Apuesta_Bussines().validacionApuesta(datosApuesta))
                {
                    datosApuesta.IdUsuario = int.Parse(idUsuario);
                    respuesta = new Apuesta_Bussines().generaApuesta(datosApuesta);
                }
            }
            else
            {
                throw new Exception("Debe Enviar los parametros {NumeroApuesta}, {ColorApuesta}, {ValorApuesta}, {IdRuleta} ");
            }

            return Ok(respuesta);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("cierreApuestas")]
        public IHttpActionResult cierreApuesta(int idRuleta)
        {
            try
            {
                List<Apuesta_Model> listaApuestas = new List<Apuesta_Model>();
                bool cierre = new Ruleta_Bussines().cierreRuleta(idRuleta);
                if (cierre)
                {
                    listaApuestas = new Apuesta_Bussines().cierreApuesta(idRuleta);
                }
                return Ok(listaApuestas);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}