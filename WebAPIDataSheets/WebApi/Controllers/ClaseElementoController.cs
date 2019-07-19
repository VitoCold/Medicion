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
    [RoutePrefix("clase")]
    public class ClaseElementoController : BaseController
    {
        public ClaseElementoController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(ClaseElementoController)} en ejecución");
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
            return Ok(_unit.ClaseElementoRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.ClaseElementoRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(ClaseElemento clase)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.ClaseElementoRepository.Add(clase);
            _unit.Save();

            var id = _unit.ClaseElementoRepository.GetAll().LastOrDefault().ClaseElementoId;

            return Ok(new { id });
        }

        //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(ClaseElemento clase)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.ClaseElementoRepository.Update(clase);
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
