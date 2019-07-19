using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("estado")]
    public class EstadoController : BaseController
    {
        public EstadoController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(EstadoController)} en ejecución");
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
            return Ok(_unit.EstadoRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.EstadoRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Estado estado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.EstadoRepository.Add(estado);
            _unit.Save();

            var id = _unit.EstadoRepository.GetAll().LastOrDefault().EstadoId;

            return Ok(new { id });
        }

        //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Estado estado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.EstadoRepository.Update(estado);
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
