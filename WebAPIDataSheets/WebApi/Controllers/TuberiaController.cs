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
    [RoutePrefix("tuberia")]
    public class TuberiaController : BaseController
    {

        public TuberiaController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(TuberiaController)} en ejecución");
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
            return Ok(_unit.TuberiaRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.TuberiaRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Tuberia tuberia)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.TuberiaRepository.Add(tuberia);
            _unit.Save();

            var id = _unit.TuberiaRepository.GetAll().LastOrDefault().TuberiaId;

            return Ok(new { id });
        }

        //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Tuberia tuberia)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.TuberiaRepository.Update(tuberia);
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
