using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("sede")]
    public class SedeController : BaseController
    {

        public SedeController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(SedeController)} en ejecución");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("error")]
        public IHttpActionResult CreateError()
        {
            throw new System.Exception("Este es un error no manejado");
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult Index()
        {
            return Ok(_unit.SedeRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.SedeRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Sede sede)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.SedeRepository.Add(sede);
            _unit.Save();

            var id = _unit.SedeRepository.GetAll().LastOrDefault().SedeId;

            return Ok(new { id });
        }

                //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Sede sede)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.SedeRepository.Update(sede);
                _unit.Save();

            }
            catch (Exception)
            {

                return BadRequest("Id incorrecto");
            }

            return Ok(new { status = true });
        }

    }
}
