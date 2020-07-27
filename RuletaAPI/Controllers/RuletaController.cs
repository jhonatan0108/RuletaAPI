using RuletaAPI.Bussines;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RuletaAPI.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    [System.Web.Http.RoutePrefix("api/Ruleta")]
    public class RuletaController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("crearRuleta")]
        public IHttpActionResult crarRuela()
        {
            try
            {
                return Ok(new Ruleta_Bussines().crearRuleta());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("aperturaRuleta")]
        public IHttpActionResult aperturaRuleta(int IdRuleta)
        {
            try
            {
                return Ok(new Ruleta_Bussines().aperturaRuleta(IdRuleta));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("consultaRuletas")]
        public IHttpActionResult consultaRuletas()
        {
            try
            {
                return Ok(new Ruleta_Bussines().consultaRuletas());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}